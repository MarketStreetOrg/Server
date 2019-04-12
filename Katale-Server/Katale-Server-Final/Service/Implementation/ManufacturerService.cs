using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Katale_Server_.Models;
using Katale_Server_Final.Database;
using Katale_Server_Final.Database.SQL.Implementation;

namespace Katale_Server_Final.Service.Implementation
{
    public class ManufacturerService : IManufacturerService
    {

        IGenericDAO<Manufacturer> ManufacturerDAO { get; set; }

        public ManufacturerService(IGenericDAO<Manufacturer> DataAccessObject)
        {
            this.ManufacturerDAO = DataAccessObject;
        }

        public ManufacturerService()
        {
            this.ManufacturerDAO = new ManufacturerSqlDAO();
        }

        public void Delete(int id)
        {
            ManufacturerDAO.Delete(id);
        }

        public List<Manufacturer> GetAll() => ManufacturerDAO.GetAll();
        
        public Manufacturer GetSingle(int id)
        {
            return ManufacturerDAO.GetByID(id);
        }

        public Manufacturer GetSingle(string Name)
        {
            return ManufacturerDAO.GetByName(Name);
        }

        public Manufacturer GetSingle(Manufacturer entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Manufacturer manufacturer)
        {
            ManufacturerDAO.Save(manufacturer);
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            ManufacturerDAO.Update(manufacturer);

            return ManufacturerDAO.GetByID(manufacturer.ID);
        }

        public bool Exists(Manufacturer t)
        {
            throw new NotImplementedException();
        }
    }
}