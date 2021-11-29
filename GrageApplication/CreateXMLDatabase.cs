using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace xmltest
{
    internal class CreateXMLDatabase 
    {
        public string DatabaseFolderName;
        public string XmlSchemaName;
        public string XmlFileName;
        public string tabelName;
        public DataTable dt ;
        public CreateXMLDatabase(string DatabaseFolderName, string XmlSchemaName, string XmlFileName, DataTable dt)
        {
            this.DatabaseFolderName = DatabaseFolderName + "_Database";
            this.XmlSchemaName = XmlSchemaName + "_s.xml";
            this.XmlFileName = XmlFileName + ".xml";
            this.dt = dt;   
           


        }
     
        public void CreateTabel()
        {
           

            // adding columns 
            if (dt.Columns.Count < 1)
            {
                //dt.Columns.Add("number", typeof(int));
                dt.Columns.Add("RegNumber");
                dt.Columns.Add("Color");
                dt.Columns.Add("NumberOfWheels", typeof(int));
                dt.Columns.Add("PassengerCapacity", typeof(int));
                dt.Columns.Add("FuelType" );
                dt.Columns.Add("Manufacturer");
                dt.Columns.Add("ModelOfYear", typeof(int));

                //dt.Constraints.Add("num_pk", dt.Columns["number"], true);
                dt.Constraints.Add("reg_pk", dt.Columns["RegNumber"], true);
                //dt.Constraints.Add("color_pk", dt.Columns["Color"], true);
                //dt.Constraints.Add("model_pk", dt.Columns["ModelOfYear"], true);
                //dt.Constraints.Add("reg_pk", dt.Columns["RegNumber"], true);
            }

        }

        public void CreateDataBaseFolder()
        {
            if (!Directory.Exists(DatabaseFolderName)) Directory.CreateDirectory(DatabaseFolderName);
        }

        // Method checks if XML files Exists
        public bool CheckXmlFiles()
        {
            if (File.Exists(DatabaseFolderName + "/" + XmlSchemaName) && File.Exists(DatabaseFolderName + "/" + XmlFileName))
                return true;
            else return false;
        }

        // Method save data in xml file
        public void WriteXmlFiles()
        {
           
            CreateDataBaseFolder();
            CreateTabel();
            dt.WriteXmlSchema(DatabaseFolderName + "/" + XmlSchemaName);
            dt.WriteXml(DatabaseFolderName + "/" + XmlFileName);
        }

        // Method read data from xml file
        public void ReadXmlFiles()
        {
            
            if (CheckXmlFiles())
            {
                dt.ReadXmlSchema(DatabaseFolderName + "/" + XmlSchemaName);
                dt.ReadXml(DatabaseFolderName + "/" + XmlFileName);
            }
        }

        public void addRow( string regnr , string color, int numofwheels, int capacity, string fuel, string manfacture, int model)
        {
            
            dt.Rows.Add(regnr, color, numofwheels, capacity, fuel , manfacture, model);    
            WriteXmlFiles();
        }

        public void PrintAllData()
        {
            

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    Console.Write(dt.Rows[r][c] + ((c < dt.Columns.Count - 1) ? " ; " : ""));
                }
                Console.WriteLine();
            }
        }

        //public DataRow findrow<type>(type T)
        //{
        //    DataRow dr = dt.Rows.Find(T);
        //    return dr;
        //}



        //public DataRow findrow(int num)
        //{
        //    DataRow dr = dt.Rows.Find(num);
        //    return dr;
        //}



        public void SearchAny(DataTable dt)
        {
            this.dt = dt;
            DataTable tblSearch = new DataTable("Search");

            foreach (DataColumn col in dt.Columns)
                tblSearch.Columns.Add(col.ColumnName, col.DataType);

            //foreach(DataRow row in dt.Rows)
            //    tblSearch.Rows.Add(row);
            //    int filter = searchFilter();
            DataRow[] rows;
            //    if (filter == 1)
            //    {
            //        //Console.WriteLine("Enter the registration number to search");
            //        //string reg = Console.ReadLine();
            //        rows = tblSearch.Select();
            //    }
            rows = tblSearch.Select();
            foreach (DataRow row in rows)
                Console.WriteLine(row);
            //foreach (DataRow row in rows) tblSearch.ImportRow(row);
            //for (int r = 0; r < tblSearch.Rows.Count; r++)
            //{
            //    for (int c = 0; c < tblSearch.Columns.Count; c++)
            //    {
            //        Console.Write(tblSearch.Rows[r][c] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //    //Console.WriteLine(value);


            //================================test=============
            //for (int r = 0; r < dt.Rows.Count; r++)
            //{
            //    for (int c = 0; c < dt.Columns.Count; c++)
            //    {
            //        Console.Write(dt.Rows[r][c] + ((c < dt.Columns.Count - 1) ? " ; " : ""));
            //        //if (dt.Rows[r][c].ToString() == "ftj457")
            //        //    Console.Write(dt.Rows[r][c] + " ");
            //    }
            //    Console.WriteLine();
            //}

        }

    }
}
