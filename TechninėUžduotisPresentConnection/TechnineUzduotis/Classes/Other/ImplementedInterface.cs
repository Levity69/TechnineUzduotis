using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TechnineUzduotis.Classes.Enumerated.EnumClass;

namespace TechnineUzduotis.Classes.Other
{
    [ExcludeFromCodeCoverage]
    class ImplementedInterface : ProviderInterface
    {
        public int CheckCountryVAT(CountryList Country)
        {
            string[] array = Enum.GetNames(typeof(European));
            Array arrayValues = Enum.GetValues(typeof(European));

            int index = 0;
            foreach (var european in array)
            {
                if (european.ToString() == Country.ToString())
                {
                    return (int)arrayValues.GetValue(index);
                }
                index++;
            }
            return -1;
        }

        public bool CheckIfEuropean(CountryList ClientCountry)
        {
            var array = Enum.GetNames(typeof(European));

            foreach (var European in array)
            {
                if (European.ToString() == ClientCountry.ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
