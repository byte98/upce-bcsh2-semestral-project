using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model
{
    /// <summary>
    /// Class which represents address.
    /// </summary>
    public class Address: AsynchronousEntity
    {
        /// <summary>
        /// Identifier of address.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Street part of address.
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Number of house.
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// Orientation number of house.
        /// </summary>
        public int? OrientationNumber { get; set; }
        
        /// <summary>
        /// Municipality of address.
        /// </summary>
        public Municipality Municipality { get; set; }

        /// <summary>
        /// Creates new address.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="orientationNumber">Orientation number of house.</param>
        /// <param name="municipality">Municipality of address.</param>
        private Address(int id, string? street, int houseNumber, int? orientationNumber, Municipality municipality)
        {
            this.Id = id;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.OrientationNumber = orientationNumber;
            this.Municipality = municipality;
        }

        /// <summary>
        /// Gets address by its identifier.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <returns>Address with searched identifier or NULL if there is no such address.</returns>
        public static Address? GetById(int id)
        {
            Address? reti = null;
            string sql = $"SELECT * FROM adresy WHERE id_adresa={id}";
            IConnection connection = OracleConnector.Load();
            IDictionary<string, object?>[] result = connection.Query(sql);
            if (result.Length > 0)
            {
                Municipality? municipality = Municipality.GetById((int)(result[0]["obec"] ?? int.MinValue));
                if (municipality is not null)
                {
                    reti = new Address(
                        (int)(result[0]["id_adresa"] ?? int.MinValue),
                        (string?)(result[0]["ulice"]),
                        (int)(result[0]["cislo_popisne"] ?? int.MinValue),
                        (int?)(result[0]["cislo_orientacni"]),
                        municipality
                    );
                }
            }
            return reti;
        }

        /// <summary>
        /// Gets address by its identifier asynchronously.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <returns>
        /// Task which resolves into:
        /// address with searched identifier,
        /// or NULL if there is no such address.
        /// </returns>
        public static Task<Address?> GetByIdAsync(int id)
        {
            return Task<Address?>.Run(() =>
            {
                return Address.GetById(id);
            });
        }

        /// <summary>
        /// Creates new address.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="orientationNumber">Orientation number of house.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Newly created address.</returns>
        public static Address Create(string street, int houseNumber, int orientationNumber, Municipality municipality)
        {   
            string sql = $"EXECUTE sempr_crud.proc_adresy_create('{street}', {houseNumber}, {orientationNumber}, {municipality.Id}";
            int id = Address.Create(sql, "adresy_seq");
            return new Address(id, street, houseNumber, orientationNumber, municipality);
        }


        public override bool Delete()
        {
            return false;
        }

        public override bool Update()
        {
            return false;
        }
    }
}
