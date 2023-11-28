using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SemestralProject.AsynchronousMethod
{
    /// <summary>
    /// Class which defines new attribute for defining asynchronous methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class AsynchronousMethodAttribute : Attribute { }
}
