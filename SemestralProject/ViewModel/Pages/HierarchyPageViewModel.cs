using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles behaviour of hierarchy page.
    /// </summary>
    public partial class HierarchyPageViewModel: AbstractPageViewModel
    {

        /// <summary>
        /// Collection with data from view.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<HierarchyView> viewData;

        /// <summary>
        /// Creates new view model of hierarchy page.
        /// </summary>
        public HierarchyPageViewModel(): base(PermissionNames.HierarchyRead)
        {
            this.viewData = new ObservableCollection<HierarchyView>();
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.ContentVisibility = Visibility.Collapsed;
            this.WaitVisibility = Visibility.Visible;
            string sql = "SELECT * FROM VW_ZAMESTNANCI_HIERARCHIE";
            IConnection connection = await OracleConnector.LoadAsync();
            await connection.ExecuteAsync("SET TRANSACTION READ ONLY");
            IDictionary<string, object?>[] results = await connection.QueryAsync(sql);
            await connection.ExecuteAsync("COMMIT");
            bool[] hasLevels = new bool[128];
            this.ViewData.Clear();
            for (int i = 0; i < results.Length; i++)
            {
                StringBuilder str = new StringBuilder();
                IDictionary<string, object?> row = results[i];
                int? level = (int?)(row["uroven"]);
                int? id = (int?)(row["zamestnanec"]);
                User? user = null;
                if (id != null)
                {
                    user = await User.GetByIdAsync((int)id);
                }
                if (level != null && user != null)
                {
                    for(int j = 0; j < (int)level;  j++)
                    {
                        str.Append("                ");
                    }
                    this.ViewData.Add(new HierarchyView(str.ToString(), user.Employee.PersonalData.Name + " " + user.Employee.PersonalData.Surname, UserImage.FromImageFile(user.Image).ToImage()));
                }
            }
            this.ContentVisibility = Visibility.Visible;
            this.WaitVisibility = Visibility.Collapsed;
        }
    }
}
