using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VRA.Dto;
using VRA.BusinessLayer;
using System.Threading;
using System.Globalization;
using VRA.DataAccess;

namespace VRA
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private readonly IList<CountryDto> AllowCountry =  ProcessFactory.GetCountryProcess().GetList();
        private readonly IList<EnterpriseDto> AllowEnterprise = ProcessFactory.GetEnterpriseProcess().GetList();
        public IList<TypeMachineDto> FindedTypeMachine;

        private readonly IList<MachineDto> AllowMachine = ProcessFactory.GetMachinerProcess().GetList();
        private readonly IList<RepairDto> AllowRepair = ProcessFactory.GetRepairProcess().GetList();
        private readonly IList<TypeRepairDto> AllowTypeRepair = ProcessFactory.GetTypeRepairProcess().GetList();
        private readonly IList<TypeMachineDto> AllowTypeMachine = ProcessFactory.GetTypeMachinProcess().GetList();


        public IList<MachineDto> FindedMachine;
        public IList<RepairDto> FindedRepair;
        public IList<TypeRepairDto> FindedTypeRepair;
        public IList<CountryDto> FindedCountry;
        public IList<EnterpriseDto> FindedEnterprise;

        public bool exec;

        public SearchWindow(string status)
        {
            InitializeComponent();

            this.cbNameCountry.ItemsSource = AllowCountry;
            this.cbNameEnterprise.ItemsSource = AllowEnterprise;
            this.cbsRepair.ItemsSource = (from a in AllowTypeRepair orderby a.NameRepair select a);

            switch (status)
            {
                case "Repair":
                    this.SearchTab.SelectedIndex = 2;
                    this.sTypeMachine.Visibility = Visibility.Collapsed;
                    this.sMachine.Visibility = Visibility.Collapsed;
                    break;
                case "Machine":
                    this.SearchTab.SelectedIndex = 0;
                    this.sTypeMachine.Visibility = Visibility.Collapsed;
                    this.sRepair.Visibility = Visibility.Collapsed;
                    break;
                case "TypeMachine":
                    this.SearchTab.SelectedIndex = 1;
                    this.sMachine.Visibility = Visibility.Collapsed;
                    this.sRepair.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SearchMachine(object sender, RoutedEventArgs e)
        {
            this.FindedMachine = ProcessFactory.GetMachinerProcess().SearchMachine(this.CodeMachine.Text, this.cbNameCountry.Text, this.cbNameEnterprise.Text);
            this.exec = true;
            this.Close();
        }

        private void SearchTypeMachine(object sender, RoutedEventArgs e)
        {
            this.FindedTypeMachine = ProcessFactory.GetTypeMachinProcess().SearchTypeMachine(this.tbICodeMachine.Text, this.tbIMark.Text);
            this.exec = true;
            this.Close();
        }

        private void SearchRepair(object sender, RoutedEventArgs e)
        {
            this.FindedRepair = ProcessFactory.GetRepairProcess().SearchRepair(this.tbCodeMachine.Text, this.cbsRepair.Text, this.dpStartDate.Text);
            this.exec = true;
            this.Close();
            IEnumerable<RepairDto> AllTrans = ProcessFactory.GetRepairProcess().GetList();
            if (this.dpStartDate.Text != "")
            {
                IEnumerable<RepairDto> trans = from I in AllTrans where (I.StartDate == Convert.ToDateTime(this.dpStartDate.Text)) select I;
                this.FindedRepair = trans.ToList();
            }
           
            this.exec = true;
            this.Close();

        }




    }
}
