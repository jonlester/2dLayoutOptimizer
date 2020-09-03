using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class Solution
    {
        public List<Segment> Segments;
        public SkuUnit UnitPlaced;
        //public float Score()
        //{
        //    return Segments.Sum(x => x.UsedArea)/Segments.Sum(x => x.Length * x.Width);
        //}
        public int TotalLength()
        {
            return (Segments.Sum(x => x.Length));
        }
        public int WasteCount()
        {
            return (Segments.Sum(x => x.WasteCount()));
        }
        //public float score { get { return TotalLength(); } }
        //public float waste { get { return WasteCount(); } }

    }
}
