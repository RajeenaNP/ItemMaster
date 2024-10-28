using ItemMaster.BusinessSevices.Contracts;
using ItemMaster.Models.DataCarrier;
using ItemMaster.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ItemMaster.ApiService.Controllers
{
    public class ItemMasterController : ApiController
    {
        private readonly IItemMasterService _itemMasterService;
        public ItemMasterController(IItemMasterService itemMasterService)
        {
            _itemMasterService = itemMasterService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetItems()
        {

            var result = await _itemMasterService.GetItems();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetItemByID(int pItemID)
        {

            var result = await _itemMasterService.GetItemByID(pItemID);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertItem(ItemMasterEntity pItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _itemMasterService.InsertItem(pItems);
            return Ok(new
            {
                Status = true,
                message = "Data updated Successfully",
            });
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateItem(ItemMasterEntity pItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _itemMasterService.UpdateItem(pItems);

            return Ok(new
            {
                Status = true,
                message = "Data updated Successfully",
            });

        }

        public async Task<IHttpActionResult> DeleteItem(int pItemID)
        {
            if (pItemID != null)
            {
                var result = await _itemMasterService.DeleteItem(pItemID);
                return Ok(new
                {
                    Status = result,
                    message = (result ? "Data deleted Successfully" : "No data deleted."),
                });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
