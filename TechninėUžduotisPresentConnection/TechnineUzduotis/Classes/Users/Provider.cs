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
    public class Provider : EnumClass
    {
        public bool IsVATPayer;
        public CountryList ProviderCountry;
        private readonly ProviderInterface _Interface;

        public Provider(bool isVATPayer, CountryList country, ProviderInterface _interface)
        {
            IsVATPayer = isVATPayer;
            ProviderCountry = country;
            _Interface = _interface;
        }

        public void SetVAT(Physical client, double Price)
        {
            VAT VAT = CreateVAT(Price, client.Country, client.IsVATPayer, "Physical");
            client.SetVAT(VAT);
        }

        public void SetVAT(Juridical client, double Price)
        {
            VAT VAT = CreateVAT(Price, client.Country, client.IsVATPayer, "Juridical");
            client.SetVAT(VAT);
        }

        public VAT CreateVAT(double Price, CountryList ClientCountry, bool clientIsVATPayer, string clientType)
        {
            if (Price < 0)
            {
                Price = 0;
            }

            double price = Price;
            double percent;

            // Provider is not a VAT Payer
            if (IsVATPayer == false)
            {
                VAT vat = new VAT(clientType, ClientCountry.ToString(), 0, Price, price);
                return vat;
            }
            // Client is outside of Europe
            else if (!_Interface.CheckIfEuropean(ClientCountry))
            {
                price = price - price * 0;
                VAT vat = new VAT(clientType, ClientCountry.ToString(), 0, Price, price);
                return vat;
            }
            // Client lives in Europe
            else
            {
                // Clinet and Provider live in the same country
                if (ClientCountry == ProviderCountry)
                {
                    percent = (double)_Interface.CheckCountryVAT(ClientCountry) / 100;
                    price = price + price * percent;

                    VAT vat = new VAT(clientType, ClientCountry.ToString(), percent, Price, price);
                    return vat;
                }
                // Client is not a VAT payer
                else if (clientIsVATPayer == false)
                {
                    percent = (double)_Interface.CheckCountryVAT(ClientCountry) / 100;
                    price = price + price * percent;

                    VAT vat = new VAT(clientType, ClientCountry.ToString(), percent, Price, price);
                    return vat;
                }
                // Client is a VAT payer
                else
                {
                    price = price - price * 0;

                    VAT vat = new VAT(clientType, ClientCountry.ToString(), 0, Price, price);
                    return vat;
                }
            }
        }
    }
}
