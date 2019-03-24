using Katale_Server_Final.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Katale_Server_Final.Controllers
{
    [RoutePrefix("api/market")]
    public class MarketController : ApiController
    {

        IMarketService marketService = new MarketService();

        //Market Functions
        [HttpGet]
        [Route("markets/")]
        public List<Market> Markets()
        {
            return marketService.GetAll();
        }

        [HttpGet]
        [Route("market/{id}")]
        public Market Market(int id)
        {
            return marketService.GetSingle(id);
        }

        [HttpPost]
        [Route("markets/add")]
        public void AddMarket([FromBody]JObject ProductObject)
        {
            Address address = new Address.Builder()
                                       .SetEmail(ProductObject["Email"].ToString())
                                       .SetPhoneNumber(ProductObject["PhoneNumber"].ToString())
                                       .SetPrimaryAddress(ProductObject["PrimaryAddress"].ToString())
                                       .SetSecondaryAddress(ProductObject["SecondaryAddress"].ToString())
                                       .Build();

            Market market = new Market.Builder()
                                    .SetName(ProductObject["Name"].ToString())
                                    .SetDescription(ProductObject["Description"].ToString())
                                    .SetAddress(address)
                                    .Build();

            marketService.Save(market);
        }

        [HttpPost]
        [Route("market/{id}/edit")]
        public void EditMarket([FromBody]JObject ProductObject, int id)
        {
            Address address = new Address.Builder()
                                       .SetEmail(ProductObject["Email"].ToString())
                                       .SetPhoneNumber(ProductObject["PhoneNumber"].ToString())
                                       .SetPrimaryAddress(ProductObject["PrimaryAddress"].ToString())
                                       .SetSecondaryAddress(ProductObject["SecondaryAddress"].ToString())
                                       .Build();

            Market market = new Market.Builder()
                                    .SetName(ProductObject["Name"].ToString())
                                    .SetDescription(ProductObject["Description"].ToString())
                                    .SetAddress(address)
                                    .Build();

            market.ID = id;

            marketService.Update(market);
        }

        [HttpDelete]
        [Route("market/{id}/delete")]
        public void Delete(int id)
        {
            marketService.Delete(id);
        }
    }
}