using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateApp.BLL
{
    class BLLSingleton
    {
        private static BLLSingleton instance;

        private BLLSingleton()
        {

        }

        public static BLLSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLLSingleton();
                }
                return instance;
            }
        }


    }
}
