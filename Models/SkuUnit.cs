using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dLayoutOptimizer
{
    public class SkuUnit
    {
        private bool _isRotated = false;
        private Sku _sku;

        private SkuUnit() { }
        public SkuUnit(Sku sku)
        {
            _sku = sku;
        }
        public Sku Sku { get { return _sku; } }
        public int Length
        {
            get { return _isRotated ? _sku.Width : _sku.Length; }
        }
        public int Width
        {
            get { return _isRotated ? _sku.Length : _sku.Width; }
        }
        public string Name
        {
            get { return _sku.Name; }
        }

        public bool CanRotate
        {
            get { return _sku.CanRotate; }
        }
        public bool IsRotated
        {
            get { return _isRotated; }
        }

        public void Rotate()
        {
            if (CanRotate)
                _isRotated = !_isRotated;

        }
        public SkuUnit Clone()
        {
            return this.MemberwiseClone() as SkuUnit;
        }
    }
}

