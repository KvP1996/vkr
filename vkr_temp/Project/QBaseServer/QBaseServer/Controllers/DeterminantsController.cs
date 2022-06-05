using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QBaseServer.QBase;

namespace QBaseServer.Controllers
{
    public class DeterminantsController : ApiController
    {
        /// <summary>
        /// Get Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's ID</param>
        /// <returns>Q-determinant</returns>
        [ActionName("Index")]
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.GetDeterminant(id))
            };
        }

        /// <summary>
        /// Delete Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's ID</param>
        /// <returns>Deletion result</returns>
        [ActionName("Index")]
        public HttpResponseMessage Delete(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.DeleteDeterminant(id))
            };
        }

        /// <summary>
        /// Get ticks count for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's id.</param>
        /// <returns>Ticks count.</returns>
        [ActionName("ticks")]
        public HttpResponseMessage GetTicks(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.GetDeterminantsTicks(id).ToString())
            };
        }

        /// <summary>
        /// Get processors count for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's id.</param>
        /// <returns>Processors count.</returns>
        [ActionName("processors")]
        public HttpResponseMessage GetProcessors(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.GetDeterminantsProcessors(id).ToString())
            };
        }

        /// <summary>
        /// Get dimensions for Q-determinant.
        /// </summary>
        /// <param name="id">Q-determinant's id.</param>
        /// <returns>Dimensions.</returns>
        [ActionName("dimensions")]
        public HttpResponseMessage GetDimensions(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(DBManager.GetDeterminantsDimensions(id))
            };
        }
    }
}
