using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which holds personal data for other objects.
    /// </summary>
    public class Person: AsynchronousEntity
    {
        /// <summary>
        /// Name of person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Surname of person.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// E-mail of person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of person.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Creates new person.
        /// </summary>
        /// <param name="id">Identifier of person.</param>
        /// <param name="name">Name of person.</param>
        /// <param name="surname">Surname of person.</param>
        /// <param name="email">E-mail of person.</param>
        /// <param name="phone">Phone of person.</param>
        private Person(int id, string name, string surname, string email, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.Phone = phone;
        }

        /// <summary>
        /// Creates new person.
        /// </summary>
        /// <param name="name">Name of person.</param>
        /// <param name="surname">Surname of person.</param>
        /// <param name="email">E-mail of person.</param>
        /// <param name="phone">Phone number of person.</param>
        /// <returns>Newly created person.</returns>
        public static Person Create(string name, string surname, string email, string phone)
        {
            string sql = $"sempr_crud.proc_osoby_create('{name}', '{surname}', '{email}', '{phone}')";
            int id = Person.Create(sql, "osoby_seq");
            return new Person(id, name, surname, email, phone);
        }

        /// <summary>
        /// Creates new person asynchronously.
        /// </summary>
        /// <param name="name">Name of person.</param>
        /// <param name="surname">Surname of person.</param>
        /// <param name="email">E-mail of person.</param>
        /// <param name="phone">Phone number of person.</param>
        /// <returns>Task which resolves into newly created person.</returns>
        public static Task<Person> CreateAsync(string name, string surname, string email, string phone)
        {
            return Task<Person>.Run(() =>
            {
                return Person.Create(name, surname, email, phone);
            });
        }

        /// <summary>
        /// Gets all available personal data.
        /// </summary>
        /// <returns>Array with all personal data.</returns>
        public static Person[] GetAll()
        {
            IList<Person> reti = new List<Person>();
            IDictionary<string, object?>[] results = Person.Read("sempr_crud.func_osoby_read()");
            if (results.Length > 0)
            {
                foreach(IDictionary<string, object?> row in results)
                {
                    reti.Add(new Person(
                        (int)(row["id_osoba"] ?? int.MinValue),
                        (string)(row["jmeno"] ?? string.Empty),
                        (string)(row["prijmeni"] ?? string.Empty),
                        (string)(row["e_mail"] ?? string.Empty),
                        (string)(row["telefon"] ?? string.Empty)
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available personal data asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all personal data.</returns>
        public static Task<Person[]> GetAllAsync()
        {
            return Task<Person[]>.Run(() =>
            {
                return Person.GetAll();
            });
        }

        /// <summary>
        /// Gets personal data by its identifier.
        /// </summary>
        /// <param name="id">Identifier of personal data.</param>
        /// <returns>
        /// Personal data with searched identifier,
        /// or NULL if there is no such personal data.
        /// </returns>
        public static Person? GetById(int id)
        {
            Person? reti = null;
            IDictionary<string, object?>[] results = Person.Read($"sempr_crud.func_osoby_read({id})");
            if (results.Length > 0)
            {
                reti = new Person(
                        (int)(results[0]["id_osoba"] ?? int.MinValue),
                        (string)(results[0]["jmeno"] ?? string.Empty),
                        (string)(results[0]["prijmeni"] ?? string.Empty),
                        (string)(results[0]["e_mail"] ?? string.Empty),
                        (string)(results[0]["telefon"] ?? string.Empty)
                );
            }
            return reti;
        }

        /// <summary>
        /// Gets personal data by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of personal data.</param>
        /// <returns>
        /// Task which resolves into:
        /// personal data with searched identifier,
        /// or NULL if there is no such personal data.
        /// </returns>
        public static Task<Person?> GetByIdAsync(int id)
        {
            return Task<Person?>.Run(() =>
            {
                return Person.GetById(id);
            });
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_osoby_update({this.Id}, '{this.Name}', '{this.Surname}', '{this.Email}', '{this.Phone}'";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_osoby_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
