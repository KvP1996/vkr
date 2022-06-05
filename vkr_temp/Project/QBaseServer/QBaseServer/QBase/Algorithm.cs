using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.QBase
{
    /// <summary>
    /// Base algorithm class.
    /// </summary>
    [System.Serializable]
    public class IDLessAlgorithm
    {
        protected string name;
        protected string description;

        /// <summary>
        /// Algorithm's name.
        /// </summary>
        public string Name { get { return name; } }
        /// <summary>
        /// Algorithm's description.
        /// </summary>
        public string Description { get { return description; } }

        public IDLessAlgorithm() { }

        public IDLessAlgorithm(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }

    /// <summary>
    /// Algorithm with id.
    /// </summary>
    [Serializable]
    public class Algorithm : IDLessAlgorithm
    {
        int id;

        /// <summary>
        /// Algorithm's ID.
        /// </summary>
        public int ID { get { return id; } }

        public Algorithm() : base() { }

        public Algorithm(int id, string name, string description)
            : base(name, description)
        {
            this.id = id;
        }
    }
}