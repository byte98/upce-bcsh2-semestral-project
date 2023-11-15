using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents state of user.
    /// </summary>
    public class State: AsynchronousEntity
    {
        /// <summary>
        /// Identifier of state.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Name of state.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates new state.
        /// </summary>
        /// <param name="id">Identifier of state.</param>
        /// <param name="name">Name of state.</param>
        private State(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Creates new state.
        /// </summary>
        /// <param name="name">Name of new state.</param>
        /// <returns>Newly created state.</returns>
        public static State Create(string name)
        {
            string sql = $"EXECUTE sempr_crud.proc_stavy_create('{name}')";
            int id = State.Create(sql, "role_seq");
            return new State(id, name);
        }

        /// <summary>
        /// Creates new state asynchronously.
        /// </summary>
        /// <param name="name">Name of new state.</param>
        /// <returns>Task which resolves into newly created state.</returns>
        public static Task<State> CreateAsync(string name)
        {
            return Task<State>.Run(() =>
            {
                return State.Create(name);
            });
        }

        /// <summary>
        /// Gets all available states.
        /// </summary>
        /// <returns>Array with all available states.</returns>
        public static State[] GetAll()
        {
            IList<State> reti = new List<State>();
            IDictionary<string, object?>[] results = State.Read("sempr_crud.func_stavy_read()");
            if (results.Length > 0)
            {
                foreach (IDictionary<string, object?> row in results)
                {
                    reti.Add(new State(
                        (int)(row["id_stav"] ?? int.MinValue),
                        (string)(row["nazev"] ?? string.Empty)
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available states asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all available states.</returns>
        public static Task<State[]> GetAllAsync()
        {
            return Task<State[]>.Run(() =>
            {
                return State.GetAll();
            });
        }

        /// <summary>
        /// Gets state by its identifier.
        /// </summary>
        /// <param name="id">Identifier of state.</param>
        /// <returns>
        /// State with searched identifier,
        /// or NULL if there is no such state.
        /// </returns>
        public static State? GetById(int id)
        {
            State? reti = null;
            IDictionary<string, object?>[] results = Role.Read($"sempr_crud.func_stavy_read({id})");
            if (results.Length > 0)
            {
                reti = new State(
                        (int)(results[0]["id_stav"] ?? int.MinValue),
                        (string)(results[0]["nazev"] ?? string.Empty)
                );
            }
            return reti;
        }

        /// <summary>
        /// Gets state by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of state.</param>
        /// <returns>
        /// Task which resolves into:
        /// state with searched identifier,
        /// or NULL if there is no such state.
        /// </returns>
        public static Task<State?> GetByIdAsync(int id)
        {
            return Task<State?>.Run(() =>
            {
                return State.GetById(id);
            });
        }

        public override bool Update()
        {
            string sql = $"EXECUTE sempr_crud.proc_stavy_update({this.Id}, '{this.Name}')";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Delete()
        {
            string sql = $"EXECUTE sempr_crud.proc_stavy_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
