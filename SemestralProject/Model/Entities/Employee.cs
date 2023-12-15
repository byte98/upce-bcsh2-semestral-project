using CommunityToolkit.Mvvm.Messaging.Messages;
using SemestralProject.Common;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents employee in system.
    /// </summary>
    public class Employee: AsynchronousEntity
    {
        /// <summary>
        /// Personal number of employee.
        /// </summary>
        public int PersonalNumber { get; set; }

        /// <summary>
        /// Date of employment start.
        /// </summary>
        public DateTime EmploymentDate { get; set; }

        /// <summary>
        /// Address of residence of employee.
        /// </summary>
        public Address Residence { get; set; }

        /// <summary>
        /// Personal data of employee.
        /// </summary>
        public Person PersonalData { get; set; }

        /// <summary>
        /// Superior employee.
        /// </summary>
        public Employee? Superior { get; set; }

        /// <summary>
        /// Creates new employee.
        /// </summary>
        /// <param name="id">Identifier of employee.</param>
        /// <param name="personalNumber">Personal number of employee.</param>
        /// <param name="employmentDate">Date of employment start.</param>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <param name="superior">Superior employee.</param>
        private Employee(int id, int personalNumber, DateTime employmentDate, Address residence, Person personalData, Employee? superior)
        {
            this.Id = id;
            this.PersonalNumber = personalNumber;
            this.EmploymentDate = employmentDate;
            this.Residence = residence;
            this.PersonalData = personalData;
            this.Superior = superior;
        }

        /// <summary>
        /// Creates new employee.
        /// </summary>
        /// <param name="personalNumber">Personal number of employee.</param>
        /// <param name="employmentDate">Date of employment start.</param>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <param name="superior">Superior employee.</param>
        /// <returns>Newly created employee.</returns>
        public static Employee Create(int personalNumber, DateTime employmentDate, Address residence, Person personalData, Employee? superior)
        {
            string sql = $"sempr_crud.proc_zamestnanci_create({personalNumber}, {DateUtils.ToSQL(employmentDate)}, {residence.Id}, {personalData.Id}";
            if (superior != null)
            {
                sql += $", {superior.Id}";
            }
            sql += ")";
            int id = Employee.Create(sql, "zamestnanci_seq");
            return new Employee(id, personalNumber, employmentDate, residence, personalData, superior);
        }

        /// <summary>
        /// Creates new employee asynchronously.
        /// </summary>
        /// <param name="personalNumber">Personal number of employee.</param>
        /// <param name="employmentDate">Date of employment start.</param>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <param name="superior">Superior employee.</param>
        /// <returns>Task which resolves into newly created employee.</returns>
        public static Task<Employee> CreateAsync(int personalNumber, DateTime employmentDate, Address residence, Person personalData, Employee? superior)
        {
            return Task<Employee>.Run(() =>
            {
                return Employee.Create(
                    personalNumber,
                    employmentDate,
                    residence,
                    personalData,
                    superior
                );
            });
        }

        /// <summary>
        /// Creates new employee.
        /// </summary>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <returns>Newly created employee.</returns>
        public static Employee Create(Address residence, Person personalData)
        {
            int number = int.MinValue;
            IConnection connection = OracleConnector.Load();
            IDictionary<string, object?>[] result = connection.Query($"SELECT sempr_utils.func_next_seq('OSOBNI_CISLA_SEQ') AS next FROM dual");
            if (result.Length > 0)
            {
                number = (int)(result[0]["next"] ?? int.MinValue);
            }
            connection.Execute("COMMIT");
            return Employee.Create(number, DateTime.Now, residence, personalData, null);
        }

        /// <summary>
        /// Creates new employee asynchronously.
        /// </summary>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <returns>Task which resolves into newly created employee.</returns>
        public static Task<Employee> CreateAsync(Address residence, Person personalData)
        {
            return Task<Employee>.Run(() =>
            {
                return Employee.Create(
                    residence,
                    personalData
                );
            });
        }

        /// <summary>
        /// Gets all available employees.
        /// </summary>
        /// <returns>Array with all available employees.</returns>
        public static Employee[] GetAll()
        {
            IList<Employee> reti = new List<Employee>();
            IDictionary<string, object?>[] results = Employee.Read("sempr_crud.func_zamestnanci_read()");
            foreach (IDictionary<string, object?> row in results)
            {
                Address? address = Address.GetById((int)(row["bydliste"] ?? int.MinValue));
                Person?  person  = Person.GetById((int)(row["osobni_udaje"] ?? int.MinValue));
                Employee? superior = Employee.GetById((int)(row["nadrizeny"] ?? int.MinValue));
                DateTime? date = DateUtils.FromQuery(row["datum_nastupu"]);
                if (address != null && person != null && date != null)
                {
                    reti.Add(new Employee(
                        (int)(row["id_zamestnanec"] ?? int.MinValue),
                        (int)(row["osobni_cislo"] ?? int.MinValue),
                        (DateTime)date,
                        address,
                        person,
                        superior
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available employees.
        /// </summary>
        /// <returns>Task which resolves into array with all available employees.</returns>
        public static Task<Employee[]> GetAllAsync()
        {
            return Task<Employee[]>.Run(() =>
            {
                return Employee.GetAll();
            });
        }

        /// <summary>
        /// Gets employee by its identifier.
        /// </summary>
        /// <param name="id">Identifier of employee.</param>
        /// <returns>
        /// Employee with searched identifier,
        /// or NULL, if there is no such employee.
        /// </returns>
        public static Employee? GetById(int id)
        {
            Employee? reti = null;
            IDictionary<string, object?>[] results = Employee.Read($"sempr_crud.func_zamestnanci_read({id})");
            if (results.Length > 0)
            {
                Address? address = Address.GetById((int)(results[0]["bydliste"] ?? int.MinValue));
                Person? person = Person.GetById((int)(results[0]["osobni_udaje"] ?? int.MinValue));
                if (address != null && person != null)
                {
                    Employee? superior = Employee.GetById((int)(results[0]["nadrizeny"] ?? int.MinValue));
                    if (results[0]["datum_nastupu"] != null)
                    {
                        DateTime? date = DateUtils.FromQuery(results[0]["datum_nastupu"]);
                        if (date != null)
                        {
                            reti = new Employee(
                                    (int)(results[0]["id_zamestnanec"] ?? int.MinValue),
                                    (int)(results[0]["osobni_cislo"] ?? int.MinValue),
                                    (DateTime)date,
                                    address,
                                    person,
                                    superior
                                );
                        }
                    }
                    
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets employee by its identifier.
        /// </summary>
        /// <param name="id">Identifier of employee.</param>
        /// <returns>
        /// Employee with searched identifier,
        /// or NULL, if there is no such employee.
        /// </returns>
        public static Task<Employee?> GetByIdAsync(int id)
        {
            return Task<Employee?>.Run(() =>
            {
                return Employee.GetById(id);
            });
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_zamestnanci_update({this.Id}, {this.PersonalNumber}, {DateUtils.ToSQL(this.EmploymentDate)}, {this.Residence.Id}, {this.PersonalData.Id}";
            if (this.Superior != null)
            {
                sql += $", {this.Superior.Id}";
            }
            sql += ")";
            return Employee.Update(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_zamestnanci_delete({this.Id})";
            return Employee.Delete(sql);
        }

        public override string? ToString()
        {
            return $"{this.PersonalNumber}: {this.PersonalData.ToString()}";
        }
    }
}
