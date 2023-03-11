using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;


namespace Systemy_Wspomagania_Decyzji
{
    internal class Tools
    {
        public static string[] columnHeaders;

        public static Object[][] loadTxt()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            string sFileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog.FileName;



                string[] delimiter = new string[] { "," };
                System.Data.DataTable fileData = new System.Data.DataTable();
                using (TextFieldParser pipeParser = new TextFieldParser(sFileName))
                {
                    pipeParser.SetDelimiters(delimiter);
                    pipeParser.HasFieldsEnclosedInQuotes = true;
                    columnHeaders = pipeParser.ReadFields();
                    foreach (string column in columnHeaders)
                    {
                        if (!string.IsNullOrEmpty(column))
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            fileData.Columns.Add(datecolumn);
                        }
                    }
                    while (!pipeParser.EndOfData)
                    {
                        string[] dataFields = pipeParser.ReadFields();
                        fileData.Rows.Add(dataFields);
                    }
                }

                List<string[]> ret = fileData.Rows.Cast<DataRow>().Select(row => fileData.Columns.Cast<DataColumn>()
               .Select(col => Convert.ToString(row[col]))
               .ToArray())
               .ToList();
                Object[][] list = new Object[ret.Count][];
                int i = 0;
                foreach (string[] str in ret)
                {
                    int j = 0;
                    list[i] = new Object[str.Length];
                    foreach (string s in str)
                    {

                        double m;
                        bool isDouble = double.TryParse(s, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out m);
                        if (isDouble)
                        {
                            list[i][j] = m;
                        }
                        else
                        {
                            DateTime d;
                            bool isDate = DateTime.TryParse(s, out d);
                            if (isDate)
                            {
                                list[i][j] = d;
                            }
                            else
                            {
                                list[i][j] = s;
                            }
                        }

                        j++;
                    }
                    i++;
                }

                return list;

            }
            throw new ApplicationException();
        }
        public static Object[][] loadFromExcel()
        {
            Microsoft.Office.Interop.Excel.Application App = new Microsoft.Office.Interop.Excel.Application();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FilterIndex = 1;
            string sFileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog.FileName;
                Workbook wb = App.Workbooks.Open(sFileName);
                Worksheet ws = wb.Worksheets[1];
                int nrCol = 1;
                for (; ; ) {
                    if (ws.Cells[1, nrCol].Value == null) break;
                    nrCol++;
                }
                var startCell = (Range)ws.Cells[1, 1];
                var endCell = (Range)ws.Cells[1, nrCol-1];
                var writeRange = ws.Range[startCell, endCell];
                Object[,] headers = writeRange.Value2;
                columnHeaders= new string[headers.Length];
                int j = 0;
                foreach (Object h in headers)
                {
                    columnHeaders[j] = h.ToString();
                    j++;
                }
                int nrRow = 1;
                for (; ; )
                {
                    if (ws.Cells[nrRow, 1].Value == null) break;
                    nrRow++;
                }
                var startCell2 = (Range)ws.Cells[2, 1];
                var endCell2 = (Range)ws.Cells[nrRow-1, nrCol - 1];
                var writeRange2 = ws.Range[startCell2, endCell2];
                Object[,] data = writeRange2.Value2;
                Object[][] data2= new Object[nrRow-2][];
                for (int it = 0; it<nrRow-2 ; it++) {
                    Object[] o = new Object[nrCol-1];
                    for (int jt = 0; jt < nrCol - 1; jt++)
                    {
                        o[jt] = data[it+1, jt+1];
                    }
                    data2[it] = o;
                }
                App.Quit();

                return data2;
            }
            throw new ApplicationException();
        }
        public static double standardDeviation(List<double> data) {
            double ar = arytmet(data);
            double sum = 0;
            foreach (double d in data)
            {
                sum += (ar - d) * (ar - d);
            }
            sum=sum/data.Count;
            return Math.Sqrt(sum);


        }
        public static double arytmet(List<double> data)
        {
            double sum = 0;
            foreach ( double d in data)
            {
                sum += d;
            }
            return sum/data.Count;
        }
        public static List<double> changeRange(List<double> data,double min,double max)
        {
            double minCurrent=double.MaxValue, maxCurrent=double.MinValue;
            foreach (double d in data)
            {
                if (d > maxCurrent) maxCurrent = d;
                if (d < minCurrent) minCurrent = d;
            }
            List<double> result = new List<double>();
            double diff = maxCurrent - minCurrent,newdiff= max-min;

            foreach (double d in data)
            {
                result.Add((d - minCurrent) / diff * newdiff + min);
            }
            return result;
            

        }
        public static void test()
        {
            
        }

    }
}
