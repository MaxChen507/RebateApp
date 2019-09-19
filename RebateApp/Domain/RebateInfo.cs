using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateApp.Domain
{
    class RebateInfo
    {
        public String Fname { get; set; }
        public String Minit { get; set; }
        public String Lname { get; set; }
        public String Addr1 { get; set; }
        public String Addr2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Gender { get; set; }
        public String PhoneNum { get; set; }
        public String Email { get; set; }
        public String ProofPurchase { get; set; }
        public String DateRecieved { get; set; }

        public RebateInfo()
        {

        }
    }
}
