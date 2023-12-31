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
    public partial class Log : AsynchronousEntity
    {
        /// <summary>
        /// Creates new log.
        /// </summary>
        /// <param name="id"> Identifier of log. </param>
        /// <param name="time"> Time of creation of log. </param>
        /// <param name="operation"> Name of performed operation. </param>
        /// <param name="table"> Name of table. </param>
        /// <param name="rows"> Number of affected rows. </param>
        /// <param name="message"> Message connected with log. </param>
        private Log(int id, DateTime time, string operation, string table, int rows, string message)
        {
            this.Id = id;
            this.Time = time;
            this.Operation = operation;
            this.Table = table;
            this.Rows = rows;
            this.Message = message;
        }

        /// <summary>
        /// Gets all available logs.
        /// </summary>
        /// <returns>
        /// All available logs.
        /// </returns>
        public static Log[] GetAll()
        {
            IList<Log> reti = new List<Log>();
            IDictionary<string, object?>[] results = Log.Read("sempr_crud.func_logy_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                Log? log = Log.Parse(row);
                if (log != null)
                {
                    reti.Add(log);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available logs asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into array with all available logs.
        /// </returns>
        public static Task<Log[]> GetAllAsync()
        {
            return Task<Log[]>.Run(() => 
            {
                return Log.GetAll();
            });
        }

        /// <summary>
        /// Gets log by its identifier.
        /// </summary>
        /// <param name="id"> Identifier of searched log. </param>
        /// <returns>
        /// Log with searched identifier,
        /// or NULL if there is no such log.
        /// </returns>
        public static Log? GetById(int id)
        {
            Log? reti = null;
            string sql = $"sempr_crud.func_logy_read({id})";
            IDictionary<string, object?>[] results = Log.Read(sql);
            if (results.Length > 0)
            {
                reti = Log.Parse(results[0]);
            }
            return reti;
        }

        /// <summary>
        /// Gets log by its identifier asynchronously.
        /// </summary>
        /// <param name="id"> Identifier of searched log. </param>
        /// <returns>
        /// Task which resolves into:
        /// log with searched identifier,
        /// or NULL if there is no such log.
        /// </returns>
        public static Task<Log?> GetByIdAsync(int id)
        {
            return Task<Log?>.Run(() => 
            {
                return Log.GetById(id);
            });
        }

        /// <summary>
        /// Parses log from result of database query.
        /// </summary>
        /// <param name="data">Source of data for entity.</param>
        private static Log? Parse(IDictionary<string, object?> data)
        {
            Log? reti = null;
            int id = (int)(data["id_log"] ?? int.MinValue);
            DateTime time = (DateTime)(DateUtils.FromQuery(data["cas"]) ?? DateTime.Now);
            string operation = (string)(data["operace"] ?? string.Empty);
            string table = (string)(data["tabulka"] ?? string.Empty);
            int rows = (int)(data["pocet_radku"] ?? int.MinValue);
            string message = (string)(data["zprava"] ?? string.Empty);
            reti = new Log(id, time, operation, table, rows, message);
            return reti;
        }

        /// <inheritdoc/>
        public override bool Update()
        {
            return false;
        }

        /// <inheritdoc/>
        public override bool Delete()
        {
            return false;
        }

    }
}
