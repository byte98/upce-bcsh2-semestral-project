using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents permission associated with users role.
    /// </summary>
    public class Permission: AsynchronousEntity
    {
        /// <summary>
        /// Name of permission.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// System name of permission.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Creates new permission.
        /// </summary>
        /// <param name="id">Identifier of permission.</param>
        /// <param name="name">Name of permission.</param>
        /// <param name="systemName">System name of permission.</param>
        private Permission(int id, string name, string systemName)
        {
            this.Id = id;
            this.Name = name;
            this.SystemName = systemName;
        }

        /// <summary>
        /// Creates new permission.
        /// </summary>
        /// <param name="name">Name of new permission.</param>
        /// <param name="systemName">System name of new permission.</param>
        /// <returns>Newly created permission.</returns>
        public static new Permission Create(string name, string systemName)
        {
            string sql = $"sempr_crud.proc_opravneni_create('{name}', '{systemName}')";
            int id = Entity.Create(sql, "opravneni_seq");
            return new Permission(id, name, systemName);
        }

        /// <summary>
        /// Creates new permission asynchronously.
        /// </summary>
        /// <param name="name">Name of new permission.</param>
        /// <param name="systemName">System name of new permission.</param>
        /// <returns>Task which resolves into newly created permission.</returns>
        public static Task<Permission> CreateAsync(string name, string systemName)
        {
            return Task<Permission>.Run(() =>
            {
                return Permission.Create(name, systemName);
            });
        }

        /// <summary>
        /// Gets all available permissions.
        /// </summary>
        /// <returns>Array with all available permissions.</returns>
        public static Permission[] GetAll()
        {
            IList<Permission> reti = new List<Permission>();
            IDictionary<string, object?>[] results = Permission.Read("sempr_crud.func_opravneni_read()");
            foreach (IDictionary<string, object?> row in results)
            {
                reti.Add(new Permission(
                        (int)(row["id_opravneni"] ?? int.MinValue),
                        (string)(row["nazev"] ?? string.Empty),
                        (string)(row["systemovy_nazev"] ?? string.Empty)
                    ));
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available permissions asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all available permissions.</returns>
        public static Task<Permission[]> GetAllAsync()
        {
            return Task<Permission[]>.Run(() =>
            {
                return Permission.GetAll();
            });
        }

        /// <summary>
        /// Gets permission by its identifier.
        /// </summary>
        /// <returns>
        /// Permission with searched identifier,
        /// or NULL if there is no such permission.
        /// </returns>
        public static Permission? GetById(int id)
        {
            Permission? reti = null;
            IDictionary<string, object?>[] results = Permission.Read($"sempr_crud.func_opravneni_read({id})");
            if (results.Length > 0)
            {
                IDictionary<string, object?> row = results[0];
                reti = new Permission(
                        (int)(row["id_opravneni"] ?? int.MinValue),
                        (string)(row["nazev"] ?? string.Empty),
                        (string)(row["systemovy_nazev"] ?? string.Empty)
                        );
            }
            return reti;
        }

        /// <summary>
        /// Gets permission by its identifier asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into:
        /// permission with searched identifier,
        /// or NULL if there is no such permission.
        /// </returns>
        public static Task<Permission?> GetByIdAsync(int id)
        {
            return Task<Permission?>.Run(() =>
            {
                return Permission.GetById(id);
            });
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_opravneni_update('{this.Name}', '{this.SystemName}')";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_opravneni_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
