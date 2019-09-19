using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateApp.DAL
{
    class DALSingleton
    {
        private static DALSingleton instance;

        private DALSingleton()
        {

        }

        public static DALSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DALSingleton();
                }
                return instance;
            }
        }

        public ICollection<Domain.RebateInfo> GetRebateInfo()
        {
            List<String> rebateRecords = ReadRebateRecordsFromFile().ToList();

            List<Domain.RebateInfo> rebateInfos = new List<Domain.RebateInfo>();


            if (!rebateRecords.Any())
            {
                return null;
            }
            else
            {
                foreach(String item in rebateRecords)
                {
                    String[] text = item.Split('\t');
                    //TODO: if the field is empty, what to do?
                    Domain.RebateInfo rebateInfoTemp = new Domain.RebateInfo();
                    rebateInfoTemp.Fname = text[0];
                    rebateInfoTemp.Minit = text[1];
                    rebateInfoTemp.Lname = text[2];
                    rebateInfoTemp.Addr1 = text[3];
                    rebateInfoTemp.Addr2 = text[4];
                    rebateInfoTemp.City = text[5];
                    rebateInfoTemp.State = text[6];
                    rebateInfoTemp.Zip = text[7];
                    rebateInfoTemp.Gender = text[8];
                    rebateInfoTemp.PhoneNum = text[9];
                    rebateInfoTemp.Email = text[10];
                    rebateInfoTemp.ProofPurchase = text[11];
                    rebateInfoTemp.DateRecieved = text[12];

                    rebateInfos.Add(rebateInfoTemp);
                }
            }

            return rebateInfos;
        }

        public ICollection<String> ReadRebateRecordsFromFile()
        {
            String currentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            String dataFilePath = currentDirectoryPath + "\\bin\\CS6326Asg2.txt";

            List<String> recordsText = null;

            try
            {
                recordsText = File.ReadAllLines(dataFilePath).ToList();
            }
            catch
            {
                File.Create(dataFilePath).Dispose();
            }

            return recordsText;
        }

    }
}
