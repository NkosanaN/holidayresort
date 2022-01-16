using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class DataHandler
    {
        public Utils Util { get; set; }
        public DataHandler(Utils util)
        {
            Util = util;
        }
    }
}
