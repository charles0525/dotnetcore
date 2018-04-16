using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Models
{
    public class MenuModel
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int SortNumber { get; set; }
        public DateTime AddTime { get; set; }
    }
}
