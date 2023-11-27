using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents address.
    /// </summary>
    public class Address: AsynchronousEntity
    {
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
        /// Gets all available addresses.
        /// </summary>
        /// <returns>Array with all available addresses.</returns>
        public static Address[] GetAll()
        {
            IList<Address> reti = new List<Address>();
            IDictionary<string, object?>[] results = Address.Read("sempr_crud.func_adresy_read()");
            foreach (IDictionary<string, object?> row in results)
            {
                Municipality? municipality = Municipality.GetById((int)(row["obec"] ?? int.MinValue));
                if (municipality != null)
                {
                    reti.Add(new Address(
                        (int)(row["id_adresa"] ?? int.MinValue),
                        (string?)(row["ulice"]),
                        (int)(row["cislo_popisne"] ?? int.MinValue),
                        (int?)(row["cislo_orientacni"]),
                        municipality
                    ));
                }
            }
            
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available addresses asynchronously.
        /// </summary>
        /// <returns>Task which resolves into array with all available addresses.</returns>
        public static Task<Address[]> GetAllAsync()
        {
            return Task<Address[]>.Run(() =>
            {
                return Address.GetAll();
            });
        }

        /// <summary>
        /// Gets address by its identifier.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <returns>Address with searched identifier or NULL if there is no such address.</returns>
        public static Address? GetById(int id)
        {
            Address? reti = null;
            IDictionary<string, object?>[] result = Municipality.Read($"sempr_crud.func_adresy_read({id})");
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
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="orientationNumber">Orientation number of house.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Newly created address.</returns>
        public static Address Create(string street, int houseNumber, int orientationNumber, Municipality municipality)
        {   
            string sql = $"sempr_crud.proc_adresy_create('{street}', {houseNumber}, {orientationNumber}, {municipality.Id})";
            int id = Address.Create(sql, "adresy_seq");
            return new Address(id, street, houseNumber, orientationNumber, municipality);
        }

        /// <summary>
        /// Creates new address.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Newly created address.</returns>
        public static Address Create(string street, int houseNumber, Municipality municipality)
        {
            string sql = $"sempr_crud.proc_adresy_create('{street}', {houseNumber}, {municipality.Id})";
            int id = Address.Create(sql, "adresy_seq");
            return new Address(id, street, houseNumber, null, municipality);
        }

        /// <summary>
        /// Creates new address.
        /// </summary>
        /// <param name="houseNumber">House number.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Newly created address.</returns>
        public static Address Create(int houseNumber, Municipality municipality)
        {
            string sql = $"sempr_crud.proc_adresy_create({houseNumber}, {municipality.Id})";
            int id = Address.Create(sql, "adresy_seq");
            return new Address(id, null, houseNumber, null, municipality);
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
        public static Address Create(int houseNumber, int orientationNumber, Municipality municipality)
        {
            string sql = $"sempr_crud.proc_adresy_create({houseNumber}, {orientationNumber}, {municipality.Id})";
            int id = Address.Create(sql, "adresy_seq");
            return new Address(id, null, houseNumber, orientationNumber, municipality);
        }

        /// <summary>
        /// Creates new address asynchronously.
        /// </summary>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="orientationNumber">Orientation number of house.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Task which resolves into newly created address.</returns>
        public static Task<Address> CreateAsync(string street, int houseNumber, int orientationNumber, Municipality municipality)
        {
            return Task<Address>.Run(() =>
            {
                return Address.Create(street, houseNumber, orientationNumber, municipality);
            });
        }

        /// <summary>
        /// Creates new address asynchronously.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Task which resolves into newly created address.</returns>
        public static Task<Address> CreateAsync(string street, int houseNumber, Municipality municipality)
        {
            return Task<Address>.Run(() =>
            {
                return Address.Create(street, houseNumber, municipality);
            });
        }

        /// <summary>
        /// Creates new address asynchronously.
        /// </summary>
        /// <param name="houseNumber">House number.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Task which resolves into newly created address.</returns>
        public static Task<Address> CreateAsync(int houseNumber, Municipality municipality)
        {
            return Task<Address>.Run(() =>
            {
                return Address.Create(houseNumber, municipality);
            });
        }

        /// <summary>
        /// Creates new address asynchronously.
        /// </summary>
        /// <param name="id">Identifier of address.</param>
        /// <param name="street">Street part of address.</param>
        /// <param name="houseNumber">House number.</param>
        /// <param name="orientationNumber">Orientation number of house.</param>
        /// <param name="municipality">Municipality of address.</param>
        /// <returns>Task which resolves into newly created address.</returns>
        public static Task<Address> CreateAsync(int houseNumber, int orientationNumber, Municipality municipality)
        {
            return Task<Address>.Run(() =>
            {
                return Address.Create(houseNumber, orientationNumber, municipality);
            });
        }

        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_adresy_delete({this.Id})";
            return Address.Delete(sql);
        }

        public override bool Update()
        {
            string sql = $"sempr_crud.proc_adresy_update({this.Id}, '{this.Street}', {this.HouseNumber}, {this.OrientationNumber},{this.Municipality.Id})";
            if (this.Street == null && this.OrientationNumber != null)
            {
                sql = $"sempr_crud.proc_adresy_update({this.Id}, {this.HouseNumber}, {this.OrientationNumber},{this.Municipality.Id})";
            }
            else if (this.Street != null && this.OrientationNumber == null)
            {
                sql = $"sempr_crud.proc_adresy_update({this.Id}, '{this.Street}, {this.HouseNumber} ,{this.Municipality.Id})";
            }
            else if (this.Street == null && this.OrientationNumber == null)
            {
                sql = $"sempr_crud.proc_adresy_update({this.Id}, {this.HouseNumber} ,{this.Municipality.Id})";
            }
            return Address.Update(sql);
        }

        public override string? ToString()
        {
            StringBuilder reti = new StringBuilder();
            if (this.Street != null)
            {
                reti.Append(this.Street);
            }
            else
            {
                reti.Append(this.Municipality.Name);
            }
            reti.Append(" ");
            reti.Append(this.HouseNumber);
            if(this.OrientationNumber != null)
            {
                reti.Append("/");
                reti.Append(this.OrientationNumber);
            }
            reti.Append(", ");
            reti.Append(this.Municipality.ToString());
            return reti.ToString();
        }
    }
}
