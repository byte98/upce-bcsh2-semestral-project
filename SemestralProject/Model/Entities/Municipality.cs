using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents municipality.
    /// </summary>
    public class Municipality: AsynchronousEntity
    {
        /// <summary>
        /// Identifier of municipality.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Name of municipality.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ZIP code of municipality.
        /// </summary>
        public int ZIP { get; set; }

        /// <summary>
        /// Name of part of municipality.
        /// </summary>
        public string? Part {  get; set; }

        /// <summary>
        /// Country in which is municipality located.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Creates new municipality.
        /// </summary>
        /// <param name="id">Identifier of municipality.</param>
        /// <param name="name">Name of municipality.</param>
        /// <param name="part">Name of part of municipality.</param>
        /// <param name="zip">ZIP code of municipality.</param>
        /// <param name="country">Country in which is municipality located.</param>
        private Municipality(int id, string name, string? part, int zip, Country country)
        {
            this.Id = id;
            this.Name = name;
            this.Part = part;
            this.ZIP = zip;
            this.Country = country;
        }

        /// <summary>
        /// Creates new municipality.
        /// </summary>
        /// <param name="name">Name of new municipality.</param>
        /// <param name="part">Name of part of new municipality.</param>
        /// <param name="zip">ZIP code of new municipality.</param>
        /// <param name="country">Country in which is new municipality located.</param>
        /// <returns>Newly created municipality.</returns>
        public static Municipality Create(string name, string? part, int zip, Country country)
        {
            string sql = $"EXECUTE sempr_crud.proc_obce_create('{name}', '{zip}', {country.Id})";
            if (part is not null)
            {
                sql = $"EXECUTE sempr_crud.proc_obce_create('{name}', '{part}', {zip}, {country.Id})";
            }
            int id = Municipality.Create(sql, "obce_seq");
            return new Municipality(id, name, part, zip, country);
        }

        /// <summary>
        /// Creates new municipality asynchronously.
        /// </summary>
        /// <param name="name">Name of new municipality.</param>
        /// <param name="part">Name of part of new municipality.</param>
        /// <param name="zip">ZIP code of new municipality.</param>
        /// <param name="country">Country in which is new municipality located.</param>
        /// <returns>Task which resolves into newly created municipality.</returns>
        public static Task<Municipality> CreateAsync(string name, string? part, int zip, Country country)
        {
            return Task<Municipality>.Run(() =>
            {
                return Municipality.Create(name, part, zip, country);
            });
        }

        /// <summary>
        /// Gets municipality by its identifier.
        /// </summary>
        /// <param name="id">Identifier of municipality.</param>
        /// <returns>Municipality with searched identifier or NULL if there is no such municipality.</returns>
        public static Municipality? GetById(int id)
        {
            Municipality? reti = null;
            IDictionary<string, object?>[] results = Municipality.Read($"sempr_crud.func_obce_read({id})");
            if (results.Length > 0)
            {
                Country? country = Country.GetById((int)(results[0]["stat"] ?? int.MinValue));
                if (country is not null)
                {
                    reti = new Municipality(
                                (int)(results[0]["id_obec"] ?? int.MinValue),
                                (string)(results[0]["nazev"] ?? string.Empty),
                                (string?)results[0]["cast_obce"],
                                (int)(results[0]["psc"] ?? int.MinValue),
                                country
                           );
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets municipality by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of municipality.</param>
        /// <returns>
        /// Task which resolves into:
        /// municipality with searched identifier,
        /// or NULL if there is no such municipality.
        /// </returns>
        public static Task<Municipality?> GetByIdAsync(int id)
        {
            return Task<Municipality?>.Run(() =>
            {
                return Municipality.GetById(id);
            });
        }

        /// <summary>
        /// Gets all available municipalities.
        /// </summary>
        /// <returns>Array with all available municipalities.</returns>
        public static Municipality[] GetAll()
        {
            IList<Municipality> reti = new List<Municipality>();
            IDictionary<string, object?>[] results = Municipality.Read("sempr_crud.func_obce_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                Country? country = Country.GetById((int)(row["stat"] ?? int.MinValue));
                if (country is not null)
                {
                    reti.Add(new Municipality(
                        (int)(row["id_obec"] ?? int.MinValue),
                        (string)(row["nazev"] ?? string.Empty),
                        (string?)(row["cast_obce"]),
                        (int)(row["psc"] ?? int.MinValue),
                        country
                    ));
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available municipalities asynchronously.
        /// </summary>
        /// <returns>Task which resloves into array with all available municipalities.</returns>
        public static Task<Municipality[]> GetAllAsync()
        {
            return Task<Municipality>.Run(() =>
            {
                return Municipality.GetAll();
            });
        }

        public override bool Delete()
        {
            string sql = $"EXECUTE sempr_crud.proc_obce_delete({this.Id})";
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }

        public override bool Update()
        {
            string sql = $"EXECUTE sempr_crud.proc_obce_update({this.Id}, '{this.Name}',{this.ZIP}, {this.Country.Id})";
            if (this.Part is not null)
            {
                sql = $"EXECUTE sempr_crud.proc_obce_update({this.Id}, '{this.Name}', '{this.Part}', {this.ZIP}, {this.Country.Id})";
            }
            IConnection connection = OracleConnector.Load();
            return connection.Execute(sql);
        }
    }
}
