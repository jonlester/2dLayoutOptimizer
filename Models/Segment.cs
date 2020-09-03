using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class Segment
    {
        public static int KerfWidth { get; set; }
        public int KerfLeft
        {
            get; set; 
        }
        public int KerfAbove = 0;

        public SkuUnit AssignedUnit { get; set; }
        public Segment Right { get; set; }
        public Segment Below { get; set; }

        //public Segment Parent { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        private bool CanFitSkuUnit(SkuUnit skuUnit)
        {
            return (AssignedUnit == null 
                && Right == null 
                && Below == null 
                && Width >= skuUnit.Width + KerfAbove
                && Length >= skuUnit.Length + KerfLeft);
        }
        private bool CanFitSkuUnitRotated(SkuUnit skuUnit)
        {
            return (skuUnit.CanRotate 
                && AssignedUnit == null
                && Right == null
                && Below == null
                && Width >= skuUnit.Length + KerfAbove
                && Length >= skuUnit.Width + KerfAbove);
        }

        public bool TryFitSkuUnit(SkuUnit skuUnit, bool canRotate = true)
        {
            bool fitFound = false;
            if (CanFitSkuUnit(skuUnit))
            {
                fitFound = true;
            }
            else if (canRotate && CanFitSkuUnitRotated(skuUnit))
            {
                skuUnit.Rotate();
                fitFound = true;
            }
            if(fitFound)
            {
                AssignedUnit = skuUnit;
                //see if one dimension is a perfect fit, or if an additional split is required
                if (skuUnit.Length < this.Length + KerfWidth)
                    Right = new Segment() { Length = this.Length - skuUnit.Length - KerfWidth, Width = skuUnit.Width, KerfLeft = KerfWidth };
                if (skuUnit.Width < this.Width + KerfWidth)
                    Below = new Segment() { Length = this.Length, Width = this.Width - skuUnit.Width - KerfWidth, KerfAbove = KerfWidth };
            }
            else
            {
                fitFound = ((Right != null && Right.TryFitSkuUnit(skuUnit)) || (Below != null && Below.TryFitSkuUnit(skuUnit)));
            }
            return fitFound;
        }
        public int ChildCount()
        {
            int count = 1;
            if (Right != null)
                count += Right.ChildCount();
            if (Below != null)
                count += Below.ChildCount();
            return count;
        }
        public int WasteCount()
        {
            int count = 0;
            if (AssignedUnit == null)
                count = 1;
            if (Right != null)
                count += Right.WasteCount();
            if (Below != null)
                count += Below.WasteCount();
            return count;
        }
        public Segment Clone()
        {
            Segment segment = this.MemberwiseClone() as Segment;
            if (AssignedUnit != null)
                segment.AssignedUnit = AssignedUnit.Clone();
            if (Right != null)
                segment.Right = Right.Clone();
            if (Below != null)
                segment.Below = Below.Clone();
            return segment;
        }
        
        public int UsedArea
        {
            get
            {
                int area = 0;
                if (this.Right != null)
                    area += this.Right.UsedArea;
                if (this.Below != null)
                    area += this.Below.UsedArea;
                if (this.AssignedUnit != null)
                    area += this.AssignedUnit.Length * this.AssignedUnit.Width;
                return area;
            }
        }
    }
}
