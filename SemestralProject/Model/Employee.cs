using CommunityToolkit.Mvvm.Messaging.Messages;
using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents employee in system.
    /// </summary>
    public class Employee: AsynchronousEntity
    {
        /// <summary>
        /// Identifier of employee.
        /// </summary>
        public int Id { get; init; }

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
        /// <param name="id">Identifier of employee.</param>
        /// <param name="personalNumber">Personal number of employee.</param>
        /// <param name="employmentDate">Date of employment start.</param>
        /// <param name="residence">Address of residence of employee.</param>
        /// <param name="personalData">Personal data of employee.</param>
        /// <param name="superior">Superior employee.</param>
        /// <returns>Newly created employee.</returns>
        public static Employee Create(int personalNumber, DateTime employmentDate, Address residence, Person personalData, Employee? superior)
        {
            string dateFormat = "yyyy-MM-dd HH24:MI:SS";
            string formattedDate = employmentDate.ToString(dateFormat);
            string sqlDate = $"TO_DATE('{formattedDate}', '{dateFormat.ToUpper()})";
            string sql = $"EXECUTE sempr_crud.proc_zamestnanci_create({personalNumber}, {sqlDate}, {residence.Id}, {personalData.Id}";
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
        /// <param name="id">Identifier of employee.</param>
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

        public override bool Update()
        {
            string dateFormat = "yyyy-MM-dd HH24:MI:SS";
            string formattedDate = this.EmploymentDate.ToString(dateFormat);
            string sqlDate = $"TO_DATE('{formattedDate}', '{dateFormat.ToUpper()})";
            string sql = $"EXECUTE sempr_crud.proc_zamestnanci_update({this.Id}, {this.PersonalNumber}, {sqlDate}, {this.Residence.Id}, {this.PersonalData.Id}";
            if (this.Superior != null)
            {
                sql += $", {this.Superior.Id}";
            }
            sql += ")";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Delete()
        {
            string sql = $"EXECUTE sempr_crud.proc_zamestnanci_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
