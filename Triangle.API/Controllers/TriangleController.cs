using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Triangle.Services;

namespace Triangle.API.Controllers
{
    /// <summary>
    /// Triangle REST service
    /// </summary>
    [Route("triangle")]
    public class TriangleController : BaseController
    {
        private readonly ITriangle _triangle;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="triangle"></param>
        public TriangleController(ITriangle triangle)
        {
            _triangle = triangle;                
        }

        /// <summary>
        /// Calculates the maximum total of a triangle text file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            try
            {
                if (file == null)
                {
                    throw new ArgumentNullException("triangleFile");
                }

                using (var fileStream = file.OpenReadStream())
                {
                    var maxTotal = await _triangle.CalculateMaximumTotalAsync(fileStream);

                    return CreateResponseMessage(System.Net.HttpStatusCode.OK, "Success", new
                    {
                        maximumTotal = maxTotal
                    });
                }                    
            }
            catch(Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                return CreateResponseMessage(System.Net.HttpStatusCode.InternalServerError, message);
            }
        }
    }
}
