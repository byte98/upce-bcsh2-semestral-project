using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Common.StringProviders;
using SemestralProject.Data;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which handles behaviour of dummy data page.
    /// </summary>
    [ObservableObject]
    public partial class DummyDataPageViewModel: NavigationSource
    {
        /// <summary>
        /// Base size of created data.
        /// </summary>
        private const int BaseSize = 128;

        /// <summary>
        /// Size of created data. 
        /// </summary>
        private int Size
        {
            get
            {
                Random random = new Random();
                int delta = (int)Math.Round((double)DummyDataPageViewModel.BaseSize / (double)4);
                int min = DummyDataPageViewModel.BaseSize - delta;
                int max = DummyDataPageViewModel.BaseSize + delta;
                return random.Next(min, max);
            }
        }

        /// <summary>
        /// Actual text of status label.
        /// </summary>
        [ObservableProperty]
        private string status = "Připraven";

        /// <summary>
        /// Content of details text box.
        /// </summary>
        [ObservableProperty]
        private string detailsText = string.Empty;

        /// <summary>
        /// Visibility of progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility progressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of details text box.
        /// </summary>
        [ObservableProperty]
        private Visibility detailsVisibility = Visibility.Collapsed;

        /// <summary>
        /// Collection of created municipalities.
        /// </summary>
        private ObservableCollection<Municipality> municipalities;

        /// <summary>
        /// Collection of created addresses.
        /// </summary>
        private ObservableCollection<Address> addresses;

        /// <summary>
        /// Collection of created persons.
        /// </summary>
        private ObservableCollection<Person> persons;

        /// <summary>
        /// Collection of created employees.
        /// </summary>
        private ObservableCollection<Employee> employees;

        /// <summary>
        /// Collection of created roles.
        /// </summary>
        private ObservableCollection<Role> roles;

        /// <summary>
        /// Collection of created users.
        /// </summary>
        private ObservableCollection<User> users;

        /// <summary>
        /// Collection of created lines.
        /// </summary>
        private ObservableCollection<Line> lines;

        /// <summary>
        /// Collection of created stops.
        /// </summary>
        private ObservableCollection<Stop> stops;

        /// <summary>
        /// List of all available images.
        /// </summary>
        private IList<UserImage> images;

        /// <summary>
        /// List of all used codes.
        /// </summary>
        private IList<string> codes;

        /// <summary>
        /// Flag, whether controls should be enabled.
        /// </summary>
        [ObservableProperty]
        private bool controlsEnabled = true;

        /// <summary>
        /// Creates new view mode for dummy data page.
        /// </summary>
        public DummyDataPageViewModel()
        {
            this.municipalities = new ObservableCollection<Municipality>();
            this.addresses = new ObservableCollection<Address>();
            this.persons = new ObservableCollection<Person>();
            this.employees = new ObservableCollection<Employee>();
            this.roles = new ObservableCollection<Role>();
            this.users = new ObservableCollection<User>();
            this.images = new List<UserImage>();
            this.lines = new ObservableCollection<Line>();
            this.stops = new ObservableCollection<Stop>();
            this.codes = new List<string>();
        }

        /// <summary>
        /// Handles click on back button.
        /// </summary>
        [RelayCommand]
        private void BackClicked()
        {
            this.NavigateBack();
        }

        /// <summary>
        /// Handles click on details button.
        /// </summary>
        [RelayCommand]
        private void Details()
        {
            if (this.DetailsVisibility == Visibility.Collapsed)
            {
                this.DetailsVisibility = Visibility.Visible;
            }
            else
            {
                this.DetailsVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Runs whole process.
        /// </summary>
        [RelayCommand]
        private async Task Go()
        {
            this.ProgressVisibility = Visibility.Visible;
            this.ControlsEnabled = false;
            this.DetailsText = string.Empty;
            this.municipalities.CollectionChanged += LogCollection;
            this.addresses.CollectionChanged += LogCollection;
            this.persons.CollectionChanged += LogCollection;
            this.roles.CollectionChanged += LogCollection;
            this.users.CollectionChanged += LogCollection;
            this.lines.CollectionChanged += LogCollection;
            this.stops.CollectionChanged += LogCollection;
            this.Status = "Vytváření obcí...";
            await this.CreateMunicipalities();
            this.Status = "Vytváření adres...";
            await this.CreateAddresses();
            this.Status = "Vytváření osob...";
            await this.CreatePersons();
            this.Status = "Vytváření zaměstnanců...";
            await this.CreateEmployees();
            this.Status = "Vytváření rolí...";
            await this.CreateRoles();
            this.Status = "Vytváření uživatelů...";
            await this.CreateUsers();
            this.Status = "Vytváření linek...";
            await this.CreateLines();
            this.Status = "Vytváření zastávek...";
            await this.CreateStops();
            this.Status = "Hotovo";
            this.ControlsEnabled = true;
            this.ProgressVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles change of collecion.
        /// </summary>
        /// <param name="sender">Sender of event.</param>
        /// <param name="e">Arguments of event.</param>
        private void LogCollection(object? sender,  NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    this.DetailsText = item.ToString() + Environment.NewLine + this.DetailsText;
                }
            }
        }

        /// <summary>
        /// Creates stops.
        /// </summary>
        /// <returns>Task which creates stop.</returns>
        private Task CreateStops()
        {
            return Task.Run(async () =>
            {
                int limit = this.Size;
                for(int i = 0; i < limit; i++)
                {
                    string code = StringUtils.Random(StringUtils.EnglishAlphabetUpper, 3);
                    while (this.codes.Contains(code))
                    {
                        code = StringUtils.Random(StringUtils.EnglishAlphabetUpper, 3);
                    }
                    this.codes.Add(code);
                    Stop stop = await Stop.CreateAsync(code, DummyScript.Stops.ElementAt(i));
                    this.stops.Add(stop);
                }
            });
        }

        /// <summary>
        /// Creates lines.
        /// </summary>
        /// <returns>Task which creates lines.</returns>
        private Task CreateLines()
        {
            return Task.Run(async () =>
            {
                Random random = new Random();
                int limit = random.Next(32, 64);
                for(int i = 0; i < limit; i++)
                {
                    Line l = await Line.CreateAsync(random.Next(100, 999).ToString());
                    this.lines.Add(l);
                }
            });
        }

        /// <summary>
        /// Creates users.
        /// </summary>
        /// <returns>Task which creates users.</returns>
        private Task CreateUsers()
        {
            return Task.Run(async () =>
            {
                Random random = new Random();                
                IStringProvider password = new HashedStringProvider(new RepeatedStringProviders(new ConstantStringProvider("password"), this.employees.Count));
                for (int i = 0; i < this.employees.Count; i++)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    User u = await User.CreateAsync(
                        password.ElementAt(i),
                        DateUtils.Random(this.employees.ElementAt(i).EmploymentDate, this.employees.ElementAt(i).EmploymentDate.AddHours(random.Next(0, 25))),
                        ImageFile.Default,
                        ArrayUtils<Role>.Random(this.roles.ToArray()),
                        State.Active,
                        this.employees.ElementAt(i)
                    );
                    this.users.Add(u);
#pragma warning restore CS8604 // Possible null reference argument.
                }
            });
        }

        /// <summary>
        /// Creates roles.
        /// </summary>
        /// <returns>Task which creates roles.</returns>
        private Task CreateRoles()
        {
            return Task.Run(async () =>
            {
                IConnection connection = await OracleConnector.LoadAsync();
                foreach(string sql in DummyScript.Roles)
                {
                    await connection.ExecuteAsync(sql);
                }
                this.roles.Clear();
                Role[] roles = await Role.GetAllAsync();
                foreach (Role role in roles)
                {
                    this.roles.Add(role);
                }
            });
        }

        /// <summary>
        /// Creates employees.
        /// </summary>
        /// <returns></returns>
        private Task CreateEmployees()
        {
            return Task.Run(async () =>
            {
                Random random = new Random();
                
                int managers = random.Next(16, 32);
                this.employees.Clear();
                IList<Employee> managersEmployees = new List<Employee>();
                foreach (Person p in this.persons)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    Employee e = await Employee.CreateAsync(
                        ArrayUtils<Address>.Random(this.addresses.ToArray()),
                        p
                    );
                    this.employees.Add(e);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                int counter = 0;
                foreach (Employee e in this.employees)
                {
                    DateTime max = DateTime.Now.AddMonths(random.Next(3, 7) * (-1));
                    DateTime min = DateTime.Now.AddYears(random.Next(3, 10) * (-1));
                    if (counter > managers)
                    {
                        e.Superior = this.employees.ElementAt(random.Next(0, managers + 1));
                    }
                    e.EmploymentDate = DateUtils.Random(min, max);
                    await e.UpdateAsync();
                    counter++;
                }
            });
        }

        /// <summary>
        /// Creates persons.
        /// </summary>
        /// <returns>Task which creates persons.</returns>
        private Task CreatePersons()
        {
            return Task.Run(async () =>
            {
                this.persons.Clear();
                int limit = this.Size;
                RandomNumberGenerator rng = new RandomNumberGenerator(123456789, 999999999, limit);
                for (int i = 0; i < limit; i++)
                {
                    Person p = await Person.CreateAsync(
                        DummyScript.Names.ElementAt(i),
                        DummyScript.Surnames.ElementAt(i),
                        DummyScript.Emails.ElementAt(i),
                        "00420" + rng.ElementAt(i).ToString()
                    );
                    this.persons.Add(p);
                }
            });
        }

        /// <summary>
        /// Creates addresses.
        /// </summary>
        /// <returns></returns>
        private Task CreateAddresses()
        {
            return Task.Run(async () =>
            {
                this.addresses.Clear();
                int limit = this.Size;
                RandomNumberGenerator ON = new RandomNumberGenerator(1, 100, limit);
                EvenRandomNumberGenerator HN = new EvenRandomNumberGenerator(1, 9999, limit);
                Random random = new Random();
                for (int i = 0; i < limit; i++)
                {
                    Address? addr = null;
                    if (random.Next(0, 2) == 0)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        addr = await Address.CreateAsync(DummyScript.Streets.ElementAt(i), HN.ElementAt(i), ArrayUtils<Municipality>.Random(this.municipalities.ToArray()));
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                    else
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        addr = await Address.CreateAsync(DummyScript.Streets.ElementAt(i), HN.ElementAt(i), ON.ElementAt(i), ArrayUtils<Municipality>.Random(this.municipalities.ToArray()));
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                    if (addr != null)
                    {
                        this.addresses.Add(addr);
                    }
                }
            });
        }

        /// <summary>
        /// Creates municipalities.
        /// </summary>
        /// <returns>Task which creates municipalities.</returns>
        private Task CreateMunicipalities()
        {
            return Task.Run(async () =>
            {
                this.municipalities.Clear();
                int limit = this.Size;
                for (int i = 0; i < limit; i++)
                {
                    string? part = null;
                    if (new Random().Next(0, 5) == 0)
                    {
                        part = DummyScript.MunicipalityParts.ElementAt(i);
                    }
#pragma warning disable CS8604 // Possible null reference argument.

                    Municipality mun = await Municipality.CreateAsync(
                        DummyScript.Municipalities.ElementAt(i),
                        part,
                        DummyScript.ZipCodes.ElementAt(i),
                        Country.GetById(DummyScript.Country)
                    );
#pragma warning restore CS8604 // Possible null reference argument.
                    this.municipalities.Add(mun);
                }
            });
        }
    }
}
