using System;
using System.Collections.Generic;
using System.Text;

namespace KalvinSquare_Abbyy.VATProdPostingGroup
{
    class VATProdPostingGroup_Item : ICloneable
    {
        public string timestamp { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Prod_Code_Part_TVA { get; set; }
        public string Prod_Code_Part_non_TVA { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
