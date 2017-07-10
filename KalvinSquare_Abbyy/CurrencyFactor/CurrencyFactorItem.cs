using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalvinSquare_Abbyy.CurrencyFactor
{
    public class CurrencyFactorItem : ICloneable
    {
        public string CurrencyCode { get; set; }
        public DateTime StartingDate { get; set; }
        public double ExchangeRate { get; set; }

        public CurrencyFactorItem()
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
