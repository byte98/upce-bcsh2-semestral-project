using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Enums
{
    /// <summary>
    /// Enumeration of all available system names of permissions.
    /// </summary>
    public enum PermissionNames
    {
        /// <summary>
        /// Permission of changing role during program runtime.
        /// </summary>
        RoleModifyRuntime,

        /// <summary>
        /// Permission of changing own role.
        /// </summary>
        RoleModifyOwn,

        /// <summary>
        /// Permission of changing own user data.
        /// </summary>
        UserModifyOwn,

        /// <summary>
        /// Permission of changing own personal number.
        /// </summary>
        EmployeePersonal_numberModifyOwn,

        /// <summary>
        /// Permission of changing date of registration.
        /// </summary>
        UserDateModifyOwn,

        /// <summary>
        /// Permission of changing employment date.
        /// </summary>
        EmployeeDateModifyOwn,

        /// <summary>
        /// Permission to read list of employees.
        /// </summary>
        EmployeesRead,

        /// <summary>
        /// Permission to modify list of employees.
        /// </summary>
        EmployeesModify,

        /// <summary>
        /// Permission to read users (its roles, permissions, etc.)
        /// </summary>
        UsersRead,

        /// <summary>
        /// Permission to modify users (its roles, permissions, etc.)
        /// </summary>
        UsersModify,

        /// <summary>
        /// Permission to read all available lines.
        /// </summary>
        LinesRead,

        /// <summary>
        /// Permission to modify lines.
        /// </summary>
        LinesModify,

        /// <summary>
        /// Permission to read list of stops.
        /// </summary>
        StopsRead,

        /// <summary>
        /// Permission to modify stops.
        /// </summary>
        StopsModify,

        /// <summary>
        /// Permission to read schedules.
        /// </summary>
        SchedulesRead,

        /// <summary>
        /// Permission to modify schedules.
        /// </summary>
        SchedulesModify,

        /// <summary>
        /// Permission to read shifts.
        /// </summary>
        ShiftsRead,

        /// <summary>
        /// Permission to modify shifts.
        /// </summary>
        ShiftsModify,

        /// <summary>
        /// Permission to read all available roles.
        /// </summary>
        RolesRead,

        /// <summary>
        /// Permission to modify roles.
        /// </summary>
        RolesModify,

        /// <summary>
        /// Permission to read logs.
        /// </summary>
        LogsRead,

        /// <summary>
        /// Permission to read hierarchy of company.
        /// </summary>
        HierarchyRead,

        /// <summary>
        /// Permission to use database supertool.
        /// </summary>
        Supertool,

        /// <summary>
        /// Permissions to read others phones.
        /// </summary>
        PhonesRead,

        /// <summary>
        /// Permission to read other emails.
        /// </summary>
        EmailsRead
    }
}
