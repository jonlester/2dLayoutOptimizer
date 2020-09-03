using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class SkuViewModel
    {
        private EventHandler DataChanged;
        public Sku Sku { get; private set; }
        public SkuViewModel(Sku sku, EventHandler changedCallback = null)
        {
            this.Sku = sku;
            this.DataChanged = changedCallback;
        }
        public string Name
        {
            get { return Sku.Name; }
            set 
            { 
                if (Name != value)
                {
                    Sku.Name = value;
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public int Qty
        {
            get { return Sku.Qty; }
            set
            {
                if (Qty != value)
                {
                    Sku.Qty = value;
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public int WidthWholeNumber
        {
            get { return ImperialDimension.GetWholeNumber(Sku.Width); }
            set
            {
                if (WidthWholeNumber != value)
                {
                    Sku.Width = ImperialDimension.SetWholeNumber(Sku.Width, value);
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public int WidthFraction
        {
            get { return ImperialDimension.GetFraction(Sku.Width); }
            set
            {
                if (WidthFraction != value)
                {
                    Sku.Width = ImperialDimension.SetFraction(Sku.Width, value);
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public int LengthWholeNumber
        {
            get { return ImperialDimension.GetWholeNumber(Sku.Length); }
            set
            {
                if (LengthWholeNumber != value)
                {
                    Sku.Length = ImperialDimension.SetWholeNumber(Sku.Length, value);
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public int LengthFraction
        {
            get { return ImperialDimension.GetFraction(Sku.Length); }
            set
            {
                if (LengthFraction != value)
                {
                    Sku.Length = ImperialDimension.SetFraction(Sku.Length, value);
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public bool CanRotate
        {
            get { return Sku.CanRotate; }
            set
            {
                if (CanRotate != value)
                {
                    Sku.CanRotate = value;
                    DataChanged?.Invoke(this, new EventArgs());
                }
            }
        }
    }
    
}
