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
    public partial class Line : AsynchronousEntity
    {
        /// <summary>
        /// Creates new line.
        /// </summary>
        /// <param name="id"> Identifier of line. </param>
        /// <param name="code"> Code of line. </param>
        private Line(int id, string code)
        {
            this.Id = id;
            this.Code = code;
        }

        /// <summary>
        /// Creates new line.
        /// </summary>
        /// <param name="code"> Code of line. </param>
        /// <returns>Newly created line. </returns>
        public static Line Create(string code)
        {
            string sql = $"sempr_crud.proc_linky_create('{code}')";
            int id = Line.Create(sql, "linky_seq");
            return new Line(id, code);
        }

        /// <summary>
        /// Creates new line asynchronously.
        /// </summary>
        /// <param name="code"> Code of line. </param>
        /// <returns>Task which resolves into newly created line. </returns>
        public static Task<Line> CreateAsync(string code)
        {
            return Task<Line>.Run(() =>
            {
                return Line.Create(code);
            });
        }

        /// <summary>
        /// Gets all available lines.
        /// </summary>
        /// <returns>
        /// All available lines.
        /// </returns>
        public static Line[] GetAll()
        {
            IList<Line> reti = new List<Line>();
            IDictionary<string, object?>[] results = Line.Read("sempr_crud.func_linky_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                Line? line = Line.Parse(row);
                if (line != null)
                {
                    reti.Add(line);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available lines asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into array with all available lines.
        /// </returns>
        public static Task<Line[]> GetAllAsync()
        {
            return Task<Line[]>.Run(() => 
            {
                return Line.GetAll();
            });
        }

        /// <summary>
        /// Gets line by its identifier.
        /// </summary>
        /// <param name="id"> Identifier of searched line. </param>
        /// <returns>
        /// Line with searched identifier,
        /// or NULL if there is no such line.
        /// </returns>
        public static Line? GetById(int id)
        {
            Line? reti = null;
            string sql = $"sempr_crud.func_linky_read({id})";
            IDictionary<string, object?>[] results = Line.Read(sql);
            if (results.Length > 0)
            {
                reti = Line.Parse(results[0]);
            }
            return reti;
        }

        /// <summary>
        /// Gets line by its identifier asynchronously.
        /// </summary>
        /// <param name="id"> Identifier of searched line. </param>
        /// <returns>
        /// Task which resolves into:
        /// line with searched identifier,
        /// or NULL if there is no such line.
        /// </returns>
        public static Task<Line?> GetByIdAsync(int id)
        {
            return Task<Line?>.Run(() => 
            {
                return Line.GetById(id);
            });
        }

        /// <summary>
        /// Parses line from result of database query.
        /// </summary>
        /// <param name="data">Source of data for entity.</param>
        private static Line? Parse(IDictionary<string, object?> data)
        {
            Line? reti = null;
            int id = (int)(data["id_linka"] ?? int.MinValue);
            string code = (string)(data["kod"] ?? string.Empty);
            reti = new Line(id, code);
            return reti;
        }

        /// <inheritdoc/>
        public override bool Update()
        {
            string sql = $"sempr_crud.proc_linky_update({this.Id}, '{this.Code}')";
            return Line.Update(sql);
        }

        /// <inheritdoc/>
        public override bool Delete()
        {
            string sql = $"sempr_crud.proc_linky_delete({this.Id})";
            return Line.Delete(sql);
        }

    }
}