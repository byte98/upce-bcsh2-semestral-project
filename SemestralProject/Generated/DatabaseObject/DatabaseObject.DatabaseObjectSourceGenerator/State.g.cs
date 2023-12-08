﻿/// <auto-generated/>
#pragma warning disable
#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SemestralProject.Utils;

namespace SemestralProject.Model.Entities
{
    public partial class State : AsynchronousEntity
    {
        /// <summary>
        /// Creates new state.
        /// </summary>
        /// <param name="id"> Identifier of state. </param>
        /// <param name="name"> Name of state. </param>
        /// <param name="loginable"> Flag, whether user can log in. </param>
        private State(int id, string name, bool loginable)
        {
            this.Id = id;
            this.Name = name;
            this.Loginable = loginable;
        }

        /// <summary>
        /// Creates new state.
        /// </summary>
        /// <param name="name"> Name of state. </param>
        /// <param name="loginable"> Flag, whether user can log in. </param>
        /// <returns>Newly created state. </returns>
        public static State Create(string name, bool loginable)
        {
            string sql = $"sempr_crud.proc_stavy_create('{name}', {BoolUtils.ToQuery(loginable)})";
            int id = State.Create(sql, "stavy_seq");
            return new State(id, name, loginable);
        }

        /// <summary>
        /// Creates new state asynchronously.
        /// </summary>
        /// <param name="name"> Name of state. </param>
        /// <param name="loginable"> Flag, whether user can log in. </param>
        /// <returns>Task which resolves into newly created state. </returns>
        public static Task<State> CreateAsync(string name, bool loginable)
        {
            return Task<State>.Run(() =>
            {
                return State.Create(name, loginable);
            });
        }

        /// <summary>
        /// Gets all available states.
        /// </summary>
        /// <returns>
        /// All available states.
        /// </returns>
        public static State[] GetAll()
        {
            IList<State> reti = new List<State>();
            IDictionary<string, object?>[] results = State.Read("sempr_crud.func_stavy_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                State? state = State.Parse(row);
                if (state != null)
                {
                    reti.Add(state);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available states asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into array with all available states.
        /// </returns>
        public static Task<State[]> GetAllAsync()
        {
            return Task<State[]>.Run(() => 
            {
                return State.GetAll();
            });
        }

        /// <summary>
        /// Gets state by its identifier.
        /// </summary>
        /// <param name="id"> Identifier of searched state. </param>
        /// <returns>
        /// State with searched identifier,
        /// or NULL if there is no such state.
        /// </returns>
        public static State? GetById(int id)
        {
            State? reti = null;
            string sql = $"sempr_crud.func_stavy_read({id})";
            IDictionary<string, object?>[] results = State.Read(sql);
            if (results.Length > 0)
            {
                reti = State.Parse(results[0]);
            }
            return reti;
        }

        /// <summary>
        /// Gets state by its identifier asynchronously.
        /// </summary>
        /// <param name="id"> Identifier of searched state. </param>
        /// <returns>
        /// Task which resolves into:
        /// state with searched identifier,
        /// or NULL if there is no such state.
        /// </returns>
        public static Task<State?> GetByIdAsync(int id)
        {
            return Task<State?>.Run(() => 
            {
                return State.GetById(id);
            });
        }

        /// <summary>
        /// Parses state from result of database query.
        /// </summary>
        /// <param name="data">Source of data for entity.</param>
        private static State? Parse(IDictionary<string, object?> data)
        {
            State? reti = null;
            int id = (int)(data["id_stav"] ?? int.MinValue);
            string name = (string)(data["nazev"] ?? string.Empty);
            bool loginable = BoolUtils.FromQuery(data["prihlasitelny"]);
            reti = new State(id, name, loginable);
            return reti;
        }

        /// <inheritdoc/>
        public override bool Update()
        {
            string sql = $"sempr_crud.proc_stavy_update({this.Id}, '{this.Name}', {BoolUtils.ToQuery(this.Loginable)})";
            return State.Update(sql);
        }

        /// <inheritdoc/>
        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_stavy_delete({this.Id})";
            return State.Delete(sql);
        }

    }
}