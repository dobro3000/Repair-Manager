using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.ObjectModel;
using VRA.Dto;
using VRA.BusinessLayer;
using System.Windows.Forms.DataVisualization.Charting;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ObservableCollection<ReportItemDto> collection = new ObservableCollection<ReportItemDto>();
        private readonly List<decimal> axisYDataSales = new List<decimal>();
        private readonly List<decimal> axisYDataPurchase = new List<decimal>();
        private readonly List<string> axisXData = new List<string>();

        public ReportWindow()
        {
            InitializeComponent();
            radioSales.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Т.к. все графики находятся в пределах области построения, создадим ее.
                chart.ChartAreas.Add(new ChartArea("Default"));

                // Добавим график, и назначим его в ранее созданную область «Default».
                chart.Series.Add(new Series("Кол-во ремонтов"));
                chart.Series["Кол-во ремонтов"].ChartArea = "Default";
                chart.Series.Add(new Series("Прибыль"));
                chart.Series["Прибыль"].ChartArea = "Default";

                // Определяем легенду.
                chart.Legends.Add(new Legend("Legend"));
                chart.Legends["Legend"].DockedToChartArea = "Default";
                chart.Series["Кол-во ремонтов"].Legend = "Legend";
                chart.Series["Прибыль"].Legend = "Legend";
                chart.Series["Прибыль"].IsVisibleInLegend = false;
                chart.Series["Кол-во ремонтов"].IsVisibleInLegend = false;


                // Загрузка данных по умолчанию.
                IList<RepairDto> repDto = ProcessFactory.GetRepairProcess().GetList();
                datePicker1.Text = repDto[0].StartDate.ToString();
                datePicker2.Text = repDto[repDto.Count -  1].StartDate.ToString();
                btn_accept_Click(sender, e);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            DateCompare();
            FillCollection();
            GraphType();
            DrawGraph();
        }
        private void DateCompare()
        {
            if ((Convert.ToDateTime(datePicker1.Text)) >= Convert.ToDateTime(datePicker2.Text))
            {
                MessageBox.Show("Дата окончания интервала запроса \n меньше либо равна дате начала");
            }
        }

        private void FillCollection()
        {
            try
            {

                axisYDataSales.Clear();
                axisYDataPurchase.Clear();
                // Если запрошена статистика по проданным.
                if (radioSales.IsChecked != null && radioSales.IsChecked.Value)
                {
                    if (radioDay.IsChecked != null && radioDay.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days > 30)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 30 дней ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddDays(30).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("day", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    if (radioMounth.IsChecked != null && radioMounth.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days / 30 > 12)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 12 месяцев ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddMonths(12).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("month", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days / (30 * 12) > 10)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 10 лет ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddYears(10).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("year", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    // Заполнение коллекции проданных.
                    foreach (var item in collection)
                    {
                        axisYDataSales.Add(item.price);
                    }
                }
                // Если запрошена статистика по купленным.
                if (radioPurchase.IsChecked != null && radioPurchase.IsChecked.Value)
                {
                    if (radioDay.IsChecked != null && radioDay.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days > 30)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 30 дней ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddDays(30).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("day", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    if (radioMounth.IsChecked != null && radioMounth.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days / 30 > 12)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 12 месяцев ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddMonths(12).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("month", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
                    {
                        TimeSpan ts =
                       (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                        if (ts.Days / (30 * 12) > 10)
                        {
                            MessageBox.Show(
                            "Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 10 лет ");
                            datePicker2.Text =
                           Convert.ToDateTime(datePicker1.Text).Date.AddYears(10).ToString();
                        }
                        collection.Clear();
                        collection = ProcessFactory.GetReportProcess()
                         .GetSaled("year", Convert.ToDateTime(datePicker1.Text),
                        Convert.ToDateTime(datePicker2.Text));
                    }
                    // Заполнение коллекции проданных.
                    foreach (var item in collection)
                    {
                        axisYDataSales.Add(item.price);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
        private void GraphType()
        {
            try
            {
                if (radioGist.IsChecked != null && radioGist.IsChecked.Value)
                {
                    // Определяем вид графиков.
                    chart.Series["Кол-во ремонтов"].ChartType = SeriesChartType.Column;
                    chart.Series["Прибыль"].ChartType = SeriesChartType.Column;
                }
                if (radioSpline.IsChecked != null && radioSpline.IsChecked.Value)
                {
                    // Определяем вид графиков.
                    chart.Series["Кол-во ремонтов"].ChartType = SeriesChartType.Line;
                    chart.Series["Прибыль"].ChartType = SeriesChartType.Line;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
        private void DrawGraph()
        {
            try
            {
                // Очищаем старые данные.
                axisXData.Clear();
                chart.Series["Кол-во ремонтов"].Points.Clear();
                chart.Series["Прибыль"].Points.Clear();
                // Добавляем подписи по оси X.
                foreach (var item in collection)
                {
                    axisXData.Add(item.date);
                }
                // Настраиваем легенду.
                if ((axisYDataSales.Count != 0) & (axisYDataPurchase.Count != 0))
                {
                    chart.Series["Кол-во ремонтов"].IsVisibleInLegend = true;
                    chart.Series["Прибыль"].IsVisibleInLegend = true;
                }
                else
                {
                    chart.Series["Кол-во ремонтов"].IsVisibleInLegend = false;
                    chart.Series["Прибыль"].IsVisibleInLegend = false;
                }
                // Строим графики.
                if (axisYDataSales.Count != 0)
                    chart.Series["Прибыль"].Points.DataBindXY(axisXData, axisYDataSales);
                if (axisYDataPurchase.Count != 0)
                    chart.Series["Кол-во ремонтов"].Points.DataBindXY(axisXData, axisYDataPurchase);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
        }
    }
}
