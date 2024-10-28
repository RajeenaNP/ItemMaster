using ItemMaster.Models.DataCarrier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.BusinessSevices.Contracts
{
    public interface IItemMasterService
    {
        Task<IEnumerable<ItemMasterEntity>> GetItems();

        Task<ItemMasterEntity> GetItemByID(int pItemID);

        Task InsertItem(ItemMasterEntity pItems);

        Task UpdateItem(ItemMasterEntity pItems);

        Task<bool> DeleteItem(int pItemID);
    }
}
