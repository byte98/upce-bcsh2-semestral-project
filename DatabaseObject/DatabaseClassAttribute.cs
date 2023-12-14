using System;
using System.Collections.Generic;
using System.Text;

namespace SemestralProject.DatabaseObject.DatabaseClass
{
    /// <summary>
    /// Class which defines new attribute for classes with some kind of reflection to the database.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class DatabaseClassAttribute : Attribute
    {
        /// <summary>
        /// Name of method which performs creating of database object.
        /// </summary>
        public string CreateMethod { get; }

        /// <summary>
        /// Name of method which has ability to read database object from database.
        /// </summary>
        public string ReadMethod { get; }

        /// <summary>
        /// Name of method which performs updating of database object.
        /// </summary>
        public string UpdateMethod { get; }

        /// <summary>
        /// Name of method which performs deleting of database object.
        /// </summary>
        public string DeleteMethod { get; }

        /// <summary>
        /// Name of sequence which generates identifiers of database object.
        /// </summary>
        public string Sequence {  get; }

        /// <summary>
        /// Name of column in database with identifier of database object.
        /// </summary>
        public string IdColumn { get; }

        /// <summary>
        /// Creates new attribute for classes with some kind of reflection to the database.
        /// </summary>
        /// <param name="createMethod">Name of method which performs creating of database object or empty string for disable generating create method.</param>
        /// <param name="readMethod">Name of method which has ability to read database object from database or empty string for disable generating read method.</param>
        /// <param name="updateMethod">Name of method which performs updating of database object or empty string for disable generating update method.</param>
        /// <param name="deleteMethod">Name of method which performs deleting of database object or empty string for disable generating delete method.</param>
        /// <param name="sequence">Name of sequence which generates identifiers of database object.</param>
        /// <param name="idCol">Name of column in database with identifier of database object.</param>
        public DatabaseClassAttribute(string createMethod, string readMethod, string updateMethod, string deleteMethod, string sequence, string idCol)
        {
            this.CreateMethod = createMethod;
            this.ReadMethod = readMethod;
            this.UpdateMethod = updateMethod;
            this.DeleteMethod = deleteMethod;
            this.Sequence = sequence;
            this.IdColumn = idCol;
        }
    }
}
