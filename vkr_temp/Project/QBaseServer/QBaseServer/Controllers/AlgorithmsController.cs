using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using QBaseServer.QBase;

namespace QBaseServer.Controllers
{
    /// <summary>
    /// Methods for algorithms.
    /// </summary>
    public class AlgorithmsController : ApiController
    {
        /// <summary>
        /// Get algorithms.
        /// </summary>
        /// <returns>Algorithms list</returns>
        [ActionName("Index")]
        public ICollection<Algorithm> Get()
        {
            return DBManager.GetAllAlgorithms();
        }

        /// <summary>
        /// Post algorithm.
        /// </summary>
        /// <param name="algorithm">Algorithm's info</param>
        /// <returns>Posted algorithm's ID</returns>
        [ActionName("Index")]
        public HttpResponseMessage Post([FromBody]string algorithm)
        {
            string res;
            var alg = new IDLessAlgorithm();
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var obj = ser.DeserializeObject(algorithm) as Dictionary<string, object>;
                string name;
                string description;
                if (obj.ContainsKey("name"))
                    name = obj["name"].ToString();
                else
                    name = obj["Name"].ToString();
                if (obj.ContainsKey("description"))
                    description = obj["description"].ToString();
                else
                    description = obj["Description"].ToString();
                alg = new IDLessAlgorithm(name, description);
                res = DBManager.AddAlgorithm(alg);
            }
            catch
            {
                res = "Error. Unable to deserialize content. You should post JSON-string with 'name' and 'description' fields.";
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(res)
            };
        }

        /// <summary>
        /// Delete algorithm.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <returns>Deletion result</returns>
        [ActionName("Index")]
        public HttpResponseMessage Delete(int id)
        {
            string res = DBManager.DeleteAlgorithm(id);
            return new HttpResponseMessage()
            {
                Content = new StringContent(res)
            };
        }

        /// <summary>
        /// Put algorithm.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <param name="algorithm">Algorithm's info</param>
        /// <returns>Updating result</returns>
        [ActionName("Index")]
        public HttpResponseMessage Put(int id, [FromBody]string algorithm)
        {
            string res;
            var alg = new IDLessAlgorithm();
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var obj = ser.DeserializeObject(algorithm) as Dictionary<string, object>;
                string name;
                string description;
                if (obj.ContainsKey("name"))
                    name = obj["name"].ToString();
                else
                    name = obj["Name"].ToString();
                if (obj.ContainsKey("description"))
                    description = obj["description"].ToString();
                else
                    description = obj["Description"].ToString();
                alg = new IDLessAlgorithm(name, description);
                res = DBManager.UpdateAlgorithm(id, alg);
            }
            catch
            {
                res = "Error. Unable to deserialize content. You should put JSON-string with 'name' and 'description' fields.";
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(res)
            };
        }

        /// <summary>
        /// Get Q-determinants' IDs for algorithm.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <returns>Q-determinants' IDs array</returns>
        [ActionName("Index")]
        public int[] Get(int id)
        {
            return DBManager.GetAlgorithmDeterminants(id);
        }

        /// <summary>
        /// Post Q-determinant.
        /// </summary>
        /// <param name="id">Algorithm's ID</param>
        /// <param name="determinant">Q-determinant in JSON</param>
        /// <returns>Q-determinmant ID</returns>
        [ActionName("Index")]
        public HttpResponseMessage Post(int id, [FromBody]string determinant)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.AddDeterminant(id, determinant))
            };
        }

        /// <summary>
        /// Compare two algorithms with common dimensions.
        /// </summary>
        /// <param name="id">Compared field.</param>
        /// <param name="args">Algorithms' IDs.</param>
        /// <returns>Comparison result.</returns>
        [ActionName("comparecommon")]
        public HttpResponseMessage PostCompareCommon(string id, [FromBody]string args)
        {
            
            var ser = new JavaScriptSerializer();
            string res = "";
            try
            {
                var dict = ser.DeserializeObject(args) as Dictionary<string, object>;
                int id1 = int.Parse(dict["id1"].ToString());
                int id2 = int.Parse(dict["id2"].ToString());
                
             
                if (id == "ticks")
                    res = DBManager.CompareDeterminantsTicks(id1, id2);
                if (id == "processors")
                    res = DBManager.CompareDeterminantsProcessors(id1, id2);                
            }
            catch
            {
                res = "Arguments parse error.";
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(res)
            };
        }
    }
}
