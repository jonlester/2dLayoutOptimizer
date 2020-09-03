using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dLayoutOptimizer
{
    public class CutSheet
    {
        public int Width { get; set; }
        public int Length { get; set; }

        public List<Segment> Segments = new List<Segment>();

        public bool TryFitSegment(Segment segment)
        {
            bool canFit = (Length - Segments.Sum(x => x.Length) >= segment.Length + (Segments.Any() ? Segment.KerfWidth : 0));
            if (canFit)
                Segments.Add(segment);

            return canFit;
        }
    }
}
