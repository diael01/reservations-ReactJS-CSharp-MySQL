using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drapper;
using Contracts.Models;
using Contracts.Interfaces;

namespace Reservations.Repositories
{
    public class MenuItemsRepository : IMenuItems
    {
        IDbCommander dbCommander;
        public MenuItemsRepository(IDbCommander _dbC)
        {
            dbCommander = _dbC;
        }

        public IEnumerable<MenuItems> GetMenuItems()
        {
            return dbCommander.Query<MenuItems>();
        }
    }
}
