using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinEnterprise.xaml
    /// </summary>
    public partial class WinEnterprise : Window
    {
        private int _id;

        public WinEnterprise()
        {
            InitializeComponent();
        }

        public void Load(EnterpriseDto enterp)
        {
          
            if (enterp == null)
                return;
            _id = enterp.IDEnterprise;
            tbEnterprise.Text = enterp.NameEnterprise;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbEnterprise.Text))
            {
                MessageBox.Show("Название предприятия не должно быть пустым.", "Проверка");
                return;
            }
            if (tbEnterprise.Text.Length > 30)
            {
                MessageBox.Show("Слишком длинное слово.", "Проверка");
                return;
            }

            if ((!string.IsNullOrEmpty(tbEnterprise.Text)))
            {
                EnterpriseDto countr = new EnterpriseDto();
                
                countr.NameEnterprise = tbEnterprise.Text;
                IEnterpriseProcess workProcess = ProcessFactory.GetEnterpriseProcess();
                if (_id == 0)
                {
                    workProcess.Add(countr);
                }
                else
                {
                    countr.IDEnterprise = _id;
                    workProcess.Add(countr);
                }
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
