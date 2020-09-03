using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class JobViewModel
    {
        public bool UnsavedChanges { get; set; }
        private Job Job { get; set; }
        public List<KeyValuePair<int, string>> Fractions { get; private set; }
        public BindingList<SkuViewModel> SkuViewModels { get; private set; }
        public JobViewModel(Job job)
        {
            this.Job = job;
            this.UnsavedChanges = false;
            this.Fractions = ImperialDimension.LargeFractions
                .Select((v, i) => new KeyValuePair<int, string>(i,v))
                .ToList<KeyValuePair<int, string>>();

            if (job.Skus == null || job.Skus.Count() == 0)
                job.Skus = new List<Sku>() { new Sku() };

            this.SkuViewModels = new BindingList<SkuViewModel>(job.Skus.Select(x => new SkuViewModel(x, DataChanged)).ToList());
        }

        public Job GetJob()
        {
            var emptySku = new Sku();
            Job.Skus = SkuViewModels
                .Select(x => x.Sku)
                .Where(x => x.GetHashCode() != emptySku.GetHashCode())
                .ToList();

            return Job;
        }

        public void DataChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        public string JobName
        {
            get { return Job.JobName; }
            set
            {
                if (JobName != value)
                {
                    Job.JobName = value;
                    DataChanged(null, null);
                }
            }
        }
        public int WidthWholeNumber
        {
            get { return ImperialDimension.GetWholeNumber(Job.SheetWidth); }
            set
            {
                if (WidthWholeNumber != value)
                {
                    Job.SheetWidth = ImperialDimension.SetWholeNumber(Job.SheetWidth, value);
                    DataChanged(null, null);
                }
            }
        }

        public int WidthFraction
        {
            get { return ImperialDimension.GetFraction(Job.SheetWidth); }
            set
            {
                if (WidthFraction != value)
                {
                    Job.SheetWidth = ImperialDimension.SetFraction(Job.SheetWidth, value);
                    DataChanged(null, null);
                }
            }
        }

        public int LengthWholeNumber
        {
            get { return ImperialDimension.GetWholeNumber(Job.SheetLength); }
            set
            {
                if (LengthWholeNumber != value)
                {
                    Job.SheetLength = ImperialDimension.SetWholeNumber(Job.SheetLength, value);
                    DataChanged(null, null);
                }
            }
        }

        public int LengthFraction
        {
            get { return ImperialDimension.GetFraction(Job.SheetLength); }
            set
            {
                if (LengthFraction != value)
                {
                    Job.SheetLength = ImperialDimension.SetFraction(Job.SheetLength, value);
                    DataChanged(null, null);
                }
            }
        }

        public int KerfWidthFraction
        {
            get { return ImperialDimension.GetFraction(Job.KerfWdith); }
            set
            {
                if (KerfWidthFraction != value)
                {
                    Job.KerfWdith = ImperialDimension.SetFraction(Job.KerfWdith, value);
                    DataChanged(null, null);
                }
            }
        }
    }
}
