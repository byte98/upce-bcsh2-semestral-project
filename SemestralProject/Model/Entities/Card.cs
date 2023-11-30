using Microsoft.VisualBasic;
using SemestralProject.AsynchronousMethod;
using SemestralProject.DatabaseObject.DatabaseClass;
using SemestralProject.DatabaseObject.DatabaseColummn;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Model.Entities
{
    /// <summary>
    /// Class which represents card issued to employee.
    /// </summary>
    [DatabaseClass("proc_karty_create", "func_karty_read", "proc_karty_update", "proc_karty_delete", "cipove_karty_seq", "id_cipova_karta")]
    public partial class Card
    {
        /// <summary>
        /// Number of card.
        /// </summary>
        [DatabaseColumn("cislo_karty")]
        public int Number { get; set; }

        /// <summary>
        /// Date of issue of card.
        /// </summary>
        [DatabaseColumn("datum_vydani")]
        public DateTime Issued { get; set; }

        /// <summary>
        /// Date of cards validity.
        /// </summary>
        [DatabaseColumn("datum_platnosti")]
        public DateTime Validity { get; set; }

        /// <summary>
        /// Flag, whether card is allowed to use.
        /// </summary>
        [DatabaseColumn("povolena")]
        public bool Allowed { get; set; }

        /// <summary>
        /// Holder of card.
        /// </summary>
        [DatabaseColumn("drzitel")]
        public Employee Holder { get; set; }



        ///// <summary>
        ///// Creates new card.
        ///// </summary>
        ///// <param name="id">Identifier of card.</param>
        ///// <param name="number">Number of card.</param>
        ///// <param name="issued">Date of issue of card.</param>
        ///// <param name="validity">Date of cards validity.</param>
        ///// <param name="allowed">Flag, whether card is allowed to use.</param>
        ///// <param name="holder">Holder of card.</param>
        //private Card(int id, int number, DateTime issued, DateTime validity, bool allowed,  Employee holder)
        //{
        //    this.Id = id;
        //    this.Number = number;
        //    this.Issued = issued;
        //    this.Validity = validity;
        //    this.Holder = holder;
        //}

        ///// <summary>
        ///// Creates new card.
        ///// </summary>
        ///// <param name="number">Number of card.</param>
        ///// <param name="issued">Date of issue of card.</param>
        ///// <param name="validity">Date of cards validity.</param>
        ///// <param name="allowed">Flag, whether card is allowed to use.</param>
        ///// <param name="holder">Holder of card.</param>
        ///// <returns>Newly created card.</returns>
        //[AsynchronousMethod]
        //public static Card Create(int number, DateTime issued, DateTime validity, bool allowed, Employee holder)
        //{
        //    string sql = $"sempr_crud.proc_karty_create({number}, {DateUtils.ToSQL(issued)}, {DateUtils.ToSQL(validity)}, {allowed.ToString().ToLower()}, {holder.Id})";
        //    int id = Card.Create(sql, "cipove_karty_seq");
        //    return new Card(id, number, issued, validity, allowed, holder);
        //}

        ///// <summary>
        ///// Gets all available cards.
        ///// </summary>
        ///// <returns>Array with all available cards.</returns>
        //[AsynchronousMethod]
        //public static Card[] GetAll()
        //{
        //    IList<Card> reti = new List<Card>();
        //    string sql = $"sempr_crud.proc_karty_read()";
        //    IDictionary<string, object?>[] results = Address.Read(sql);
        //    foreach (IDictionary<string, object?> row in results)
        //    {
        //        Employee? employee = Employee.GetById((int)(row["drzitel"] ?? int.MinValue));
        //        if (employee != null)
        //        {
        //            reti.Add(new Card(
        //                (int)(row["id_cipova_karta"] ?? int.MinValue),
        //                (int)(row["cislo_karty"] ?? int.MinValue),
        //                DateUtils.FromQuery(row["datum_vydani"]) ?? DateTime.Now,
        //                DateUtils.FromQuery(row["datum_platnosti"]) ?? DateTime.Now,
        //                bool.Parse((string)(row["povolena"] ?? "FALSE")),
        //                employee
        //            ));
        //        }
        //    }
        //    return reti.ToArray();
        //}

        ///// <summary>
        ///// Gets card by its identifier.
        ///// </summary>
        ///// <param name="id">Identifier of searched card.</param>
        ///// <returns>Card with searched identifier, or NULL if there is no such card.</returns>
        //[AsynchronousMethod]
        //public static Card? GetById(int id)
        //{
        //    Card? reti = null;
        //    string sql = $"sempr_crud.proc_karty_read()";
        //    IDictionary<string, object?>[] results = Address.Read(sql);
        //    if (results.Length > 0)
        //    {
        //        IDictionary<string, object?> row = results[0];
        //    }
        //    foreach (IDictionary<string, object?> row in results)
        //    {
        //        Employee? employee = Employee.GetById((int)(row["drzitel"] ?? int.MinValue));
        //        if (employee != null)
        //        {
        //            reti = new Card(
        //                (int)(row["id_cipova_karta"] ?? int.MinValue),
        //                (int)(row["cislo_karty"] ?? int.MinValue),
        //                DateUtils.FromQuery(row["datum_vydani"]) ?? DateTime.Now,
        //                DateUtils.FromQuery(row["datum_platnosti"]) ?? DateTime.Now,
        //                bool.Parse((string)(row["povolena"] ?? "FALSE")),
        //                employee
        //            );
        //        }
                
        //    }
        //    return reti;
        //}

        //public override bool Delete()
        //{
        //    return false;
        //}

        //public override bool Update()
        //{
        //    return false;
        //}
    }
}
