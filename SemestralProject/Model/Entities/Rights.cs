using SemestralProject.Common;
using SemestralProject.Common.Exceptions;
using SemestralProject.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which handles rights of roles.
    /// </summary>
    public class Rights: AsynchronousEntity, IExceptionThrownSource
    {
        /// <summary>
        /// Identifier of role.
        /// </summary>
        private int Role {  get; init; }

        /// <summary>
        /// Permission associated with right.
        /// </summary>
        public Permission Permission { get; init; }

        /// <summary>
        /// Create new rights.
        /// </summary>
        /// <param name="id">Identifier of rights.</param>
        /// <param name="role">Identifier of role associated with rights.</param>
        /// <param name="permission">Permission associated with rights.</param>
        private Rights(int id, int role, Permission permission)
        {
            this.Id = id;
            this.Role = role;
            this.Permission = permission;
        }

        public event ExceptionThrownEventHandler? ExceptionThrown;

        /// <summary>
        /// Creates new connection between role and permission.
        /// </summary>
        /// <param name="role">Role to which new permission will be given.</param>
        /// <param name="permission">Permission which will be associated with role.</param>
        /// <returns>Newly created connection between role and permission.</returns>
        public static Rights Create(Role role, Permission permission)
        {
            string sql = $"sempr_crud.proc_prava_create({role.Id}, {permission.Id})";
            int id = Rights.Create(sql, "prava_seq");
            return new Rights(id, role.Id, permission);
        }

        /// <summary>
        /// Creates new connection between role and permission asynchronously.
        /// </summary>
        /// <param name="role">Role to which new permission will be given.</param>
        /// <param name="permission">Permission which will be associated with role.</param>
        /// <returns>Task which resolves into newly created connection between role and permission.</returns>
        public static Task<Rights> CreateAsync(Role role, Permission permission)
        {
            return Task<Rights>.Run(() =>
            {
                return Rights.Create(role, permission);
            });
        }

        /// <summary>
        /// Gets all rights connected with role.
        /// </summary>
        /// <param name="role">Role which rights will be returned.</param>
        /// <returns>Array with all rights connected with role.</returns>
        public static Rights[] GetByRole(Role role)
        {
            IList<Rights> reti = new List<Rights>();
            IDictionary<string, object?>[] results = Rights.Read($"sempr_crud.func_prava_read({role.Id})");
            foreach (IDictionary<string, object?> row in results)
            {
                Permission? permission = Permission.GetById((int)(row["opravneni"] ?? int.MinValue));
                if (permission != null)
                {
                    int id = (int)(row["id_pravo"] ?? int.MinValue);
                    reti.Add(new Rights(
                        id,
                        (int)(row["role"] ?? int.MinValue),
                        permission
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all rights connected with role asynchronously.
        /// </summary>
        /// <param name="role">Role which rights will be returned.</param>
        /// <returns>Task which resolves into array with all rights connected with role.</returns>
        public static Task<Rights[]> GetByRoleAsync(Role role)
        {
            return Task<Rights[]>.Run(() =>
            {
                return Rights.GetByRole(role);
            });
        }

        public override bool Update()
        {
            this.ExceptionThrown?.Invoke(this, new ExceptionThrownEventArgs(
                new DeniedCRUDOperationException(this, "UPDATE")));
            return false;
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_prava_delete({this.Id})";
            return Rights.Delete(sql);
        }
    }
}
