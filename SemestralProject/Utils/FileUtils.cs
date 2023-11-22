using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which contains utility functions to work with files.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Reads content of file defined in resources.
        /// </summary>
        /// <param name="resName">Name of resources.</param>
        /// <param name="resFile">Name of file in resources.</param>
        /// <returns>Content of file.</returns>
        public static byte[] ReadFromResources(string resName, string resFile)
        {
            byte[] reti = new byte[0];
            ResourceManager resourceManager = new ResourceManager(resName, Assembly.GetExecutingAssembly());
            object? obj = resourceManager.GetObject(resFile);
            if (obj != null)
            {
                if (obj.GetType() == typeof(string))
                {
                    reti = Encoding.UTF8.GetBytes((string)obj);
                }
                else
                {
                    reti = (byte[])obj;
                }
            }
            return reti;
        }
    }
}
