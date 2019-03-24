using System;
using Katale_Server_Final.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.Service
{
    [TestClass]
    public class MarketServiceTests
    {
        IMarketService marketService = new MarketService();

        [TestMethod]
        public void TestGetAllMarkets()
        {
            Assert.IsNotNull(marketService.GetAll());

        }

        [TestMethod]
        public void TestSaveMarket()
        {
            Address address = new Address();
            address.Address1 = "First Address";
            address.Address2 = "Second Address";


            Market market = new Market.Builder()
                                      .SetName("Test Market")
                                      .SetDescription("This is my Test Market")
                                      .SetAddress(address)
                                      .Build();

            marketService.Save(market);
        }

        [TestMethod]
        public void TestGetSingleMarket()
        {
            Assert.IsNotNull(marketService.GetSingle(1));
            
        }

        [TestMethod]
        public void TestUpdateMarket()
        {
            Market market = marketService.GetSingle(1);
            market.Description = "This is my updated market";

            Assert.IsNotNull(marketService.Update(market));
        }
    }
}
