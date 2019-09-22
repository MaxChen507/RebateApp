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
            List<String> rebateRecords = ReadRebateRecords_FromFile().ToList();

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

        private ICollection<String> ReadRebateRecords_FromFile()
        {
            String currentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            String dataFilePath = currentDirectoryPath + "\\bin\\CS6326Asg2.txt";

            //First clear all whitespace
            var lines = File.ReadAllLines(dataFilePath).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(dataFilePath, lines);

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

        public void SaveRebateInfo_ToFile(Domain.RebateInfo rebateInfo)
        {
            StringBuilder recordTxt = new StringBuilder();

            recordTxt.Append(rebateInfo.Fname + "\t");
            recordTxt.Append(rebateInfo.Minit + "\t");
            recordTxt.Append(rebateInfo.Lname + "\t");
            recordTxt.Append(rebateInfo.Addr1 + "\t");
            recordTxt.Append(rebateInfo.Addr2 + "\t");
            recordTxt.Append(rebateInfo.City + "\t");
            recordTxt.Append(rebateInfo.State + "\t");
            recordTxt.Append(rebateInfo.Zip + "\t");
            recordTxt.Append(rebateInfo.Gender + "\t");
            recordTxt.Append(rebateInfo.PhoneNum + "\t");
            recordTxt.Append(rebateInfo.Email + "\t");
            recordTxt.Append(rebateInfo.ProofPurchase + "\t");
            recordTxt.Append(rebateInfo.DateRecieved + "\n");

            WriteRebateInfo_ToFile(recordTxt.ToString());
        }

        private void WriteRebateInfo_ToFile(String recordsTxt)
        {
            String currentDirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            String dataFilePath = currentDirectoryPath + "\\bin\\CS6326Asg2.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(dataFilePath, true))
            {
                file.WriteLine(recordsTxt);
            }
        }

    }
}
