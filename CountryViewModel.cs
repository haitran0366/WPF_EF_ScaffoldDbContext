using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_EF_ScaffoldDbContext.Models;

namespace WPF_EF_ScaffoldDbContext
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string countryName;
        public string CountryName
        {
            get { return countryName; }
            set
            {
                countryName = value;
                NotifyPropertyChanged("CountryName");
            }
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                NotifyPropertyChanged("Greeting");
            }
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ICommand cmdSave { get; private set; }
        public bool CanExectute
        {
            get { return !string.IsNullOrEmpty(CountryName) & !string.IsNullOrEmpty(Greeting); }
        }



        public CountryViewModel()
        {
            cmdSave = new RelayCommand(Save, () => CanExectute);
        }

        private void Save()
        {
            try
            {
                using (var context = new WPF_DBContext())
                {
                    var country = new TblCountry()
                    {
                        CountryName = CountryName,
                        Greeting = Greeting
                    };
                    context.Add(country);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            ErrorMessage = "Data saved successfully!";
        }
    }
}
