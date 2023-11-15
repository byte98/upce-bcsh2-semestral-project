using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents users role.
    /// </summary>
    public class Role: AsynchronousEntity
    {
        /// <summary>
        /// Identifier of role.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Name of role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates new role.
        /// </summary>
        /// <param name="id">Identifier of role.</param>
        /// <param name="name">Name of role.</param>
        private Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Creates new role.
        /// </summary>
        /// <param name="name">Name of new role.</param>
        /// <returns>Newly created role.</returns>
        public static Role Create(string name)
        {
            string sql = $"EXECUTE sempr_crud.proc_role_create('{name}')";
            int id = Role.Create(sql, "role_seq");
            return new Role(id, name);
        }

        /// <summary>
        /// Creates new role asynchronously.
        /// </summary>
        /// <param name="name">Name of new role.</param>
        /// <returns>Task which resolves into newly created role.</returns>
        public static Task<Role> CreateAsync(string name)
        {
            return Task<Role>.Run(() =>
            {
                return Role.Create(name);
            });
        }

        /// <summary>
        /// Gets all available roles.
        /// </summary>
        /// <returns>Array with all available roles.</returns>
        public static Role[] GetAll()
        {
            IList<Role> reti = new List<Role>();
            IDictionary<string, object?>[] results = Role.Read("sempr_crud.func_role_read()");
            if (results.Length > 0)
            {
                foreach (IDictionary<string, object?> row in results)
                {
                    reti.Add(new Role(
                        (int)(row["id_role"] ?? int.MinValue),
                        (string)(row["nazev"] ?? string.Empty)
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available roles asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all available roles.</returns>
        public static Task<Role[]> GetAllAsync()
        {
            return Task<Role[]>.Run(() =>
            {
                return Role.GetAll();
            });
        }

        /// <summary>
        /// Gets role by its identifier.
        /// </summary>
        /// <param name="id">Identifier of role.</param>
        /// <returns>
        /// Role with specified identifier,
        /// or NULL if there is no such role.
        /// </returns>
        public static Role? GetById(int id)
        {
            Role? reti = null;
            IDictionary<string, object?>[] results = Role.Read($"sempr_crud.func_role_read({id})");
            if (results.Length > 0)
            {
                reti = new Role(
                        (int)(results[0]["id_role"] ?? int.MinValue),
                        (string)(results[0]["nazev"] ?? string.Empty)
                );
            }
            return reti;
        }

        /// <summary>
        /// Gets role by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of role.</param>
        /// <returns>
        /// Task which resolves into:
        /// role with specified identifier,
        /// or NULL if there is no such role.
        /// </returns>
        public static Task<Role?> GetByIdAsync(int id)
        {
            return Task<Role?>.Run(() =>
            {
                return Role.GetById(id);
            });
        }

        public override bool Update()
        {
            string sql = $"EXECUTE sempr_crud.proc_role_update({this.Id}, '{this.Name}')";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Delete()
        {
            string sql = $"EXECUTE sempr_crud.proc_role_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
