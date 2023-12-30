using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.AsynchronousMethod;
using SemestralProject.Common;
using SemestralProject.Model.Enums;
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
    public partial class Role: AsynchronousEntity
    {
        /// <summary>
        /// Name of role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Superuser role in system.
        /// </summary>
        public static readonly Role Superuser = new Role(0, "SUPERUŽIVATEL");

        /// <summary>
        /// Lowest user role in system.
        /// </summary>
        public static readonly Role User = new Role(1, "Uživatel");

        /// <summary>
        /// Array of permissions associated with role.
        /// </summary>
        private Permission[] permissions;


        /// <summary>
        /// Array with all available permissions.
        /// </summary>
        private Permission[] allPermissions;



        /// <summary>
        /// Creates new role.
        /// </summary>
        /// <param name="id">Identifier of role.</param>
        /// <param name="name">Name of role.</param>
        public Role(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            
            this.permissions = new Permission[0];
            this.allPermissions = new Permission[0];
            this.LoadPermissions();
        }

        /// <summary>
        /// Gets permission by its name.
        /// </summary>
        /// <param name="name">Name of permission.</param>
        /// <returns>Permission with defined name or NULL if there is no such permission.</returns>
        private Permission? GetPermissionByName(PermissionNames name)
        {
            Permission? reti = null;
            if (this.allPermissions.Length == 0)
            {
                this.LoadPermissions();
            }
            foreach(Permission perm in this.allPermissions)
            {
                if (perm.SystemName == PermissionNamesConvertor.ToName(name))
                {
                    reti = perm;
                    break;
                }
            }
            return reti;
        }

        /// <summary>
        /// Checks, whether role has associated permission.
        /// </summary>
        /// <param name="name">System name of permission.</param>
        /// <returns>
        /// TRUE if user role has associated permission,
        /// FALSE otherwise.
        /// </returns>
        public bool HasPermission(PermissionNames name)
        {
            bool reti = false;
            if (this.permissions.Length == 0 || this.allPermissions.Length == 0)
            {
                this.LoadPermissions();
            }
            Permission? searched = this.GetPermissionByName(name);
            if (searched != null)
            {
                foreach (Permission permission in this.permissions)
                {
                    if (permission.Equals(searched))
                    {
                        reti = true;
                        break;
                    }
                }

            }
            return reti;
        }

        /// <summary>
        /// Checks, whether role has associated permission asynchronously.
        /// </summary>
        /// <param name="name">System name of permission.</param>
        /// <returns>
        /// Task which resolves into:
        /// TRUE if user role has associated permission,
        /// FALSE otherwise.
        /// </returns>
        public Task<bool> HasPermissionAsync(PermissionNames name)
        {
            return Task<bool>.Run(() =>
            {
                return this.HasPermission(name);
            });
        }

        /// <summary>
        /// Gets all permissions associated with role.
        /// </summary>
        /// <returns>Array of all permissions associated with user role.</returns>
        public Permission[] GetPermissions()
        {
            if (this.permissions.Length == 0 || this.allPermissions.Length == 0)
            {
                this.LoadPermissions();
            }
            return this.permissions;
        }

        /// <summary>
        /// Gets all permissions associated with role asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array of all permissions associated with user role.</returns>
        public Task<Permission[]> GetPermissionsAsync()
        {
            return Task<Permission[]>.Run(() =>
            {
                return this.GetPermissions();
            });
        }

        /// <summary>
        /// Loads all available permissions to user role.
        /// </summary>
        [AsynchronousMethod]
        public void LoadPermissions()
        {
            lock (this)
            {
                if (this.permissions.Length == 0 || this.allPermissions.Length == 0)
                {
                    Rights[] rights = Rights.GetByRole(this);
                    IList<Permission> loaded = new List<Permission>();
                    foreach (Rights right in rights)
                    {
                        loaded.Add(right.Permission);
                    }
                    this.permissions = loaded.ToArray();
                    this.allPermissions = Permission.GetAll();
                }
            }
            
        }

        /// <summary>
        /// Creates new role.
        /// </summary>
        /// <param name="name">Name of new role.</param>
        /// <returns>Newly created role.</returns>
        public static Role Create(string name)
        {
            string sql = $"sempr_crud.proc_role_create('{name}')";
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
            string sql = $"sempr_crud.proc_role_update({this.Id}, '{this.Name}')";
            return Role.Update(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_role_delete({this.Id})";
            return Role.Delete(sql);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
