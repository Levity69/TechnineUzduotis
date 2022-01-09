using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnineUzduotis.Classes.Enumerated;
using TechnineUzduotis.Classes.Other;

namespace TechnineUzduotis.Classes.UserTypes
{
    public interface Physical
    {
        public void SetVAT(VAT vat);
        VAT VAT { get; set; }
        bool IsVATPayer { get; set; }
        EnumClass.CountryList Country { get; set; }
    }
}
