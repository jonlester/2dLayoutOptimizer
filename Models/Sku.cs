using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class Sku
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Qty { get; set; }

        public string Name { get; set; }

        public bool CanRotate = false;
    }
}
