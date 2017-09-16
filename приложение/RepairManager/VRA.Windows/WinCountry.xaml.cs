using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinCountry.xaml
    /// </summary>
    public partial class WinCountry : Window
    {
        private int _id;

        public WinCountry()
        {
            InitializeComponent();
        }

        public void Load(CountryDto countr)
        {
            if (countr == null)
                return;
            _id = countr.IDCountry;
            tbCountry.Text = countr.NameCountry;

        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCountry.Text))
            {
                MessageBox.Show("Название страны не должно быть пустым.", "Проверка");
                return;
            }
            if (tbCountry.Text.Length > 30)
            {
                MessageBox.Show("Слишком длинное слово.", "Проверка");
                return;
            }

            if ((!string.IsNullOrEmpty(tbCountry.Text)))
            {
                CountryDto countr = new CountryDto();
                countr.NameCountry = tbCountry.Text;
                ICountryProcess workProcess = ProcessFactory.GetCountryProcess();
                if (_id == 0)
                {
                    workProcess.Add(countr);
                }
                else 
                {
                    countr.IDCountry = _id;
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
