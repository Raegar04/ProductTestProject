using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Helpers
{
    public static class HtmlTableExtension
    {
        private static List<TableRow> ReadTable(this IWebElement table)
        {
            var rows = table.FindElements(By.TagName("tr")).Skip(1);
            var columns = table.FindElements(By.TagName("th")).Select(element => element.Text).ToList();

            var tableRows = new List<TableRow>();

            var rowIndex = 0;
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                var cellsData = new List<CellData>();

                for (int i = 0; i < cells.Count; i++)
                {
                    var cell = cells[i];
                    var links = cell.FindElements(By.TagName("a"));

                    cellsData?.Add(new CellData()
                    {
                        Text = cell.Text,
                        ColumnName = columns[i],
                        Elements = links
                    });
                }

                tableRows.Add(new TableRow()
                {
                    Index = rowIndex,
                    Data = cellsData
                });

                rowIndex++;
            }

            return tableRows;
        }

        private static void PerformACtionOnRow(this TableRow row, OperationType operationType)
        {
            var actions = row.Data.FirstOrDefault(x => x.Elements != null && x.Elements.Count == 3).Elements;
            actions.FirstOrDefault(action => action.Text == operationType.ToString()).Click();
        }

        public static void PerformAction(this IWebElement table, OperationType operationType, string columnName, string value)
        {
            var tableRows = ReadTable(table);
            var row = tableRows.FirstOrDefault(x => x.Data.Any(y => y.ColumnName == columnName && y.Text == value));
            row.PerformACtionOnRow(operationType);
        }
    }

    public class TableRow
    {
        public int Index { get; set; }

        public ICollection<CellData>? Data { get; set; } = new List<CellData>();
    }

    public class CellData
    {
        public string? Text { get; set; }

        public string ColumnName { get; set; }

        public ICollection<IWebElement>? Elements { get; set; }
    }

    public enum OperationType
    {
        Details,
        Edit,
        Delete
    }
}
