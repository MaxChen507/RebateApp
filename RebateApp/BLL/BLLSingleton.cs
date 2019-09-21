﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateApp.BLL
{
    class BLLSingleton
    {
        private static BLLSingleton instance;

        public String currentMode = Domain.CurrentMode.addMode;

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

        public ICollection<Domain.RebateInfo> GetRebateInfo()
        {
            List<Domain.RebateInfo> rebateInfos = DAL.DALSingleton.Instance.GetRebateInfo_FromFile().ToList();

            return rebateInfos;
        }

        public Boolean CheckUnique(String fName, String lName, String phoneNum)
        {
            List<Domain.RebateInfo> rebateInfos = GetRebateInfo().ToList();

            Boolean uniqueFlag = true;

            if (rebateInfos.Any(record => record.Fname == fName && record.Lname == lName && record.PhoneNum == phoneNum))
            {
                uniqueFlag = false;
            }

            return uniqueFlag;
        }

    }
}
