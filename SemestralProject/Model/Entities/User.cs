using SemestralProject.Common;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents user of the system.
    /// </summary>
    public class User: AsynchronousEntity
    {
        /// <summary>
        /// Attribute which holds password of user.
        /// </summary>
        private string password;

        /// <summary>
        /// Password of user.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = User.HashPassword(value);
            }
        }

        /// <summary>
        /// Date and time of registration.
        /// </summary>
        public DateTime Registration { get; set; }

        /// <summary>
        /// Image of user.
        /// </summary>
        public UserImage Image { get; set; }

        /// <summary>
        /// Role of user.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// State of user.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Employee to which is user assigned to.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="id">Identifier of new user.</param>
        /// <param name="password">Password of new user.</param>
        /// <param name="registration">Date and time of registration of new user.</param>
        /// <param name="image">Image of user.</param>
        /// <param name="role">Role of user.</param>
        /// <param name="state">State of user.</param>
        /// <param name="employee">Employee to which is user assigned to.</param>
        private User(int id, string password, DateTime registration, UserImage image, Role role, State state, Employee employee)
        {
            this.Id = id;
            this.password = User.HashPassword(password);
            this.Registration = registration;
            this.Image = image;
            this.Role = role;
            this.State = state;
            this.Employee = employee;
        }

        /// <summary>
        /// Creates hash of password.
        /// </summary>
        /// <param name="password">Password which hash will be created.</param>
        /// <returns>String containing hashed password.</returns>
        private static string HashPassword(string password)
        {
            return StringUtils.Hash(password);
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="password">Password of new user.</param>
        /// <param name="registration">Date and time of registration of new user.</param>
        /// <param name="image">Image of user.</param>
        /// <param name="role">Role of user.</param>
        /// <param name="state">State of user.</param>
        /// <param name="employee">Employee to which is user assigned to.</param>
        /// <returns>Newly created user.</returns>
        public static User Create(string password, DateTime registration, UserImage image, Role role, State state, Employee employee)
        {
            string sql = $"sempr_crud.proc_uzivatele_create('{User.HashPassword(password)}', {DateUtils.ToSQL(registration)}, {image.ToClob()}, {role.Id}, {state.Id}, {employee.Id})";
            int id = User.Create(sql, "uzivatele_seq");
            return new User(id, password, registration, image, role, state, employee);
        }


        /// <summary>
        /// Creates new user asynchronously.
        /// </summary>
        /// <param name="password">Password of new user.</param>
        /// <param name="registration">Date and time of registration of new user.</param>
        /// <param name="image">Image of user.</param>
        /// <param name="role">Role of user.</param>
        /// <param name="state">State of user.</param>
        /// <param name="employee">Employee to which is user assigned to.</param>
        /// <returns>Task which resolves into newly created user.</returns>
        public static Task<User> CreateAsync(string password, DateTime registration, UserImage image, Role role, State state, Employee employee)
        {
            return Task<User>.Run(() =>
            {
                return User.Create(
                    password,
                    registration,
                    image,
                    role,
                    state,
                    employee
                );
            });
        }

        /// <summary>
        /// Gets all available users.
        /// </summary>
        /// <returns>
        /// Array with all available users.
        /// </returns>
        public static User[] GetAll()
        {
            IList<User> reti = new List<User>();
            IDictionary<string, object?>[] results = User.Read("sempr_crud.func_uzivatele_read()");
            foreach (IDictionary<string, object?> row in results)
            {
                Employee? employee = Employee.GetById((int)(row["zamestnanec"] ?? int.MinValue));
                State? state = State.GetById((int)(row["stav"] ?? int.MinValue));
                Role? role = Role.GetById((int)(row["role"] ?? int.MinValue));
                DateTime? date = DateUtils.FromQuery(row["datum_registrace"]);
                if (date != null && employee != null && state != null && role != null)
                {
                    reti.Add(new User(
                        (int)(row["id_uzivatel"] ?? int.MinValue),
                        (string)(row["heslo"] ?? string.Empty),
                        (DateTime)date,
                        UserImage.FromContent((string)(row["obrazek"] ?? string.Empty)),
                        role,
                        state,
                        employee
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available users asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// array with all available users.
        /// </returns>
        public static Task<User[]> GetAllAsync()
        {
            return Task<User[]>.Run(() =>
            {
                return User.GetAll();
            });
        }

        /// <summary>
        /// Gets all superusers of system.
        /// </summary>
        /// <returns>Array with users with role of superuser.</returns>
        public static User[] GetSuperusers()
        {
            IList<User> reti = new List<User>();
            IDictionary<string, object?>[] results = User.Read("sempr_crud.func_uzivatele_read_superusers()");
            foreach (IDictionary<string, object?> row in results)
            {
                Employee? employee = Employee.GetById((int)(row["zamestnanec"] ?? int.MinValue));
                State? state = State.GetById((int)(row["stav"] ?? int.MinValue));
                Role? role = Role.GetById((int)(row["role"] ?? int.MinValue));
                DateTime date;
                if (DateTime.TryParse((string)(row["datum_registrace"] ?? string.Empty), out date))
                {
                    if (employee != null && state != null && role != null)
                    {
                        reti.Add(new User(
                            (int)(row["id_uzivatel"] ?? int.MinValue),
                            (string)(row["heslo"] ?? string.Empty),
                            date,
                            UserImage.FromContent((string)(row["obrazek"] ?? string.Empty)),
                            role,
                            state,
                            employee
                        ));
                    }
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all superusers of system asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with users with role of superuser.</returns>
        public static Task<User[]> GetSuperusersAsync()
        {
            return Task<User[]>.Run(() =>
            {
                return User.GetSuperusers();
            });
        }

        /// <summary>
        /// Gets user by its identifier.
        /// </summary>
        /// <param name="id">Identifier of user.</param>
        /// <returns>
        /// User with searched identifier,
        /// or NULL if there is no such user.
        /// </returns>
        public static User? GetById(int id)
        {
            User? reti = null;
            IDictionary<string, object?>[] results = User.Read($"sempr_crud.func_uzivatele_read({id})");
            if (results.Length > 0)
            {
                IDictionary<string, object?> row = results[0];
                Employee? employee = Employee.GetById((int)(row["zamestnanec"] ?? int.MinValue));
                State? state = State.GetById((int)(row["stav"] ?? int.MinValue));
                Role? role = Role.GetById((int)(row["role"] ?? int.MinValue));
                DateTime? date = DateUtils.FromQuery(results[0]["datum_registrace"]);
                if (employee != null && state != null && role != null && date != null)
                {
                    reti = new User(
                        (int)(row["id_uzivatel"] ?? int.MinValue),
                        (string)(row["heslo"] ?? string.Empty),
                        (DateTime)date,
                        UserImage.FromContent((string)(row["obrazek"] ?? string.Empty)),
                        role,
                        state,
                        employee
                    );
                }
            }
            return reti;
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_uzivatele_update({this.Id}, '{this.Password}', {DateUtils.ToSQL(this.Registration)}, {this.Image.ToClob()}, {this.Role.Id}, {this.State.Id}, {this.Employee.Id})";
            return User.Update(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_uzivatele_delete({this.Id})";
            return User.Delete(sql);
        }
    }
}
