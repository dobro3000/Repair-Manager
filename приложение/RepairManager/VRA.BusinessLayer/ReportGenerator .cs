using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Threading;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VRA.Dto;
using System.Windows.Forms;

namespace VRA.BusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {
        public void fillExcelTableByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            try
            {
                if (grid != null)
                {
                    ExcelPackage pck = new ExcelPackage(xlsxFile);
                    var excel = pck.Workbook.Worksheets.Add(status);
                    int x = 1;
                    int y = 1;

                    CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    excel.Cells["A1:Z1"].Style.Font.Bold = true;
                    excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    excel.Cells.Style.Numberformat.Format = "General";

                    Object dtObj = new Object();

                    switch (status)
                    {
                        case "Country": dtObj = new CountryDto(); break;
                        case "Enterprise": dtObj = new EnterpriseDto(); break;
                        case "Repair": dtObj = new RepairDto(); break;
                        case "Machine": dtObj = new MachineDto(); break;
                        case "TypeMachine": dtObj = new TypeMachineDto(); break;
                        case "TypeRepair": dtObj = new TypeRepairDto(); break;
                    }
                    foreach (var prop in dtObj.GetType().GetProperties())
                    {
                        excel.Cells[y, x].Value = prop.Name.Trim();
                        x++;
                    }
                    foreach (var item in grid)
                    {
                        y++;
                        Object itemObj = item;
                        x = 1;
                        foreach (var prop in itemObj.GetType().GetProperties())
                        {
                            object t = prop.GetValue(itemObj, null);
                            object val;

                            if (t == null) val = "";
                            else
                            {
                                val = t.ToString();
                                if (t is CountryDto)
                                    val = ((CountryDto)t).NameCountry;

                                if (t is MachineDto)
                                    val = ((MachineDto)t).CodeMashine;

                                if (t is RepairDto)
                                    val = ((RepairDto)t).StartDate;

                                if (t is EnterpriseDto)
                                    val = ((EnterpriseDto)t).NameEnterprise;

                                if (t is TypeMachineDto)
                                    val = ((TypeMachineDto)t).CodeMachine;

                                if (t is TypeRepairDto)
                                    val = ((TypeRepairDto)t).NameRepair;

                                if (t is NameRepairDto)
                                    val = ((NameRepairDto)t).NameTypeRepair;
                            }
                            excel.Cells[y, x].Value = val;
                            x++;
                        }
                    }
                    excel.Cells.AutoFitColumns();
                    pck.Save();
                }
                else MessageBox.Show("Данные не загружены!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }


        public string genHtmlInfoRepairs(string rep)
        {
            List<object> works = ProcessFactory.InfoRepairDtoProcess().GetList().Cast<object>().ToList();
            string res_html = "<tr><td><b>Дата начала</b></td><td><b>Продолжительность</b></td><td><b>Стоимость</b></td><td><b>Название ремонта</b> </td><td><b>Примечание</b></td></tr>";

            double sum = 0;
            string cData = "";
            try
            {
                foreach (var work in works)
                {
                    InfoRepairDto WorkItem = (InfoRepairDto)work;
                    res_html += "<tr><td><p>" + WorkItem.StartDate + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Length + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Cost + "</p></td>";
                    res_html += "<td><p>" + WorkItem.NameRepairs + "</p></td>";
                    res_html += "<td><p>" + WorkItem.Note + "</p></td></tr>";

                    sum += Convert.ToDouble(WorkItem.Cost);
                    if (WorkItem.StartDate.ToString() != cData)
                    {
                        cData = WorkItem.StartDate.ToString();

                        res_html += "<tr><td colspan='5'><b>Итог: " + sum + "</b></td></tr>";
                        sum = 0;
                    }
                    else
                    {

                    }

                }
               
                res_html = rep.Replace("[VRA_TABLE_REPORT]", res_html);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }

            return res_html;
        }


    }
}
