using System;
using System.Diagnostics.CodeAnalysis;
using TechnineUzduotis.Classes.Enumerated;
using TechnineUzduotis.Classes.Other;
using TechnineUzduotis.Classes.Users;
using TechnineUzduotis.Classes.UserTypes;

namespace TechnineUzduotis
{
    [ExcludeFromCodeCoverage]
    public class Program : EnumClass
    {
        static void Main(string[] args)
        {
            ProviderInterface _interface = new ImplementedInterface();
            Provider Provider = new Provider(true, CountryList.Germany, _interface);
            Juridical Client = new Client(true, CountryList.Germany);

            Provider.SetVAT(Client, 100);
            Console.WriteLine(Client.VAT.ToString());
        }
    }
}
