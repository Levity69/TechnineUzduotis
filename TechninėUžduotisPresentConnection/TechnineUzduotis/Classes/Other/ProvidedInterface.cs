using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechnineUzduotis.Classes.Enumerated.EnumClass;

namespace TechnineUzduotis.Classes.Other
{
    public interface ProviderInterface
    {
        public int CheckCountryVAT(CountryList Country);
        public bool CheckIfEuropean(CountryList ClientCountry);
    }
}
