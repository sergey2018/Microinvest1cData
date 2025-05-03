using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microinvest1cData.Data
{
    public class Groups
    {
        public int MId { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public String UUid
        {
            get;
            set;
        }
        public String PaerntUUid
        {
            get;
            set;
        }
    }
}
