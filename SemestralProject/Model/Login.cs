using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents data model of login.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Password entered by user.
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// Personal number entered by user.
        /// </summary>
        public int PersonalNumber {  get; init; }

        /// <summary>
        /// Creates new data model of login.
        /// </summary>
        /// <param name="password">Password entered by user.</param>
        /// <param name="personalNumber">Personal number entered by user.</param>
        public Login(string password, int personalNumber)
        {
            this.PersonalNumber = personalNumber;
            this.Password = StringUtils.Hash(password);
        }

        /// <summary>
        /// Checks, whether there is any user with entered
        /// personal number and password.
        /// </summary>
        /// <returns>
        /// User which matches entered data,
        /// or NULL if there is no such user.
        /// </returns>
        public User? Check()
        {
            User? reti = null;
            IConnection conn = OracleConnector.Load();
            conn.Execute("SET TRANSACTION READ WRITE");
            IDictionary<string, object?>[] result = conn.Query($"SELECT sempr_api.func_users_login({this.PersonalNumber}, '{this.Password}') AS user_id FROM dual");
            if (result.Length > 0)
            {
                IDictionary<string, object?> row = result[0];
                if (row.ContainsKey("user_id"))
                {
                    int id = (int)(row["user_id"] ?? int.MinValue);
                    reti = User.GetById(id);
                }
            }
            conn.Execute("COMMIT");
            if (reti != null)
            {
                this.Log(reti);
            }
            return reti;
        }

        /// <summary>
        /// Logs information about login.
        /// </summary>
        /// <param name="user">User which has logged.</param>
        private void Log(User user)
        {
            IConnection conn = OracleConnector.Load();
            conn.Execute("SET TRANSACTION READ WRITE");
            string sql = $"sempr_api.proc_log('login', 'UZIVATELE', 1, {StringUtils.ToClob($"[ID_UZIVATEL: {user.Id}; HESLO: {user.Password}; DATUM_REGISTRACE: {user.Registration}; OBRAZEK: {user.Image.ToContent()}; ROLE: {user.Role.Id}; STAV: {user.State.Id}; ZAMESTNANEC: {user.Employee.Id};]")}, '')";
            string cmd = $"BEGIN\n    {sql};\nEND;";
            conn.Execute(cmd);
            conn.Execute("COMMIT");
        }

        /// <summary>
        /// Checks, whether there is any user with entered
        /// personal number and password asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// user which matches entered data,
        /// or NULL if there is no such user.
        /// </returns>
        public Task<User?> CheckAsync()
        {
            return Task<User?>.Run(() =>
            {
                return this.Check();
            });
        }
    }
}
