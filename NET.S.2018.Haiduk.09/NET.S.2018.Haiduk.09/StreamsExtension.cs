using System;
using System.IO;

namespace NET.S._2018.Haiduk._09
{
    /// <summary>
    /// Static class that contains methods for working with files
    /// </summary>
    public static class StreamsExtension
    {
        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var fs1 = File.OpenRead(sourcePath))
            using (var fs2 = File.Create(destinationPath))
            {
                int countBytes = 0;
                for (int i = 0; i < fs1.Length; i++)
                {
                    fs2.WriteByte((byte)fs1.ReadByte());
                    countBytes++;
                }

                return countBytes;
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file

            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        private static void InputValidation(string sourcePath, string destinationPath)
        {

        }

        #endregion

        #endregion
    }
}
