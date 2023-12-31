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
    public partial class ImageFile : AsynchronousEntity
    {
        /// <summary>
        /// Creates new imagefile.
        /// </summary>
        /// <param name="id"> Identifier of imagefile. </param>
        /// <param name="content"> Content of image. </param>
        /// <param name="hash"> Hash of file. </param>
        /// <param name="name"> Name of file. </param>
        /// <param name="uploaddate"> Date of upload of file. </param>
        private ImageFile(int id, Clob content, string hash, string name, DateTime uploaddate)
        {
            this.Id = id;
            this.Content = content;
            this.Hash = hash;
            this.Name = name;
            this.UploadDate = uploaddate;
        }

        /// <summary>
        /// Creates new imagefile.
        /// </summary>
        /// <param name="content"> Content of image. </param>
        /// <param name="hash"> Hash of file. </param>
        /// <param name="name"> Name of file. </param>
        /// <param name="uploaddate"> Date of upload of file. </param>
        /// <returns>Newly created imagefile. </returns>
        public static ImageFile Create(Clob content, string hash, string name, DateTime uploaddate)
        {
            string sql = $"sempr_crud.proc_obrazky_create({StringUtils.ToClob(content.Content)}, '{hash}', '{name}', {DateUtils.ToSQL(uploaddate)})";
            int id = Entity.Create(sql, "obrazky_seq");
            return new ImageFile(id, content, hash, name, uploaddate);
        }

        /// <summary>
        /// Creates new imagefile asynchronously.
        /// </summary>
        /// <param name="content"> Content of image. </param>
        /// <param name="hash"> Hash of file. </param>
        /// <param name="name"> Name of file. </param>
        /// <param name="uploaddate"> Date of upload of file. </param>
        /// <returns>Task which resolves into newly created imagefile. </returns>
        public static Task<ImageFile> CreateAsync(Clob content, string hash, string name, DateTime uploaddate)
        {
            return Task<ImageFile>.Run(() =>
            {
                return ImageFile.Create(content, hash, name, uploaddate);
            });
        }

        /// <summary>
        /// Gets all available imagefiles.
        /// </summary>
        /// <returns>
        /// All available imagefiles.
        /// </returns>
        public static ImageFile[] GetAll()
        {
            IList<ImageFile> reti = new List<ImageFile>();
            IDictionary<string, object?>[] results = ImageFile.Read("sempr_crud.func_obrazky_read()");
            foreach(IDictionary<string, object?> row in results)
            {
                ImageFile? imagefile = ImageFile.Parse(row);
                if (imagefile != null)
                {
                    reti.Add(imagefile);
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Gets all available imagefiles asynchronously.
        /// </summary>
        /// <returns>
        /// Task which resolves into array with all available imagefiles.
        /// </returns>
        public static Task<ImageFile[]> GetAllAsync()
        {
            return Task<ImageFile[]>.Run(() => 
            {
                return ImageFile.GetAll();
            });
        }

        /// <summary>
        /// Gets imagefile by its identifier.
        /// </summary>
        /// <param name="id"> Identifier of searched imagefile. </param>
        /// <returns>
        /// ImageFile with searched identifier,
        /// or NULL if there is no such imagefile.
        /// </returns>
        public static ImageFile? GetById(int id)
        {
            ImageFile? reti = null;
            string sql = $"sempr_crud.func_obrazky_read({id})";
            IDictionary<string, object?>[] results = ImageFile.Read(sql);
            if (results.Length > 0)
            {
                reti = ImageFile.Parse(results[0]);
            }
            return reti;
        }

        /// <summary>
        /// Gets imagefile by its identifier asynchronously.
        /// </summary>
        /// <param name="id"> Identifier of searched imagefile. </param>
        /// <returns>
        /// Task which resolves into:
        /// imagefile with searched identifier,
        /// or NULL if there is no such imagefile.
        /// </returns>
        public static Task<ImageFile?> GetByIdAsync(int id)
        {
            return Task<ImageFile?>.Run(() => 
            {
                return ImageFile.GetById(id);
            });
        }

        /// <summary>
        /// Parses imagefile from result of database query.
        /// </summary>
        /// <param name="data">Source of data for entity.</param>
        private static ImageFile? Parse(IDictionary<string, object?> data)
        {
            ImageFile? reti = null;
            int id = (int)(data["id_obrazek"] ?? int.MinValue);
            Clob content = new Clob((string)(data["obsah"] ?? string.Empty));
            string hash = (string)(data["hash"] ?? string.Empty);
            string name = (string)(data["nazev"] ?? string.Empty);
            DateTime uploaddate = (DateTime)(DateUtils.FromQuery(data["datum_nahrani"]) ?? DateTime.Now);
            reti = new ImageFile(id, content, hash, name, uploaddate);
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
            string sql = $"sempr_crud.proc_obrazky_delete({this.Id})";
            return ImageFile.Delete(sql);
        }

    }
}
