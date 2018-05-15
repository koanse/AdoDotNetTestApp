using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ADO.NET_test
{
    public partial class Form1 : Form
    {
        WorkWithData wwd;
        public Form1()
        {
            InitializeComponent();
            wwd = new WorkWithData();
            wwd.Test1();
            dataGridView1.DataSource = wwd.myTable.Select("Make = 'Colt'");
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();
            da.
        }
    }

    public class WorkWithData
    {
        public DataTable myTable;
        public DataRow[] myDataRows;
        public void Test1()
        {
            myTable = new DataTable("MyTable");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.Int32");
            myDataColumn.ColumnName = "CarID";
            myDataColumn.ReadOnly = true;
            myDataColumn.AllowDBNull = false;
            myDataColumn.Unique = true;
            myDataColumn.AutoIncrement = true;
            myDataColumn.AutoIncrementSeed = 500;
            myDataColumn.AutoIncrementStep = 10;
            myTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Make";
            myTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Color";
            myTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "PetName";
            myDataColumn.AllowDBNull = true;
            myTable.Columns.Add(myDataColumn);

            DataColumn[] PK = new DataColumn[1];
            PK[0] = myTable.Columns["CarID"];
            myTable.PrimaryKey = PK;

            DataRow dr;
            dr = myTable.NewRow();
            dr["Make"] = "BMW";
            dr["Color"] = "Green";
            dr["PetName"] = "Chucky";
            myTable.Rows.Add(dr);

            dr = myTable.NewRow();
            dr["Make"] = "Yugo";
            dr["Color"] = "White";
            dr["PetName"] = "Tiny";
            myTable.Rows.Add(dr);

            dr = myTable.NewRow();
            dr["Make"] = "Jeep";
            dr["Color"] = "Tan";
            myTable.Rows.Add(dr);

            myDataRows = myTable.Select("CarID > 0");
            string message = "";
            for(int i = 0; i < myDataRows.Length; i++)
            {
                DataRow temp = myDataRows[i];
                message += temp["Make"] = "Colt";
                myDataRows[i] = temp;
            }
            MessageBox.Show(message, "Message");
        }
    }
}