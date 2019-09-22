using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RebateApp.Domain;

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

        public ICollection<Domain.RebateInfo> GetRebateInfo_FromFile()
        {
            List<String> rebateRecordsText = ReadRebateRecords_FromFile().ToList();

            //List to hold rebateInfos
            List<Domain.RebateInfo> rebateInfos = new List<Domain.RebateInfo>();
            
            //Checks if file is null
            if (!rebateRecordsText.Any())
            {
                return null;
            }
            else
            {
                foreach(String item in rebateRecordsText)
                {
                    //Parse text to rebateInfos
                    String[] text = item.Split('\t');
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

        private ICollection<String> ReadRebateRecords_FromFile()
        {
            //Sets the path and file name
            String currentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            String dataFilePath = currentDirectoryPath + "\\bin\\CS6326Asg2.txt";

            //First clear all whitespace
            var lines = File.ReadAllLines(dataFilePath).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(dataFilePath, lines);

            //List variable that holds text from file
            List<String> recordsText = null;

            //Reads text from file
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

        public void SaveRebateInfo_ToFile(ICollection<Domain.RebateInfo> rebateInfos)
        {
            //Sets the path and file name
            String currentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            String dataFilePath = currentDirectoryPath + "\\bin\\CS6326Asg2.txt";

            //String builder to hold new text to write over existing file
            StringBuilder rebateRecordsTxt = new StringBuilder();

            foreach(Domain.RebateInfo item in rebateInfos)
            {
                rebateRecordsTxt.Append(item.Fname + "\t");
                rebateRecordsTxt.Append(item.Minit + "\t");
                rebateRecordsTxt.Append(item.Lname + "\t");
                rebateRecordsTxt.Append(item.Addr1 + "\t");
                rebateRecordsTxt.Append(item.Addr2 + "\t");
                rebateRecordsTxt.Append(item.City + "\t");
                rebateRecordsTxt.Append(item.State + "\t");
                rebateRecordsTxt.Append(item.Zip + "\t");
                rebateRecordsTxt.Append(item.Gender + "\t");
                rebateRecordsTxt.Append(item.PhoneNum + "\t");
                rebateRecordsTxt.Append(item.Email + "\t");
                rebateRecordsTxt.Append(item.ProofPurchase + "\t");
                rebateRecordsTxt.Append(item.DateRecieved + "\n");
            }

            System.IO.File.WriteAllText(dataFilePath, rebateRecordsTxt.ToString());
        }

    }
}
