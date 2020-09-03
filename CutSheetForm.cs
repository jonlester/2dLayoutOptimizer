using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dLayoutOptimizer
{
    public partial class CutSheetForm : Form
    {
        public List<Metafile> sheetImages = new List<Metafile>();
        public Queue<Metafile> printImages = new Queue<Metafile>();
        public CutSheetForm()
        {
            InitializeComponent();
        }

        public void RunJob(Job job)
        {           

            var cutsheets = Optimizer.Optimize(job);
            sheetImages.Clear();

            //Bitmap bm = new Bitmap(job.SheetLength + 1, job.SheetWidth*cutsheets.Count() + (20*cutsheets.Count() - 1) + 1);
            Font f = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Regular);
            for (int i = 0; i < cutsheets.Length; i++)
            {
                Metafile mf = MakeMetafile(job.SheetLength + 1, job.SheetWidth + 21);
                using (var ig = Graphics.FromImage(mf))
                {
                    var currentSheet = cutsheets[i];
                    int xOrigin = 0;
                    int yOrigin = 20;// i * (job.SheetWidth + 20) + 20;

                    ig.DrawString($"{job.JobName} Sheet {i + 1} of {cutsheets.Length}", f, Brushes.Black, new Point(0, yOrigin - 19));
                    ig.FillRectangle(new HatchBrush(HatchStyle.DiagonalCross, Color.Gray, Color.White), new Rectangle(0, yOrigin, job.SheetLength, job.SheetWidth));
                    
                    for (int s = 0; s < currentSheet.Segments.Count(); s++)
                    {

                        var currentSegment = currentSheet.Segments[s];
                        RenderSegments(ig, currentSegment, xOrigin, yOrigin);
                        xOrigin += currentSegment.Length + Segment.KerfWidth;
                    }
                    var remainingLength = currentSheet.Segments.Sum(x => x.Length);
                    if (remainingLength < job.SheetLength)
                        ig.DrawRectangle(Pens.Black, new Rectangle(xOrigin, yOrigin, remainingLength > Segment.KerfWidth ? remainingLength - Segment.KerfWidth : remainingLength, job.SheetWidth));

                    ig.DrawRectangle(Pens.Black, new Rectangle(0, yOrigin, job.SheetLength, job.SheetWidth));
                    
                    sheetImages.Add(mf);
                }
            }

            Bitmap bm = new Bitmap(job.SheetLength + 1, (job.SheetWidth + 20) * cutsheets.Count() + 1);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                for (int i = 0; i < sheetImages.Count; i++)
                {
                    int yOrigin = i * (job.SheetWidth + 20);
                    GraphicsUnit unit = GraphicsUnit.Pixel;
                    RectangleF source = sheetImages[i].GetBounds(ref unit);

                    PointF[] dest =
                    {
                        new PointF(0, yOrigin),
                        new PointF(source.Width, yOrigin),
                        new PointF(0, yOrigin + source.Height),
                    };
                    gr.DrawImage(sheetImages[i], dest, source, GraphicsUnit.Pixel);
                }
                
            }
            
                //ig.Save();
            pictureBox1.Image = bm;
            pictureBox1.Size = new Size(job.SheetLength + 1, (job.SheetWidth + 20) * cutsheets.Count() + 1);
            
            //var g = Graphics.FromImage(mf);
            //g.FillRectangle(Brushes.Gray, 0, 0, bm.Size.Width, bm.Size.Height);

            //g.DrawImage(job.SheetLength + 1, job.SheetWidth * cutsheets.Count() + (20 * cutsheets.Count() - 1) + 1)


        }
        private Metafile MakeMetafile(int width, int height)
        {
            using (Graphics gr = this.CreateGraphics())
            {
                Rectangle bounds =
                    new Rectangle(0, 0, width, height);

                Metafile mf = new Metafile(gr.GetHdc(), bounds,
                        MetafileFrameUnit.Pixel); ;
                
                gr.ReleaseHdc();
                return mf;
            }
        }
        private void RenderSegments(Graphics g, Segment segment, int xOrigin, int yOrigin, int recursionDepth = 0)
        {
            xOrigin += segment.KerfLeft;
            yOrigin += segment.KerfAbove;
            Font f = new Font(FontFamily.GenericSansSerif, 12f, FontStyle.Regular);

            //string[] fractions = { "", "¹/₁₆", "¹/₈", "³/₁₆", "¹/₄", "⁵/₁₆", "³/₈", "⁷/₁₆", "¹/₂", "⁹/₁₆", "⁵/₈", "¹¹/₁₆", "³/₄", "¹³/₁₆", "⁷/₈", "¹⁵/₁₆" };

            g.DrawRectangle(Pens.Black, new Rectangle(xOrigin, yOrigin, segment.Length, segment.Width));

            if (segment.AssignedUnit != null)
            {

                g.FillRectangle(new HatchBrush(segment.AssignedUnit.IsRotated ? HatchStyle.Vertical : HatchStyle.Horizontal, Color.LightGray, Color.White), new Rectangle(xOrigin, yOrigin, segment.AssignedUnit.Length, segment.AssignedUnit.Width));
                g.DrawRectangle(Pens.Black, new Rectangle(xOrigin, yOrigin, segment.AssignedUnit.Length, segment.AssignedUnit.Width));
                
                string nameString = segment.AssignedUnit.Name;
                var nameStringgSize = g.MeasureString(nameString, f);
                if (segment.AssignedUnit.IsRotated)
                {
                    g.DrawString(segment.AssignedUnit.Name, f, Brushes.Black,
                    (xOrigin + segment.AssignedUnit.Length / 2) - nameStringgSize.Height / 2,
                    (yOrigin + segment.AssignedUnit.Width / 2) - nameStringgSize.Width / 2, new StringFormat(StringFormatFlags.DirectionVertical));
                }
                else
                {
                    g.DrawString(segment.AssignedUnit.Name, f, Brushes.Black,
                        (xOrigin + segment.AssignedUnit.Length / 2) - nameStringgSize.Width / 2,
                        (yOrigin + segment.AssignedUnit.Width / 2) - nameStringgSize.Height / 2);
                }

                if (segment.Right != null)
                    RenderSegments(g, segment.Right, xOrigin + segment.AssignedUnit.Length, yOrigin, recursionDepth + 1);
                if(segment.Below != null)
                    RenderSegments(g, segment.Below, xOrigin, yOrigin + segment.AssignedUnit.Width, recursionDepth + 1);

                if (recursionDepth == 0 || segment.Length >= segment.AssignedUnit.Length)
                {
                    var hString = $"{segment.AssignedUnit.Length / 16} {ImperialDimension.Fractions[segment.AssignedUnit.Length % 16]}→";
                    var hStringSize = g.MeasureString(hString, f);
                    g.DrawString(hString, f, Brushes.Black, xOrigin + segment.AssignedUnit.Length - hStringSize.Width, yOrigin + 1);
                }


                if (recursionDepth == 0 || segment.Width >= segment.AssignedUnit.Width)
                {
                    var vString = $"↓{segment.AssignedUnit.Width/16} {ImperialDimension.Fractions[segment.AssignedUnit.Width % 16]}";
                    var vStringSize = g.MeasureString(vString, f);
                    g.DrawString(vString, f, Brushes.Black, xOrigin + 1, yOrigin + segment.AssignedUnit.Width - vStringSize.Height);
                }
            }         
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printImages = new Queue<Metafile>(sheetImages);
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += PrintPage;
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = pd;

            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            GraphicsUnit unit = GraphicsUnit.Pixel;
            var image = printImages.Dequeue();
            
            RectangleF source = image.GetBounds(ref unit);

            float sourceAspectRatio = source.Height / source.Width;
            float destinationApectRatio = e.MarginBounds.Height / (float)(e.MarginBounds.Width);
            PointF[] dest;

            if (sourceAspectRatio < destinationApectRatio)
            {
                dest = new PointF[]
                {
                    new PointF(e.MarginBounds.X , e.MarginBounds.Y + .5f*(e.MarginBounds.Height - e.MarginBounds.Width * sourceAspectRatio)),
                    new PointF(e.MarginBounds.Right, e.MarginBounds.Y + .5f*(e.MarginBounds.Height - e.MarginBounds.Width * sourceAspectRatio)),
                    new PointF(e.MarginBounds.X, e.MarginBounds.Y + e.MarginBounds.Width * sourceAspectRatio + .5f*(e.MarginBounds.Height - e.MarginBounds.Width * sourceAspectRatio)),
                };
            }
            else
            {
                dest = new PointF[]
                {
                    new PointF(e.MarginBounds.X + .5f*(e.MarginBounds.Width -  e.MarginBounds.Height / sourceAspectRatio), e.MarginBounds.Y),
                    new PointF(e.MarginBounds.X + e.MarginBounds.Height / sourceAspectRatio + .5f*(e.MarginBounds.Width -  e.MarginBounds.Height / sourceAspectRatio),  e.MarginBounds.Y),
                    new PointF(e.MarginBounds.X + .5f*(e.MarginBounds.Width -  e.MarginBounds.Height / sourceAspectRatio), e.MarginBounds.Bottom),
                };
            }


            e.Graphics.DrawImage(image, dest, source, GraphicsUnit.Pixel);
            e.HasMorePages = printImages.Count > 0;
        }

    }
}
