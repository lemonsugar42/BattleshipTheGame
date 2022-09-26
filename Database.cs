using System;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace ExcelApp
{
    public static class Excel
    {
        private static Application _excelApp;
        private static Worksheet _excelSheet;
        private const int A = 1;
        private const int B = 2;
        private const int Bestest = 10;
        public static Application ExcelApp()
        {
            _excelApp = new Application();
            if (_excelApp == null) throw new Exception("Excel is not installed");
            else
            {
                return _excelApp;
            }
        }
        private static bool Launch()
        {
            bool first;
            string curdir = Environment.CurrentDirectory;
            var dir = Directory.GetParent(Directory.GetParent(@curdir).ToString());
            try
            {
                ExcelApp().Workbooks.Open($@"{dir}\Database\Records.xlsx", Editable: true);
                first = false;
            }
            catch
            {
                Directory.CreateDirectory($@"{dir}\Database");
                _excelApp.Workbooks.Add();
                _excelApp.ActiveWorkbook.SaveAs($@"{dir}\Database\Records.xlsx");
                first = true;
            }
            return first;
        }
        private static void Sort(int rows)
        {
            Range records = _excelSheet.Range[_excelSheet.Cells[1, A], _excelSheet.Cells[rows, B]];
            records.Sort(records.Columns[B], XlSortOrder.xlDescending, records.Columns[A], Type.Missing, XlSortOrder.xlAscending);
        }
        public static void Update(string name, string score)
        {
            bool first = Launch();
            _excelSheet = _excelApp.ActiveWorkbook.Sheets[1];
            int id = 1;
            if (!first)
            {
                id = _excelSheet.UsedRange.Rows.Count + 1;
            }
            _excelSheet.Cells[id, A] = name;
            _excelSheet.Cells[id, B] = score;
            Sort(id);
            _excelApp.ActiveWorkbook.Save();
        }
        public static void Show(string name, string score, out string[] usernames, out string[] scores)
        {
            Update(name, score);
            usernames = new string[Bestest];
            scores = new string[Bestest];
            int i = 0;
            while (i < usernames.Length)
            {
                try
                {
                    usernames[i] = _excelSheet.Cells[i + 1, A].Value2.ToString() + "\n";
                    scores[i] = _excelSheet.Cells[i + 1, B].Value2.ToString() + "\n";
                }
                catch
                {
                    usernames[i] = scores[i] = "---\n";
                }
                finally
                {
                    i++;
                }
            }
            _excelApp.ActiveWorkbook.Close();
        }
    }
}
