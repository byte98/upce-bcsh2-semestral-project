using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Windows
{
    public partial class LogsWindowViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> logs = new ObservableCollection<string>();

        public LogsWindowViewModel()
        {
            string sql = "SELECT * FROM LOGS";
            IConnection conn = OracleConnector.Load();
            IDictionary<string, object?>[] res = conn.Query(sql);
            foreach (IDictionary<string, object?> row in res)
            {
                StringBuilder reti = new StringBuilder();
                foreach(string key in row.Keys)
                {
                    reti.Append(key);
                    reti.Append(": ");
                    if (row[key] != null)
                    {
                        reti.Append(row[key].ToString());
                    }
                    else
                    {
                        reti.Append("null");
                    }
                    reti.Append("; ");
                }
                logs.Append(reti.ToString());
            }
        }
    }
}
