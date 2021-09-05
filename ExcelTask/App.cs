using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExcelTask
{
    internal class App
    {
        private static void Export(string file)
        {
            var personsList = new List<Person>
            {
                new Person("Nicholson", "Jack", 66, 2437612),
                new Person("Pacino", "Al", 46, 8761231),
                new Person("Hoffman", "Dustin", 54, 1009612),
                new Person("Hanks", "Tom", 72, 8911118),
                new Person("Cruise", "Tom", 26, 1234567),
                new Person("Freeman", "Morgan", 88, 9890612),
                new Person("Norton", "Edward", 51, 7773829),
                new Person("Smith", "Will", 49, 2981203),
                new Person("Diesel", "Vin", 26, 2008271),
                new Person("Damon", "Matt", 26, 4222123),
                new Person("Walker", "Paul", 40, 0980909)
            };

            using (var package = new ExcelPackage())
            {
                package.Workbook.Worksheets.Add("Persons");

                var sheet = package.Workbook.Worksheets["Persons"];
                sheet.Cells["A1"].LoadFromCollection(personsList, true);

                var totalRows = sheet.Dimension.End.Row;
                var totalColumns = sheet.Dimension.End.Column;

                var headerCells = sheet.Cells[1, 1, 1, totalColumns];
                var headerFont = headerCells.Style.Font;
                headerFont.SetFromFont(new Font("Times New Roman", 12, FontStyle.Bold));
                var headerFill = headerCells.Style.Fill;
                headerFill.PatternType = ExcelFillStyle.Solid;
                headerFill.BackgroundColor.SetColor(Color.Silver);

                var dataCells = sheet.Cells[2, 1, totalRows, totalColumns];
                var dataCellsFont = dataCells.Style.Font;
                dataCellsFont.SetFromFont(new Font("Times New Roman", 10, FontStyle.Italic));

                var allCells = sheet.Cells[1, 1, totalRows, totalColumns];
                allCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                allCells.AutoFitColumns();

                var cellsBorder = allCells.Style.Border;
                cellsBorder.Top.Style = ExcelBorderStyle.Thin;
                cellsBorder.Bottom.Style = ExcelBorderStyle.Thin;
                cellsBorder.Left.Style = ExcelBorderStyle.Thin;
                cellsBorder.Right.Style = ExcelBorderStyle.Thin;

                package.SaveAs(new FileInfo(file));
            }
        }

        private static void Main()
        {
            const string newExcelFile = @"persons.xlsx";

            try
            {
                Export(newExcelFile);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("The file was created successfully!");
        }
    }
}
