using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class Job
    {
        public Job()
        {
            Skus = new List<Sku>();
        }
        public string JobName { get; set; }
        public List<Sku> Skus { get; set; }

        public int SheetLength { get; set; }
        public int SheetWidth { get; set; }
        public int KerfWdith { get; set; }
    }
}
