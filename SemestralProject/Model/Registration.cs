using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which performs registration of user.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Name of user which will be registered.
        /// </summary>
        private readonly string name = string.Empty;

        /// <summary>
        /// Surname of user which will be registered.
        /// </summary>
        private readonly string surname = string.Empty;

        /// <summary>
        /// E-mail of user which will be registered.
        /// </summary>
        private readonly string email = string.Empty;

        /// <summary>
        /// Phone of user which will be registered.
        /// </summary>
        private readonly string phone = string.Empty;

        /// <summary>
        /// Password of user which will be registered.
        /// </summary>
        private readonly string password = string.Empty;

        /// <summary>
        /// Address of residence of user which will be registered.
        /// </summary>
        private readonly Address address;

        /// <summary>
        /// Personal number of registered user.
        /// </summary>
        public int PersonalNumber { get; private set; } = int.MinValue; 

        /// <summary>
        /// Creates new registration.
        /// </summary>
        /// <param name="name">Name of user which will be registered.</param>
        /// <param name="surname">Surname of user which will be registered.</param>
        /// <param name="email">E-mail of user which will be registered.</param>
        /// <param name="phone">Phone of user which will be registered.</param>
        /// <param name="password">Password of user which will be registered.</param>
        /// <param name="address">Address of residence of user which will be registered.</param>
        public Registration(
            string name,
            string surname,
            string email,
            string phone,
            string password,
            Address address)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.password = password;
            this.address = address;
        }

        /// <summary>
        /// Performs registration of user.
        /// </summary>
        /// <returns>
        /// TRUE if user has been registered,
        /// FALSE otherwise.
        /// </returns>
        public bool Register()
        {
            bool reti = false;
            int? personalNr = Registration.GetPersonalNumber();
            if (personalNr != null)
            {
                Person person = Person.Create(this.name, this.surname, this.email, this.phone);
                Employee employee = Employee.Create((int)personalNr, DateTime.Now, this.address, person, null);
                User.Create(this.password, DateTime.Now, ImageFile.Default, Role.User, State.Active, employee);
                reti = true;
                this.PersonalNumber = (int)personalNr;
            }
            return reti;
        }

        /// <summary>
        /// Performs asynchronous registration of user.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// TRUE if user has been registered,
        /// FALSE otherwise.
        /// </returns>
        public Task<bool> RegisterAsync()
        {
            return Task<bool>.Run(() =>
            {
                return this.Register();
            });
        }

        /// <summary>
        /// Generates new personal number of user.
        /// </summary>
        /// <returns></returns>
        private static int? GetPersonalNumber()
        {
            int? reti = null;
            IConnection connection = OracleConnector.Load();
            connection.Execute("SET TRANSACTION READ WRITE");
            IDictionary<string, object?>[] result = connection.Query($"SELECT sempr_utils.func_next_seq('OSOBNI_CISLA_SEQ') AS next_personal_nr FROM dual");
            connection.Execute("COMMIT");
            if (result.Length > 0)
            {
                reti = (int?)result[0]["next_personal_nr"];
            }
            return reti;
        }
    }
}
