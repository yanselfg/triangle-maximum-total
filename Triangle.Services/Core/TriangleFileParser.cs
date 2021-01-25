using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MaximumTotal.Services.Core
{
    /// <summary>
    /// TriangleFileParser service implementation
    /// </summary>
    public class TriangleFileParser : ITriangleFileParser
    {
        /// <summary>
        /// Transform the triangle of values in an upper regular matrix
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public int[,] ParseTriangleFile(Stream fileStream)
        {
            try
            {
                if (fileStream == null)
                {
                    throw new ArgumentNullException("fileStream");
                }

                var lines = new List<string>();

                using (var sr = new StreamReader(fileStream))
                {
                    while (sr.Peek() >= 0)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }

                if (lines.Count == 0)
                {
                    throw new IndexOutOfRangeException($"File '{fileStream}' is empty");
                }

                var length = lines.Count;
                var matrix = new int[length, length];

                for(var i = 0; i < length; i ++)
                {
                    var lineElements = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for(var j = 0; j < length; j ++)
                    {
                        if (j < lineElements.Length && int.TryParse(lineElements[j], out int value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }

                return matrix;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Async transform the triangle of values in an upper regular matrix
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public async Task<int[,]> ParseTriangleFileAsync(Stream fileStream)
        {
            try
            {
                if (fileStream == null)
                {
                    throw new ArgumentNullException("fileStream");
                }

                var lines = new List<string>();

                using (var sr = new StreamReader(fileStream))
                {
                    while (sr.Peek() >= 0)
                    {
                        lines.Add(await sr.ReadLineAsync());
                    }
                }

                if (lines.Count == 0)
                {
                    throw new IndexOutOfRangeException($"File '{fileStream}' is empty");
                }

                var length = lines.Count;
                var matrix = new int[length, length];

                for (var i = 0; i < length; i++)
                {
                    var lineElements = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (var j = 0; j < length; j++)
                    {
                        if (j < lineElements.Length && int.TryParse(lineElements[j], out int value))
                        {
                            matrix[i, j] = value;
                        }
                        else
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }

                return matrix;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
