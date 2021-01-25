using System.ComponentModel.DataAnnotations;

namespace Triangle.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusCodeModel
    {
        /// <summary>
        /// Status code
        /// </summary>
        [Required]
        public int StatusCode { get; set; }

        /// <summary>
        /// Status description
        /// </summary>
        [Required]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Returned data
        /// </summary>
        public object Data { get; set; }
    }
}
