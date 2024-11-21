using OpenSilver.Themes.Modern;
using OpenSilver.Theming;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ModernThemeTest
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            //Application.Current.Theme = new ModernTheme() { CurrentPalette = ModernTheme.Palettes.Dark };
            InitializeComponent();

            UpdateBackground();
            Loaded += MainPage_Loaded;
            this.DataContext = new DtCtx();
            // Enter construction logic here...
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/ChartsPage");
        }

        private void UpdateBackground()
        {
            MainBackground.Background = Application.Current.Theme is ModernTheme theme && theme.CurrentPalette == ModernTheme.Palettes.Dark
                ? new SolidColorBrush(Color.FromRgb(17, 17, 17))
                : new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void OnClassicThemeClick(object sender, RoutedEventArgs e)
        {
            ApplyTheme(null);
        }

        private void OnModerLightThemeClick(object sender, RoutedEventArgs e)
        {
            ApplyTheme(new ModernTheme());
        }

        private void OnModernDarkThemeClick(object sender, RoutedEventArgs e)
        {
            ApplyTheme(new ModernTheme { CurrentPalette = ModernTheme.Palettes.Dark });
        }

        private void ApplyTheme(Theme theme)
        {
            Application.Current.Theme = theme;
            Window.Current.Content = new MainPage();
        }

        private void ButtonBasePage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/BasePage");
        }

        private void ButtonChartsPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/ChartsPage");
        }

        private void ButtonChartsPointSeriesPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage("/ChartsPointSeriesPage");
        }

        void NavigateToPage(string targetUri)
        {
            // Navigate to the target page:
            Uri uri = new Uri(targetUri, UriKind.Relative);
            PageContainer.Source = uri;

            // Scroll to top:
            ScrollViewer1.ScrollToVerticalOffset(0d);
        }
    }

    public class DtCtx : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public List<Person> People = Person.GetPeople();
        public ObservableCollection<SalesData> ProductASales = SalesData.GetSalesA();
        public ObservableCollection<SalesData> ProductBSales = SalesData.GetSalesB();
        public ObservableCollection<SalesData> ProductCSales = SalesData.GetSalesC();
        public ObservableCollection<SalesData> ProductDSales = SalesData.GetSalesD();
        public ObservableCollection<SalesData> ProductESales = SalesData.GetSalesE();
        public ObservableCollection<SalesData> ProductFSales = SalesData.GetSalesF();
        public ObservableCollection<SalesData> ProductGSales = SalesData.GetSalesG();
        public ObservableCollection<SalesData> ProductHSales = SalesData.GetSalesH();
        public ObservableCollection<SalesData> ProductISales = SalesData.GetSalesI();
        public ObservableCollection<SalesData> ProductJSales = SalesData.GetSalesJ();
        public ObservableCollection<SalesData> ProductKSales = SalesData.GetSalesK();
        public ObservableCollection<SalesData> ProductLSales = SalesData.GetSalesL();
        public ObservableCollection<SalesData> ProductMSales = SalesData.GetSalesM();
        public ObservableCollection<SalesData> ProductNSales = SalesData.GetSalesN();
        string _someString;
        [Required(ErrorMessage = "SomeString is required")]
        public string SomeString
        {
            get { return _someString; }
            set { _someString = value; OnPropertyChanged(); UpdateValidation(); }
        }

        private void UpdateValidation()
        {
            ValidateProperty("SomeString", _someString);
        }

        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ValidateProperty(string propertyName, object value)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(this) { MemberName = propertyName };

            if (!Validator.TryValidateProperty(value, context, results))
            {
                _errors[propertyName] = new List<string>();
                foreach (var validationResult in results)
                {
                    _errors[propertyName].Add(validationResult.ErrorMessage);
                }
                OnErrorsChanged(propertyName);
            }
            else if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }

    public class Person
    {
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        [DisplayName("Is VIP?")]
        public bool IsVIP { get; set; }

        public Person(string firstName, string lastName, int age, bool isVIP)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsVIP = isVIP;
        }

        public static List<Person> GetPeople()
        {
            var people = new List<Person>()
            {
                new Person("John", "Doe", 32, true),
                new Person("Jessica", "Buck", 26, true),
                new Person("Bob", "Deer", 56, false),
                new Person("Georges", "Stag", 32, false),
                new Person("Elma", "Elk", 32, true)
            };
            return people;
        }
    }

    public class SalesData
    {
        public string Month { get; set; }
        public double SalesAmount { get; set; }

        public SalesData(string month, double salesAmount)
        {
            Month = month;
            SalesAmount = salesAmount;
        }


        public static ObservableCollection<SalesData> GetSalesA()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 5000),
                new SalesData("Feb", 7000),
                new SalesData("Mar", 6500),
                new SalesData("Apr", 7500),
                new SalesData("May", 8000),
                new SalesData("Jun", 8500),
                new SalesData("Jul", 9000),
                new SalesData("Aug", 9500),
                new SalesData("Sep", 10000),
                new SalesData("Oct", 10500),
                new SalesData("Nov", 11000),
                new SalesData("Dec", 12000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesB()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 4500),
                new SalesData("Feb", 6500),
                new SalesData("Mar", 6200),
                new SalesData("Apr", 7200),
                new SalesData("May", 7800),
                new SalesData("Jun", 8000),
                new SalesData("Jul", 8700),
                new SalesData("Aug", 9100),
                new SalesData("Sep", 9400),
                new SalesData("Oct", 9800),
                new SalesData("Nov", 10500),
                new SalesData("Dec", 11500)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesC()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 3000),
                new SalesData("Feb", 7000),
                new SalesData("Mar", 4000),
                new SalesData("Apr", 1100),
                new SalesData("May", 1000),
                new SalesData("Jun", 7000),
                new SalesData("Jul", 7000),
                new SalesData("Aug", 9500),
                new SalesData("Sep", 11000),
                new SalesData("Oct", 9500),
                new SalesData("Nov", 10000),
                new SalesData("Dec", 7000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesD()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 11000),
                new SalesData("Feb", 2000),
                new SalesData("Mar", 9500),
                new SalesData("Apr", 7000),
                new SalesData("May", 10500),
                new SalesData("Jun", 1500),
                new SalesData("Jul", 10000),
                new SalesData("Aug", 5500),
                new SalesData("Sep", 12000),
                new SalesData("Oct", 8000),
                new SalesData("Nov", 7500),
                new SalesData("Dec", 8500)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesE()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 4000),
                new SalesData("Feb", 7000),
                new SalesData("Mar", 6500),
                new SalesData("Apr", 1500),
                new SalesData("May", 1000),
                new SalesData("Jun", 10000),
                new SalesData("Jul", 6000),
                new SalesData("Aug", 5500),
                new SalesData("Sep", 8000),
                new SalesData("Oct", 4500),
                new SalesData("Nov", 11000),
                new SalesData("Dec", 5000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesF()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 11500),
                new SalesData("Feb", 8000),
                new SalesData("Mar", 3500),
                new SalesData("Apr", 5000),
                new SalesData("May", 10000),
                new SalesData("Jun", 9500),
                new SalesData("Jul", 7000),
                new SalesData("Aug", 6000),
                new SalesData("Sep", 11000),
                new SalesData("Oct", 4500),
                new SalesData("Nov", 1000),
                new SalesData("Dec", 3000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesG()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 10500),
                new SalesData("Feb", 11500),
                new SalesData("Mar", 2000),
                new SalesData("Apr", 2500),
                new SalesData("May", 1500),
                new SalesData("Jun", 12000),
                new SalesData("Jul", 5000),
                new SalesData("Aug", 11000),
                new SalesData("Sep", 7500),
                new SalesData("Oct", 1000),
                new SalesData("Nov", 6500),
                new SalesData("Dec", 8000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesH()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 10000),
                new SalesData("Feb", 11500),
                new SalesData("Mar", 9000),
                new SalesData("Apr", 4500),
                new SalesData("May", 4000),
                new SalesData("Jun", 1500),
                new SalesData("Jul", 5000),
                new SalesData("Aug", 7500),
                new SalesData("Sep", 7000),
                new SalesData("Oct", 11000),
                new SalesData("Nov", 12000),
                new SalesData("Dec", 3500)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesI()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 9500),
                new SalesData("Feb", 11500),
                new SalesData("Mar", 2000),
                new SalesData("Apr", 2500),
                new SalesData("May", 4000),
                new SalesData("Jun", 3500),
                new SalesData("Jul", 3000),
                new SalesData("Aug", 5000),
                new SalesData("Sep", 6500),
                new SalesData("Oct", 5500),
                new SalesData("Nov", 8000),
                new SalesData("Dec", 12000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesJ()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 4000),
                new SalesData("Feb", 7500),
                new SalesData("Mar", 11000),
                new SalesData("Apr", 1000),
                new SalesData("May", 3000),
                new SalesData("Jun", 8000),
                new SalesData("Jul", 12000),
                new SalesData("Aug", 4500),
                new SalesData("Sep", 10000),
                new SalesData("Oct", 8500),
                new SalesData("Nov", 9000),
                new SalesData("Dec", 2000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesK()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 2500),
                new SalesData("Feb", 11000),
                new SalesData("Mar", 11500),
                new SalesData("Apr", 5000),
                new SalesData("May", 9500),
                new SalesData("Jun", 6000),
                new SalesData("Jul", 5500),
                new SalesData("Aug", 8500),
                new SalesData("Sep", 6500),
                new SalesData("Oct", 7500),
                new SalesData("Nov", 2000),
                new SalesData("Dec", 3500)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesL()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 6500),
                new SalesData("Feb", 2500),
                new SalesData("Mar", 7500),
                new SalesData("Apr", 1500),
                new SalesData("May", 4500),
                new SalesData("Jun", 11000),
                new SalesData("Jul", 10500),
                new SalesData("Aug", 12000),
                new SalesData("Sep", 11500),
                new SalesData("Oct", 4000),
                new SalesData("Nov", 9000),
                new SalesData("Dec", 5000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesM()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 5500),
                new SalesData("Feb", 4500),
                new SalesData("Mar", 3500),
                new SalesData("Apr", 6000),
                new SalesData("May", 7000),
                new SalesData("Jun", 4000),
                new SalesData("Jul", 1500),
                new SalesData("Aug", 5000),
                new SalesData("Sep", 11000),
                new SalesData("Oct", 6500),
                new SalesData("Nov", 8500),
                new SalesData("Dec", 9000)
            };
            return sales;
        }

        public static ObservableCollection<SalesData> GetSalesN()
        {
            var sales = new ObservableCollection<SalesData>
            {
                new SalesData("Jan", 8000),
                new SalesData("Feb", 9000),
                new SalesData("Mar", 1000),
                new SalesData("Apr", 6000),
                new SalesData("May", 5000),
                new SalesData("Jun", 4000),
                new SalesData("Jul", 10000),
                new SalesData("Aug", 11500),
                new SalesData("Sep", 10500),
                new SalesData("Oct", 5500),
                new SalesData("Nov", 7000),
                new SalesData("Dec", 6500)
            };
            return sales;
        }

    }
}
