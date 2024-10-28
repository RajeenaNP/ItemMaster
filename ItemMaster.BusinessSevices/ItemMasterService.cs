using ItemMaster.BusinessSevices.Contracts;
using ItemMaster.Models.DataCarrier;
using ItemMaster.Models.DataModel;
using ItemMaster.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.BusinessSevices
{
    public class ItemMasterService : IItemMasterService
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        public ItemMasterService(IItemMasterRepository itemMasterRepository)
        {
            _itemMasterRepository = itemMasterRepository;
        }
        public async Task<IEnumerable<ItemMasterEntity>> GetItems()
        {
            try
            {
                var result = await _itemMasterRepository.GetItems();

                var items = result.Select(x => new ItemMasterEntity
                {
                    ID = x.ID,
                    Code = x.Code,
                    Name = x.Name,
                    Description = x.Description
                });

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ItemMasterEntity> GetItemByID(int pItemID)
        {
            try
            {
                var result = await _itemMasterRepository.GetItemByID(pItemID);

                var items = new ItemMasterEntity
                {
                    ID = result.ID,
                    Code = result.Code,
                    Name = result.Name,
                    Description = result.Description
                };

                return items;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task InsertItem(ItemMasterEntity pItems)
        {
            try
            {
                var Item = new ItemMasterModel
                {
                    ID = pItems.ID,
                    Code = pItems.Code,
                    Name = pItems.Name,
                    Description = pItems.Description
                };
                await _itemMasterRepository.InsertItem(Item);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task UpdateItem(ItemMasterEntity pItems)
        {
            try
            {
                var Item = new ItemMasterModel
                {
                    ID = pItems.ID,
                    Code = pItems.Code,
                    Name = pItems.Name,
                    Description = pItems.Description
                };
                await _itemMasterRepository.UpdateItem(Item);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<bool> DeleteItem(int pItemID)
        {
            try
            {
                return await _itemMasterRepository.DeleteItem(pItemID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
