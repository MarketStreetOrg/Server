using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.SQL.Implementation;
using Katale_Server_Final.Models;

namespace Katale_Server_Final.Service.Implementation
{
    public class MarketService : IMarketService
    {
        IGenericDAO<Market> MarketDAO { get; set; }

        public MarketService(IGenericDAO<Market> DataAccessObject)
        {
            this.MarketDAO = DataAccessObject;
        }

        public MarketService()
        {
            this.MarketDAO = new MarketSqlDAO();
        }

        public void Delete(int id)
        {
            MarketDAO.Delete(id);
        }

        public List<Market> GetAll()
        {
            return MarketDAO.GetAll();
        }

        public Market GetSingle(int id)
        {
            return MarketDAO.GetByID(id);
        }

        public Market GetSingle(string Name)
        {
            return MarketDAO.GetByName(Name);
        }

        public Market GetSingle(Market entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Market market)
        {
            MarketDAO.Save(market);
        }

        public Market Update(Market market)
        {
            MarketDAO.Update(market);

            return MarketDAO.GetByID(market.ID);
        }

        public bool Exists(Market market)
        {
            return MarketDAO.Exists(market);
        }
    }
}