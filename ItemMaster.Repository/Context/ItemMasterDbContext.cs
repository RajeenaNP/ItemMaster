using ItemMaster.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMaster.Repository.Context
{
    public class ItemMasterDbContext : DbContext
    {
        static ItemMasterDbContext()
        {
            Database.SetInitializer<ItemMasterDbContext>(null);
        }
        public ItemMasterDbContext() : base(ConnectionStringManager.GetConnectionString())
        {
        }

        public DbSet<ItemMF> Items { get; set; }
    }
}
