using ItemMaster.Models.DataCarrier;
using ItemMaster.Models.DataModel;
using ItemMaster.Models.Domain;
using ItemMaster.Repository.Context;
using ItemMaster.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.Repository
{
    public class ItemMasterRepository : IItemMasterRepository
    {
        private readonly ItemMasterDbContext _dbContext;

        public ItemMasterRepository(ItemMasterDbContext pDbContext)
        {
            _dbContext = pDbContext;
        }

        public async Task<IEnumerable<ItemMasterModel>> GetItems()
        {
            try
            {
                var result = _dbContext.Items.ToList();
                var items = new List<ItemMasterModel>();
                if (result != null)
                {
                    items = result.Select(x => new ItemMasterModel
                    {
                        ID = x.ID,
                        Code = x.Code,
                        Name = x.Name,
                        Description = x.Description
                    }).ToList();
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ItemMasterModel> GetItemByID(int pItemID)
        {
            try
            {
                var result = _dbContext.Items.Where(x => x.ID == pItemID).FirstOrDefault();
                var items = new ItemMasterModel();

                if (result != null)
                {
                    items = new ItemMasterModel
                    {
                        ID = result.ID,
                        Code = result.Code,
                        Name = result.Name,
                        Description = result.Description
                    };
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertItem(ItemMasterModel pItems)
        {
            try
            {
                var item = new ItemMF
                {
                    Code = pItems.Code,
                    Name = pItems.Name,
                    Description = pItems.Description
                };
                _dbContext.Items.Add(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateItem(ItemMasterModel pItems)
        {
            try
            {
                var item = _dbContext.Items.Where(x => x.ID == pItems.ID).FirstOrDefault();
                if (item != null)
                {
                    item.Code = pItems.Code;
                    item.Name = pItems.Name;
                    item.Description = pItems.Description;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<bool> DeleteItem(int pItemID)
        {
            try
            {
                var item = _dbContext.Items.Where(x => x.ID == pItemID).FirstOrDefault();
                if (item != null)
                {
                    _dbContext.Items.Remove(item);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
