using CourseReportEmailer.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Data;

namespace CourseReportEmailer.Workers
{
    internal class EnrollmentDetailReportSpreadsheetCreator
    {
        public void Create(string filename, IList<EnrollmentDetailReport> enrollments)
        {
            using (var doc = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook))
            {
                // Convert JSON to DataTable.  Easier to work with DataTable when building the spreadsheet.
                string json = JsonConvert.SerializeObject(enrollments);
                var dt = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                // Create a workbook part.
                var wbpart = doc.AddWorkbookPart();
                wbpart.Workbook = new Workbook();

                // Create a worksheet part.
                var wspart = wbpart.AddNewPart<WorksheetPart>();

                // Create sheet data and add it to the worksheet.
                var sheetdata = new SheetData();
                wspart.Worksheet = new Worksheet(sheetdata);

                // Create a sheet list and add a sheet to it
                var sheetlist = doc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                var sheet = new Sheet()                       
                {
                    Id = doc.WorkbookPart.GetIdOfPart(wspart),  // Links sheet back to worksheet part.
                    SheetId = 1,
                    Name = "Report Sheet"
                };                
                sheetlist.Append(sheet);

                // Build the header row and add it to the sheetdata.
                var headerrow = new Row();                
                foreach (DataColumn col in dt.Columns)
                {
                    var cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(col.ColumnName);
                    headerrow.Append(cell);
                }
                sheetdata.Append(headerrow);

                // Build each data row and add it to the sheetdata.
                foreach (DataRow row in dt.Rows)
                {
                    var xrow = new Row();
                    foreach (DataColumn col in dt.Columns)
                    {
                        var cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(row[col.ColumnName].ToString());
                        xrow.Append(cell);
                    }
                    sheetdata.Append(xrow);
                }

                wbpart.Workbook.Save();
            }
        }
    }
}
