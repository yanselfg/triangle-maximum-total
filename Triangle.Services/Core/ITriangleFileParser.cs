using System.IO;
using System.Threading.Tasks;

namespace MaximumTotal.Services.Core
{
    /// <summary>
    /// TriangleFileParser service
    /// </summary>
    public interface ITriangleFileParser
    {
        /// <summary>
        /// Transform the triangle of values in an upper regular matrix
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        int[,] ParseTriangleFile(Stream fileStream);

        /// <summary>
        /// Async transform the triangle of values in an upper regular matrix
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        Task<int[,]> ParseTriangleFileAsync(Stream fileStream);
    }
}
