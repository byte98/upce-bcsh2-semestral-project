using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class representing login form model.
    /// </summary>
    internal class Login: ASimpleModel
    {
        /// <summary>
        /// Attribute holding personal number of user.
        /// </summary>
        private string personalNumber;

        /// <summary>
        /// Attribute holding password of user.
        /// </summary>
        private string password;

        /// <summary>
        /// Property with personal number of user.
        /// </summary>
        public string PersonalNumber
        {
            get
            {
                return this.personalNumber;
            }

            set
            {
                if (this.personalNumber != value)
                {
                    this.personalNumber = value;
                    this.InvokePropertyChanged("PersonalNumber");
                }
            }
        }

        /// <summary>
        /// Property with password of user.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.InvokePropertyChanged("Password");
                }
            }
        }

    }
}
