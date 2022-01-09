using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnineUzduotis.Classes.Enumerated;
using TechnineUzduotis.Classes.Other;
using TechnineUzduotis.Classes.UserTypes;

namespace TechnineUzduotis.Classes.Users
{
    public class Client : Physical, Juridical
    {
        private VAT vat;
        public VAT VAT
        {
            get { return vat; }
            set { vat = value; }
        }

        private bool isVATPayer;
        public bool IsVATPayer
        {
            get { return isVATPayer; }
            set { isVATPayer = value; }
        }

        private EnumClass.CountryList country;

        public EnumClass.CountryList Country
        {
            get { return country; }
            set { country = value; }
        }

        public Client(bool isVATPayer, EnumClass.CountryList country)
        {
            Country = country;
            IsVATPayer = isVATPayer;
        }

        public void SetVAT(VAT vat)
        {
            VAT = vat;
        }
    }
}
