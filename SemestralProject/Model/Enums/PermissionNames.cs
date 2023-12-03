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
        /// Permission to read shift plans.
        /// </summary>
        ShiftPlansRead,

        /// <summary>
        /// Permission to modify shift plans.
        /// </summary>
        ShiftPlansModify,

        /// <summary>
        /// Permission to read actual real schedules.
        /// </summary>
        SchedulesRealRead,

        /// <summary>
        /// Permission to modify actual real schedules.
        /// </summary>
        SchedulesRealModify,

        /// <summary>
        /// Permission to modify actual real schedules of own shifts.
        /// </summary>
        SchedulesRealModifyOwn,

        /// <summary>
        /// Permission to read all assigned shifts.
        /// </summary>
        ShiftsRead,

        /// <summary>
        /// Permission to read own shift.
        /// </summary>
        ShiftsReadOwn,

        /// <summary>
        /// Permission to modify all shifts.
        /// </summary>
        ShiftsModify,

        /// <summary>
        /// Permission to read all branches of company.
        /// </summary>
        BranchesRead,

        /// <summary>
        /// Permission to modify branches of company.
        /// </summary>
        BranchesModify,

        /// <summary>
        /// Permission to read all managed trolleybuses.
        /// </summary>
        TrolleybusesRead,

        /// <summary>
        /// Permission to change managed trolleybuses.
        /// </summary>
        TrolleybusesModify,

        /// <summary>
        /// Permission to read managed metros.
        /// </summary>
        MetroRead,

        /// <summary>
        /// Permission to modify managed metros.
        /// </summary>
        MetroModify,

        /// <summary>
        /// Permission to read all managed trams.
        /// </summary>
        TramsRead,

        /// <summary>
        /// Permission to modify managed trams.
        /// </summary>
        TramsModify,

        /// <summary>
        /// Permission to read all contracted manufacturers.
        /// </summary>
        ManufacturersRead,

        /// <summary>
        /// Permission to change contracted manufacturers.
        /// </summary>
        ManufacturersModify,

        /// <summary>
        /// Permission to read all managed models of vehicles.
        /// </summary>
        ModelsRead,

        /// <summary>
        /// Permission to modify managed models of vehicles.
        /// </summary>
        ModelsModify,

        /// <summary>
        /// Permission to read all available roles.
        /// </summary>
        RolesRead,

        /// <summary>
        /// Permission to modify roles.
        /// </summary>
        RolesModify
    }
}
