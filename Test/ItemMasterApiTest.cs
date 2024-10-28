using ItemMaster.ApiService.Controllers;
using ItemMaster.BusinessSevices.Contracts;
using ItemMaster.Models.DataCarrier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ItemMasterApiTest
    {
        private Mock<IItemMasterService> _mockItemService;
        private ItemMasterController _itemController;

        [TestInitialize]
        public void Setup()
        {
            _mockItemService = new Mock<IItemMasterService>();
            _itemController = new ItemMasterController(_mockItemService.Object);
        }

        [TestMethod]
        public async Task InsertItem_ShouldReturnOk_WhenItemIsValid()
        {
            var newItem = new ItemMasterEntity { ID = 1, Code = "001", Name = "Item 1", Description = "Item Description" };

            var result = await _itemController.InsertItem(newItem);

            _mockItemService.Verify(service => service.InsertItem(newItem), Times.Once);
        }
    }
}
