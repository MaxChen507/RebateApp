﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateApp.BLL
{
    class BLLSingleton
    {
        // Instance Variable
        private static BLLSingleton instance;

        // Holds the current mode for this session
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

        public ICollection<Domain.RebateInfo> GetRebateInfoList()
        {
            if (DAL.DALSingleton.Instance.GetRebateInfo_FromFile() == null || !DAL.DALSingleton.Instance.GetRebateInfo_FromFile().Any())
            {
                return null;
            }
            else
            {
                List<Domain.RebateInfo> rebateInfos = DAL.DALSingleton.Instance.GetRebateInfo_FromFile().ToList();
                return rebateInfos;
            }

        }

        public Boolean CheckUnique(String fName, String lName, String phoneNum)
        {
            if(GetRebateInfoList() == null || !GetRebateInfoList().Any())
            {
                return true;
            }

            List<Domain.RebateInfo> rebateInfos = GetRebateInfoList().ToList();

            Boolean uniqueFlag = true;

            //Checks if theres any match in data
            if (rebateInfos.Any(record => record.Fname == fName && record.Lname == lName && record.PhoneNum == phoneNum))
            {
                uniqueFlag = false;
            }

            return uniqueFlag;
        }

        public void SaveRebateInfo(ICollection<Domain.RebateInfo> rebateInfos)
        {
            DAL.DALSingleton.Instance.SaveRebateInfo_ToFile(rebateInfos);
        }

    }
}
