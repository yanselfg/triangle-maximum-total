using MaximumTotal.Services.Core;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Triangle.Services
{
    /// <summary>
    /// Triangle service implementation
    /// </summary>
    public class Triangle : ITriangle
    {
        private readonly ITriangleFileParser _triangleFileParser;

        public Triangle(ITriangleFileParser triangleFileParser)
        {
            _triangleFileParser = triangleFileParser;
        }

        /// <summary>
        /// Gets the maximum total of the triangle text file from it's stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public int CalculateMaximumTotal(Stream fileStream)
        {
            try
            {
                if (fileStream == null)
                {
                    throw new ArgumentNullException("fileStream");
                }

                var regularMatrix = _triangleFileParser.ParseTriangleFile(fileStream);
                var xLength = regularMatrix.GetLength(0) - 1;

                for (int i = xLength - 1; i >= 0; i--)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (regularMatrix[i + 1, j] > regularMatrix[i + 1, j + 1])
                        {
                            regularMatrix[i, j] += regularMatrix[i + 1, j];
                        }
                        else
                        {
                            regularMatrix[i, j] += regularMatrix[i + 1, j + 1];
                        }
                    }
                }

                return regularMatrix[0, 0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Async gets the maximum total of the triangle text file from it's stream
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public async Task<int> CalculateMaximumTotalAsync(Stream fileStream)
        {
            try
            {
                if (fileStream == null)
                {
                    throw new ArgumentNullException("fileStream");
                }

                var regularMatrix = await _triangleFileParser.ParseTriangleFileAsync(fileStream);
                var xLength = regularMatrix.GetLength(0) - 1;

                for (int i = xLength - 1; i >= 0; i--)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (regularMatrix[i + 1, j] > regularMatrix[i + 1, j + 1])
                        {
                            regularMatrix[i, j] += regularMatrix[i + 1, j];
                        }
                        else
                        {
                            regularMatrix[i, j] += regularMatrix[i + 1, j + 1];
                        }
                    }
                }

                return regularMatrix[0, 0];
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
