using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.BusinessLayer;
using VRA.Dto;
using System.IO;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private string status; //Устанавливает, с какой таблицей в текущий момент работает пользователь 

        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btnCountry_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }
            this.dgCountry.Visibility = Visibility.Visible;
            status = "Country";
            this.btnUpdateC_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Страна";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Collapsed;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Collapsed;
        }

        private void btnEnterprise_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }

            this.dgEnterprise.Visibility = Visibility.Visible;
            status = "Enterprise";
            this.btnUpdateE_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Предприятия";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Collapsed;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Collapsed;
        }

        private void btnRepair_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }

            this.dgRepair.Visibility = Visibility.Visible;
            status = "Repair";
            this.btnUpdateR_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Ремонт";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Collapsed;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Visible;
        }

        private void btnMachine_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }

            this.dgMachine.Visibility = Visibility.Visible;
            status = "Machine";
            this.btnUpdateM_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Станок";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Visible;
        }

        private void btnTypeRepair_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }

            this.dgTypeRepair.Visibility = Visibility.Visible;
            status = "TypeRepair";
            this.btnUpdatetR_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Вид ремонта";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Collapsed;
            
        }

        private void btnTypeMachine_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.dgCountry.Visibility = Visibility.Hidden; break;
                case "Enterprise": this.dgEnterprise.Visibility = Visibility.Hidden; break;
                case "Repair": this.dgRepair.Visibility = Visibility.Hidden; break;
                case "Machine": this.dgMachine.Visibility = Visibility.Hidden; break;
                case "TypeMachine": this.dgTypeMachine.Visibility = Visibility.Hidden; break;
                case "TypeRepair": this.dgTypeRepair.Visibility = Visibility.Hidden; break;
            }

            this.dgTypeMachine.Visibility = Visibility.Visible;
            status = "TypeMachine";
            this.btnUpdatetM_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Тип машины";
            this.btnAdd.Visibility = Visibility.Visible;

            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnUpdate.Visibility = Visibility.Visible;
            this.btnShearc.Visibility = Visibility.Visible;
        }

        private void btnTypeShearc_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow(status);
            {
                switch (status)
                {
                    case "Repair":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgRepair.ItemsSource = search.FindedRepair;
                        }
                        break;
                    case "Machine":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgMachine.ItemsSource = search.FindedMachine;
                        }
                        break;
                    case "TypeMachine":
                        search.ShowDialog();
                        if (search.exec)
                        {
                            this.dgTypeMachine.ItemsSource = search.FindedTypeMachine;
                        }
                        break;

                    default: MessageBox.Show("Для поиска необходимо выбрать таблицу!"); break;
                }
            }
        }

        #region Add_btn

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.btnAddC_Click(sender, e); break;
                case "Enterprise": this.btnAddE_Click(sender, e); break;
                case "Repair": this.btnAddR_Click(sender, e); break;
                case "Machine": this.btnAddM_Click(sender, e); break;
                case "TypeMachine": this.btnAddtM_Click(sender, e); break;
                case "TypeRepair": this.btnAddtR_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!"); return;
            }
        }

        private void btnAddC_Click(object sender, RoutedEventArgs e)
        {
            WinCountry window = new WinCountry();
            window.ShowDialog();

            dgCountry.ItemsSource = ProcessFactory.GetCountryProcess().GetList();
        }

        private void btnAddE_Click(object sender, RoutedEventArgs e)
        {
            WinEnterprise window = new WinEnterprise();
            window.ShowDialog();

            dgEnterprise.ItemsSource = ProcessFactory.GetEnterpriseProcess().GetList();
        }

        private void btnAddR_Click(object sender, RoutedEventArgs e)
        {
            WinAddRepair window = new WinAddRepair();
            window.ShowDialog();

            dgRepair.ItemsSource = ProcessFactory.GetRepairProcess().GetList();
        }

        private void btnAddM_Click(object sender, RoutedEventArgs e)
        {
            WinMachine window = new WinMachine();
            window.ShowDialog();

            dgMachine.ItemsSource = ProcessFactory.GetMachinerProcess().GetList();
        }

        private void btnAddtM_Click(object sender, RoutedEventArgs e)
        {
            WinTypeMach window = new WinTypeMach(); window.ShowDialog();

            dgTypeMachine.ItemsSource = ProcessFactory.GetTypeMachinProcess().GetList();
        }

        private void btnAddtR_Click(object sender, RoutedEventArgs e)
        {
            WinRepairxaml window = new WinRepairxaml();
            window.ShowDialog();

            dgTypeRepair.ItemsSource = ProcessFactory.GetTypeRepairProcess().GetList();
        }

        #endregion

        #region Edit_btn

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.btnEditC_Click(sender, e); break;
                case "Enterprise": this.btnEditE_Click(sender, e); break;
                case "Repair": this.btnEditR_Click(sender, e); break;
                case "Machine": this.btnEditM_Click(sender, e); break;
                case "TypeMachine": this.btnEdittM_Click(sender, e); break;
                case "TypeRepair": this.btnEdittR_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!"); return;
            }
        }

        private void btnEditC_Click(object sender, RoutedEventArgs e)
        {
            CountryDto item = dgCountry.SelectedItem as CountryDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinCountry window = new WinCountry();
            window.Load(item);
            window.ShowDialog();
            btnUpdateC_Click(sender, e);
        }

        private void btnEditE_Click(object sender, RoutedEventArgs e)
        {
            EnterpriseDto item = dgEnterprise.SelectedItem as EnterpriseDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinEnterprise window = new WinEnterprise();
            window.Load(item);
            window.ShowDialog();
            btnUpdateE_Click(sender, e);
        }

        private void btnEditR_Click(object sender, RoutedEventArgs e)
        {
            RepairDto item = dgRepair.SelectedItem as RepairDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinAddRepair window = new WinAddRepair();
            window.Load(item);
            window.ShowDialog();
            btnUpdateR_Click(sender, e);
        }

        private void btnEditM_Click(object sender, RoutedEventArgs e)
        {
            MachineDto item = dgMachine.SelectedItem as MachineDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinMachine window = new WinMachine();
            window.Load(item);
            window.ShowDialog();
            btnUpdateM_Click(sender, e);
        }

        private void btnEdittM_Click(object sender, RoutedEventArgs e)
        {
            TypeMachineDto item = dgTypeMachine.SelectedItem as TypeMachineDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinTypeMach window = new WinTypeMach();
            window.Load(item);
            window.ShowDialog();
            btnUpdatetM_Click(sender, e);
        }

        private void btnEdittR_Click(object sender, RoutedEventArgs e)
        {
            TypeRepairDto item = dgTypeRepair.SelectedItem as TypeRepairDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }

            WinRepairxaml window = new WinRepairxaml();
            window.Load(item);
            window.ShowDialog();
            btnUpdatetR_Click(sender, e);
        }

        #endregion

        #region Delete_btn

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.btnDeleteC_Click(sender, e); break;
                case "Enterprise": this.btnDeleteE_Click(sender, e); break;
                case "Repair": this.btnDeleteR_Click(sender, e); break;
                case "Machine": this.btnDeleteM_Click(sender, e); break;
                case "TypeMachine": this.btnDeletetM_Click(sender, e); break;
                case "TypeRepair": this.btnDeletetR_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!"); return;
            }
        }

        private void btnDeleteC_Click(object sender, RoutedEventArgs e)
        {
            CountryDto item = dgCountry.SelectedItem as CountryDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление страны");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.NameCountry + "?", "Удаление страны", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetCountryProcess().Delete(item.IDCountry);

            btnUpdateC_Click(sender, e);
        }

        private void btnDeleteE_Click(object sender, RoutedEventArgs e)
        {
            EnterpriseDto item = dgEnterprise.SelectedItem as EnterpriseDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление предприятия");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.NameEnterprise + "?", "Удаление предприятия", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetEnterpriseProcess().Delete(item.IDEnterprise);

            btnUpdateE_Click(sender, e);
        }

        private void btnDeleteR_Click(object sender, RoutedEventArgs e)
        {
            RepairDto item = dgRepair.SelectedItem as RepairDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление ремонта");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить ремонт от " + item.StartDate + ", для станка " + item.CodeMachine + "?", "Удаление ремонта", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetRepairProcess().Delete(item.StartDate, item.CodeMachine);

            btnUpdateR_Click(sender, e);
        }

        private void btnDeleteM_Click(object sender, RoutedEventArgs e)
        {
            MachineDto item = dgMachine.SelectedItem as MachineDto;
            
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление станка");
                return;
            }
            
            MessageBoxResult result = MessageBox.Show("Удалить станок " + item.CodeMashine + "?", "Удаление станка", MessageBoxButton.YesNo, MessageBoxImage.Warning);
 
            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetMachinerProcess().Delete(item.CodeMashine);
            
            btnUpdateM_Click(sender, e);
        }

        private void btnDeletetM_Click(object sender, RoutedEventArgs e)
        {
            TypeMachineDto item = dgTypeMachine.SelectedItem as TypeMachineDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление вида станка");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить " + item.CodeMachine + "?", "Удаление вида станка", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetTypeMachinProcess().Delete(item.CodeMachine);

            btnUpdatetM_Click(sender, e);
        }

        private void btnDeletetR_Click(object sender, RoutedEventArgs e)
        {
            TypeRepairDto item = dgTypeRepair.SelectedItem as TypeRepairDto;

            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление вида ремонта");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить ремонт" + item.NameRepair + "?", "Удаление виа ремонта", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            ProcessFactory.GetTypeRepairProcess().Delete(item.IDRepair);

            btnUpdatetR_Click(sender, e);
        }

        #endregion'

        #region Update_btn

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "Country": this.btnUpdateC_Click(sender, e); break;
                case "Enterprise": this.btnUpdateE_Click(sender, e); break;
                case "Repair": this.btnUpdateR_Click(sender, e); break;
                case "Machine": this.btnUpdateM_Click(sender, e); break;
                case "TypeMachine": this.btnUpdatetM_Click(sender, e); break;
                case "TypeRepair": this.btnUpdatetR_Click(sender, e); break;
                default: MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!"); return;
            }
        }

        private void btnUpdateC_Click(object sender, RoutedEventArgs e)
        {
            dgCountry.ItemsSource = ProcessFactory.GetCountryProcess().GetList();
        }

        private void btnUpdateE_Click(object sender, RoutedEventArgs e)
        {
            dgEnterprise.ItemsSource = ProcessFactory.GetEnterpriseProcess().GetList();
        }

        private void btnUpdateR_Click(object sender, RoutedEventArgs e)
        {
            dgRepair.ItemsSource = ProcessFactory.GetRepairProcess().GetList();
        }

        private void btnUpdateM_Click(object sender, RoutedEventArgs e)
        {
            dgMachine.ItemsSource = ProcessFactory.GetMachinerProcess().GetList();
        }

        private void btnUpdatetM_Click(object sender, RoutedEventArgs e)
        {
            dgTypeMachine.ItemsSource = ProcessFactory.GetTypeMachinProcess().GetList();
        }

        private void btnUpdatetR_Click(object sender, RoutedEventArgs e)
        {
            dgTypeRepair.ItemsSource = ProcessFactory.GetTypeRepairProcess().GetList();
        }

        #endregion

        private void ExсelExporterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<object> grid = null;

                switch (status)
                {
                    case "Country": grid = this.dgCountry.ItemsSource.Cast<object>().ToList(); break;
                    case "Enterprise": grid = this.dgEnterprise.ItemsSource.Cast<object>().ToList(); break;
                    case "Repair": grid = this.dgRepair.ItemsSource.Cast<object>().ToList(); break;
                    case "Machine": grid = this.dgMachine.ItemsSource.Cast<object>().ToList(); break;
                    case "TypeMachine": grid = this.dgTypeMachine.ItemsSource.Cast<object>().ToList(); break;
                    case "TypeRepair": grid = this.dgTypeRepair.ItemsSource.Cast<object>().ToList(); break;
                }

                System.Windows.Forms.SaveFileDialog saveXlsxDialog = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".xlsx",
                    Filter = "Excel Files(.xlsx) | *.xlsx",
                    AddExtension = true,
                    FileName = status
                };

                bool? result = Convert.ToBoolean(saveXlsxDialog.ShowDialog());

                if (result == true)
                {
                    FileInfo xlsxFile = new FileInfo(saveXlsxDialog.FileName);
                    ProcessFactory.GetReport().fillExcelTableByType(grid, status, xlsxFile);
                    MessageBox.Show("Отчет успешно создан!", "Результат");
                }
            }
            catch (Exception exc)
            {
               
            }
        }

        private void HtmlWorksInfoRepairsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rep;
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog
                {
                    DefaultExt = ".vrt",
                    Filter = "View Ridge Assistant Template files|*.vrt"
                };
                bool? result = true;
                if (result == true)
                {
                    StreamReader sr = new StreamReader("vra.vrt.txt");
                    rep = sr.ReadToEnd();
                    sr.Close();
                }
                else
                {
                    return;
                }
                string full_rep = ProcessFactory.GetReport().genHtmlInfoRepairs(rep);
                System.Windows.Forms.SaveFileDialog sdlg = new System.Windows.Forms.SaveFileDialog
                {
                    DefaultExt = ".html",
                    Filter = "Html Documents (.html)|*.html"
                };
                if (Convert.ToBoolean(sdlg.ShowDialog()) == true)
                {
                    string filename = sdlg.FileName;
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(full_rep);
                    sw.Close();

                    MessageBox.Show("Отчет успешно создан!", "Результат");
                }
            }
            catch (Exception exc)
            {
               
            }
        }

        private void GraphReportButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReportWindow();
            window.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 aB = new AboutBox1();
            aB.ShowDialog();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("readme.docx");
            }
            catch 
            {
                
            }
        }
    }
}
