using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents single country of the world.
    /// </summary>
    public class Country: AsynchronousEntity
    {
        /// <summary>
        /// Name of country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates new country.
        /// </summary>
        /// <param name="id">Identifier of country.</param>
        /// <param name="name">Name of country.</param>
        private Country(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Creates new country.
        /// </summary>
        /// <param name="name">Name of new country.</param>
        /// <returns>Newly created coutnry.</returns>
        public static Country Create(string name)
        {
            string sql = $"sempr_crud.proc_staty_create('{name}')";
            IConnection connection = OracleConnector.Load();
            connection.Execute(sql);
            return Country.GetByName(name) ?? new Country(int.MinValue, string.Empty);
        }

        /// <summary>
        /// Creates new country asynchronously.
        /// </summary>
        /// <param name="name">Name of new country.</param>
        /// <returns>Task which resloves into newly creates country.</returns>
        public static Task<Country> CreateAsync(string name)
        {
            return Task<Country>.Run(() =>
            {
                return Country.Create(name);
            });
        }

        /// <summary>
        /// Gets all available countries.
        /// </summary>
        /// <returns>Array with all available countries.</returns>
        public static Country[] GetAll()
        {
            IDictionary<string, object?>[] results = Country.Read("sempr_crud.func_staty_read()");
            IList<Country> reti = new List<Country>();
            foreach(IDictionary<string, object?> row in results)
            {
                reti.Add(new Country((int)(row["id_stat"] ?? int.MinValue), (string)(row["nazev"] ?? string.Empty)));
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available countries asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all available countries.</returns>
        public static Task<Country[]> GetAllAsync()
        {
            return Task<Country[]>.Run(() =>
            {
                return Country.GetAll();
            });
        }

        /// <summary>
        /// Gets country by its identifier.
        /// </summary>
        /// <param name="id">Identifier of country.</param>
        /// <returns>Country with searched identifier or NULL if there is no such country.</returns>
        public static Country? GetById(int id)
        {
            Country? reti = null;
            IDictionary<string, object?>[] results = Country.Read($"sempr_crud.func_staty_read({id})");
            if (results.Length > 0)
            {
                reti = new Country((int)(results[0]["id_stat"] ?? int.MinValue), (string)(results[0]["nazev"] ?? string.Empty));
            }
            return reti;
        }

        /// <summary>
        /// Gets country by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of country.</param>
        /// <returns>
        /// Task which resolves into country with searched identifier
        /// or NULL if there is no such country.
        /// </returns>
        public static Task<Country?>GetByIdAsync(int id)
        {
            return Task<Country?>.Run(() =>
            {
                return Country.GetById(id);
            });
        }

        /// <summary>
        /// Gets country by its name.
        /// </summary>
        /// <param name="name">Name of searched country.</param>
        /// <returns>Searched country or NULL if there is no such country.</returns>
        public static Country? GetByName(string name)
        {
            Country? reti = null;
            IDictionary<string, object?>[] result = Country.Read($"sempr_crud.func_staty_read('{name}')");
            if (result.Length > 0)
            {
                reti = new Country((int)(result[0]["id_stat"] ?? int.MinValue), (string)(result[0]["nazev"] ?? string.Empty));
            }
            return reti;
        }

        /// <summary>
        /// Gets country by its name asynchronously.
        /// </summary>
        /// <param name="name">Name of searched country.</param>
        /// <returns>
        /// Task which resolves into:
        /// country with searched name,
        /// or NULL if there is no such country.
        /// </returns>
        public static Task<Country?> GetByNameAsync(string name)
        {
            return Task<Country?>.Run(() =>
            {
                return Country.GetByName(name);
            });
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_staty_update('{this.Name}',{this.Id})";
            return Country.Update(sql);
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_staty_delete({this.Id})";
            return Country.Delete(sql);
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}
