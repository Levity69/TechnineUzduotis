using NSubstitute;
using NUnit.Framework;
using TechnineUzduotis.Classes.Other;
using TechnineUzduotis.Classes.Users;
using TechnineUzduotis.Classes.UserTypes;
using static TechnineUzduotis.Classes.Enumerated.EnumClass;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, 100, 100)]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, -10, 0)]
        [TestCase(CountryList.Germany, CountryList.France, 19, 100, 100)]
        public void ProviderIsNotAVATPayer(CountryList ProviderCountry, CountryList ClientCountry, int countryVAT, double BeforeVAT, double AfterVAT)
        {
            ProviderInterface _providerInterface = Substitute.For<ProviderInterface>();
            _providerInterface.CheckCountryVAT(ClientCountry).Returns(countryVAT);
            _providerInterface.CheckIfEuropean(ClientCountry).Returns(true);

            Provider Provider = new Provider(false, ProviderCountry, _providerInterface);
            Juridical Client = new Client(true, ClientCountry);

            Provider.SetVAT(Client, BeforeVAT);

            Assert.AreEqual(AfterVAT,Client.VAT.SumAfter);
        }

        [Test]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, 100, 100)]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, -10, 0)]
        [TestCase(CountryList.Germany, CountryList.France, 19, 100, 100)]
        public void ClientIsOutsideOfEU(CountryList ProviderCountry, CountryList ClientCountry, int countryVAT, double BeforeVAT, double AfterVAT)
        {
            ProviderInterface _providerInterface = Substitute.For<ProviderInterface>();
            _providerInterface.CheckCountryVAT(ClientCountry).Returns(countryVAT);
            _providerInterface.CheckIfEuropean(ClientCountry).Returns(false);

            Provider Provider = new Provider(true, ProviderCountry,_providerInterface);
            Physical Client = new Client(true, ClientCountry);
            Provider.SetVAT(Client, BeforeVAT);

            Assert.AreEqual(AfterVAT,Client.VAT.SumAfter);
            Assert.AreEqual(0,Client.VAT.VATPercent);
        }

        [Test]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, 100, 121)]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, -10, 0)]
        [TestCase(CountryList.Germany, CountryList.France, 19, 100, 119)]
        public void ClientLivesInEUAndDoesntPayVAT(CountryList ProviderCountry, CountryList ClientCountry, int countryVAT, double BeforeVAT, double AfterVAT)
        {
            ProviderInterface _providerInterface = Substitute.For<ProviderInterface>();
            _providerInterface.CheckCountryVAT(ClientCountry).Returns(countryVAT);
            _providerInterface.CheckIfEuropean(ClientCountry).Returns(true);

            Provider Provider = new Provider(true, ProviderCountry,_providerInterface);
            Juridical Client = new Client(false, ClientCountry);
            Provider.SetVAT(Client, BeforeVAT);

            Assert.AreEqual(AfterVAT,Client.VAT.SumAfter);
            Assert.AreEqual((double)countryVAT / 100, Client.VAT.VATPercent);
        }

        [Test]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, 100, 100)]
        [TestCase(CountryList.Lithuania, CountryList.Poland, 21, -10, 0)]
        [TestCase(CountryList.Germany,   CountryList.France, 19, 100, 100)]
        public void ClientLivesInEUAndPaysVAT(CountryList ProviderCountry, CountryList ClientCountry, int countryVAT, double BeforeVAT, double AfterVAT)
        {
            ProviderInterface _providerInterface = Substitute.For<ProviderInterface>();
            _providerInterface.CheckCountryVAT(ClientCountry).Returns(countryVAT);
            _providerInterface.CheckIfEuropean(ClientCountry).Returns(true);

            Provider Provider = new Provider(true,ProviderCountry, _providerInterface);
            Physical Client = new Client(true, ClientCountry);
            Provider.SetVAT(Client, BeforeVAT);

            Assert.AreEqual(AfterVAT,Client.VAT.SumAfter);
            Assert.AreEqual(0,Client.VAT.VATPercent);
        }


        [Test]
        [TestCase(CountryList.Lithuania,21,100,121)]
        [TestCase(CountryList.Lithuania, 21, -20, 0)]
        [TestCase(CountryList.Germany,19,100,119)]
        public void ClientAndProviderLiveInEU(CountryList country,int countryVAT, double BeforeVAT, double AfterVAT)
        {
            ProviderInterface _providerInterface = Substitute.For<ProviderInterface>();
            _providerInterface.CheckCountryVAT(country).Returns(countryVAT);
            _providerInterface.CheckIfEuropean(country).Returns(true);

            Provider Provider = new Provider(true, country,_providerInterface);
            Juridical Client = new Client(true, country);
            
            Provider.SetVAT(Client, BeforeVAT);

            Assert.AreEqual(AfterVAT,Client.VAT.SumAfter);
            Assert.AreEqual((double)countryVAT/100, Client.VAT.VATPercent);
        }
}
}