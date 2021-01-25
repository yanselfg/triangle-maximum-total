using Microsoft.AspNetCore.Mvc;
using System.Net;
using Triangle.API.Models;

namespace Triangle.API.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Creates a response message
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        [NonAction]
        protected IActionResult CreateResponseMessage(HttpStatusCode statusCode, string statusDescription)
        {
            var model = CreateResponseMessageModel(statusCode, statusDescription);

            return StatusCode(model.StatusCode, model);
        }

        /// <summary>
        /// Creates a response message with content
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [NonAction]
        protected IActionResult CreateResponseMessage(HttpStatusCode statusCode, string statusDescription, object content)
        {
            var model = CreateResponseMessageModel(statusCode, statusDescription, content);

            return StatusCode(model.StatusCode, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="statusDescription"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [NonAction]
        private StatusCodeModel CreateResponseMessageModel(HttpStatusCode statusCode, string statusDescription, object content = null)
        {
            var model = new StatusCodeModel
            {
                StatusCode = (int)statusCode,
                StatusDescription = statusDescription
            };

            if(content != null)
            {
                model.Data = content;
            }

            return model;
        }
    }
}
