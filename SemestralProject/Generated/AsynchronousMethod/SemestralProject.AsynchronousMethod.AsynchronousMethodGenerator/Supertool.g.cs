﻿// <auto-generated />
#pragma warning disable
#nullable enable

using System.Threading.Tasks;
namespace SemestralProject.Model
{
    public partial class Supertool
    {
        /// <summary>
        /// Gets names of all available tables asynchronously.
        /// </summary>
        /// <returns> Task which resolves into: array with all available names of tables.</returns>
        public static System.Threading.Tasks.Task<string[]> GetTableNamesAsync()
        {
            return Task<string[]>.Run(() => {
                return Supertool.GetTableNames();
            });
        }

    }
}
