using ItemMaster.Models.DataCarrier;
using ItemMaster.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.Repository.Contracts
{
    public interface IItemMasterRepository
    {
        Task<IEnumerable<ItemMasterModel>> GetItems();

        Task<ItemMasterModel> GetItemByID(int pItemID);

        Task InsertItem(ItemMasterModel pItems);

        Task UpdateItem(ItemMasterModel pItems);

        Task<bool> DeleteItem(int pItemID);
    }
}
