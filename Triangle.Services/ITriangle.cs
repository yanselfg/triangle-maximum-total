using System.IO;
using System.Threading.Tasks;

namespace Triangle.Services
{
    /// <summary>
    /// Triangle service
    /// </summary>
    public interface ITriangle
    {
        /// <summary>
        /// Gets the maximum total of the triangle text file from it's stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        int CalculateMaximumTotal(Stream fileStream);

        /// <summary>
        /// Async gets the maximum total of the triangle text file from it's stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        Task<int> CalculateMaximumTotalAsync(Stream fileStream);
    }
}
