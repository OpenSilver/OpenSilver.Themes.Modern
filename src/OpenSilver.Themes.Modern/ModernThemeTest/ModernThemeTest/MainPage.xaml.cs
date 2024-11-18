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

namespace ModernThemeTest
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            //Application.Current.Theme = new ModernTheme() { CurrentPalette = ModernTheme.Palettes.Dark };
            InitializeComponent();

            UpdateBackground();

            DataContext = new DtCtx();
        }

        private void UpdateBackground()
        {
            MainBackground.Background = Application.Current.Theme is ModernTheme theme && theme.CurrentPalette == ModernTheme.Palettes.Dark
                ? new SolidColorBrush(Color.FromRgb(51, 51, 51))
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
    }

    public class DtCtx : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public List<Person> People = Person.GetPeople();
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
}
