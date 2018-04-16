using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class MenuContext
    {
        public MenuContext()
        {
            Menu = new List<MenuModel>();
        }
        public IList<MenuModel> Menu { get; set; }
    }
}
