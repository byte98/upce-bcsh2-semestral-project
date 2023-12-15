﻿// <auto-generated />
#pragma warning disable
#nullable enable

using System.Threading.Tasks;
namespace SemestralProject.Model.Entities
{
    public partial class ImageFile
    {
        /// <summary>
        /// Creates image file from file in storage asynchronously.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns> Task which resolves into: image file created from file in storage.</returns>
        public static System.Threading.Tasks.Task<SemestralProject.Model.Entities.ImageFile> FromFileAsync(string path)
        {
            return Task<SemestralProject.Model.Entities.ImageFile>.Run(() => {
                return ImageFile.FromFile(path);
            });
        }

    }
}
