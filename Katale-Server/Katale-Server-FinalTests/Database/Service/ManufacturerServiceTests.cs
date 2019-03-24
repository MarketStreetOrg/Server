using System;
using Katale_Server_.Models;
using Katale_Server_Final.Models;
using Katale_Server_Final.Service;
using Katale_Server_Final.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katale_Server_FinalTests.Database.Service
{
    [TestClass]
    public class ManufacturerServiceTests
    {
        IManufacturerService manufacturerService = new ManufacturerService();

        [TestMethod]
        public void TestSaveManufacturer()
        {
            Address address = new Address.Builder()
                                       .SetEmail("Test Email")
                                       .SetPhoneNumber("Test PhoneNumber")
                                       .SetWorkNumber("Test Work number")
                                       .SetPrimaryAddress("Test Primary Address")
                                       .SetSecondaryAddress("Test secondary address")
                                       .Build();

            Manufacturer manufacturer = new Manufacturer.Builder()
                                                        .SetName("Test Manfacturer")
                                                        .SetLogo("Test Logo")
                                                        .SetAddress(address)
                                                        .Build();

            manufacturerService.Save(manufacturer);

        }

        [TestMethod]
        public void TestUpdateManufacturer()
        {
            Manufacturer manufacturer = manufacturerService.GetSingle(2);

            manufacturer.Address.Address1 = "Updated Address";

            manufacturerService.Update(manufacturer);
        }

        [TestMethod]
        public void TestGetAllManufacturers()
        {
            Assert.IsNotNull(manufacturerService.GetAll());
        }

        [TestMethod]
        public void TestGetSingleManufacturer()
        {
            Assert.IsNotNull(manufacturerService.GetSingle(2));
        }
    }
}
