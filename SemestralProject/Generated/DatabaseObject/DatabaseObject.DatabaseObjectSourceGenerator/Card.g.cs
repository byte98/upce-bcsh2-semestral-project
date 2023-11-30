﻿/// <auto-generated/>
#pragma warning disable
#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SemestralProject.Utils;

namespace SemestralProject.Model.Entities
{
    public partial class Card : AsynchronousEntity
    {
        /// <summary>
        /// Creates new card.
        /// </summary>
        /// <param name="id"> Identifier of card. </param>
        /// <param name="number"> Number of card. </param>
        /// <param name="issued"> Date of issue of card. </param>
        /// <param name="validity"> Date of cards validity. </param>
        /// <param name="allowed"> Flag, whether card is allowed to use. </param>
        /// <param name="holder"> Holder of card. </param>
        private Card(int id, int number, DateTime issued, DateTime validity, bool allowed, Employee holder)
        {
            this.Id = id;
            this.Number = number;
            this.Issued = issued;
            this.Validity = validity;
            this.Allowed = allowed;
            this.Holder = holder;
        }

        /// <summary>
        /// Creates new card.
        /// </summary>
        /// <param name="number"> Number of card. </param>
        /// <param name="issued"> Date of issue of card. </param>
        /// <param name="validity"> Date of cards validity. </param>
        /// <param name="allowed"> Flag, whether card is allowed to use. </param>
        /// <param name="holder"> Holder of card. </param>
        /// <returns>Newly created card. </returns>
        public static Card Create(int number, DateTime issued, DateTime validity, bool allowed, Employee holder)
        {
            string sql = $"sempr_crud.proc_karty_create({number}, {DateUtils.ToSQL(issued)}, {DateUtils.ToSQL(validity)}, {allowed}, {holder})";
            int id = Card.Create(sql, "cipove_karty_seq");
            return new Card(id, number, issued, validity, allowed, holder);
        }

        /// <summary>
        /// Creates new card asynchronously.
        /// </summary>
        /// <param name="number"> Number of card. </param>
        /// <param name="issued"> Date of issue of card. </param>
        /// <param name="validity"> Date of cards validity. </param>
        /// <param name="allowed"> Flag, whether card is allowed to use. </param>
        /// <param name="holder"> Holder of card. </param>
        /// <returns>Task which resolves into newly created card. </returns>
        public static Task<Card> CreateAsync(int number, DateTime issued, DateTime validity, bool allowed, Employee holder)
        {
            return Task<Card>.Run(() =>
            {
                return Card.Create(number, issued, validity, allowed, holder);
            });
        }

        /// <summary>
        /// Gets all available cards.
        /// </summary>
        /// <returns>
        /// All available cards.
        /// </returns>
        public static Card[] GetAll()
        {
            IList<Card> reti = new List<Card>();
            IDictionary<string, object?>[] results = Card.Read("sempr_crud.func_karty_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                Card? card = Card.Parse(row);
                if (card != null)
                {
                    reti.Add(card);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available cards asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into array with all available cards.
        /// </returns>
        public static Task<Card[]> GetAllAsync()
        {
            return Task<Card[]>.Run(() => 
            {
                return Card.GetAll();
            });
        }

        /// <summary>
        /// Gets card by its identifier.
        /// </summary>
        /// <param name="id"> Identifier of searched card. </param>
        /// <returns>
        /// Card with searched identifier,
        /// or NULL if there is no such card.
        /// </returns>
        public static Card? GetById(int id)
        {
            Card? reti = null;
            string sql = $"sempr_crud.func_karty_read({id})";
            IDictionary<string, object?>[] results = Card.Read(sql);
            if (results.Length > 0)
            {
                reti = Card.Parse(results[0]);
            }
            return reti;
        }

        /// <summary>
        /// Gets card by its identifier asynchronously.
        /// </summary>
        /// <param name="id"> Identifier of searched card. </param>
        /// <returns>
        /// Task which resolves into:
        /// card with searched identifier,
        /// or NULL if there is no such card.
        /// </returns>
        public static Task<Card?> GetByIdAsync(int id)
        {
            return Task<Card?>.Run(() => 
            {
                return Card.GetById(id);
            });
        }

        /// <summary>
        /// Parses card from result of database query.
        /// </summary>
        /// <param name="data">Source of data for entity.</param>
        private static Card? Parse(IDictionary<string, object?> data)
        {
            Card? reti = null;
            int id = (int)(data["id_cipova_karta"] ?? int.MinValue);
            int number = (int)(data["cislo_karty"] ?? int.MinValue);
            DateTime issued = (DateTime)(DateUtils.FromQuery(data["datum_vydani"]) ?? DateTime.Now);
            DateTime validity = (DateTime)(DateUtils.FromQuery(data["datum_platnosti"]) ?? DateTime.Now);
            bool allowed = (bool)(data["povolena"] ?? false);
            Employee? holder = Employee.GetById((int)(data["drzitel"] ?? int.MinValue));
            if (holder != null)
            {
                reti = new Card(id, number, issued, validity, allowed, holder);
            }
            return reti;
        }

        /// <inheritdoc/>
        public override bool Update()
        {
            string sql = $"sempr_crud.proc_karty_update({this.Id}, {this.Number}, {DateUtils.ToSQL(this.Issued)}, {DateUtils.ToSQL(this.Validity)}, {this.Allowed.ToString().ToLower()}, {this.Holder.Id})";
            return Card.Update(sql);
        }

        /// <inheritdoc/>
        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_karty_delete({this.Id})";
            return Card.Delete(sql);
        }

    }
}
