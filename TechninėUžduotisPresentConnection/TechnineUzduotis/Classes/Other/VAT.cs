using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnineUzduotis.Classes.Other
{
    public class VAT
    {
        public string Type;
        public string Country;
        public double VATPercent;
        public double SumBefore;
        public double SumAfter;

        public VAT(string type, string country, double vatPercent, double sumBefore, double sumAfter)
        {
            Type = type;
            Country = country;
            VATPercent = vatPercent;
            SumBefore = sumBefore;
            SumAfter = sumAfter;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return String.Format("Client Type {5,3}{0}\nClient Country {5}{1}" +
                "\nVAT {5,11}{2}\nSum Before VAT {5}{3}\nSum After VAT {5,1}{4}",
                "- " + Type, "- " + Country, "- " + VATPercent, "- " + SumBefore, "- " + SumAfter, "");
        }
    }
}
