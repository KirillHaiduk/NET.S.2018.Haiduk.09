using System;
using System.IO;
using System.Linq;
using System.Text;

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
        /// Method for copy from one file into another by byte
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied bytes</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var fileStream1 = File.OpenRead(sourcePath))
            using (var fileStream2 = File.Create(destinationPath))
            {
                int countBytes = 0;
                for (int i = 0; i < fileStream1.Length; i++)
                {
                    fileStream2.WriteByte((byte)fileStream1.ReadByte());
                    countBytes++;
                }

                return countBytes;
            }
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Method for copy from one file into another by byte using MemoryStream class
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied bytes</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {            
            InputValidation(sourcePath, destinationPath);            
            using (var streamReader = new StreamReader(sourcePath))
            using (var streamWriter = new StreamWriter(destinationPath))
            {
                Encoding encoding = Encoding.ASCII;
                byte[] bytes = encoding.GetBytes(streamReader.ReadToEnd());
                using (var memoryStream = new MemoryStream(bytes, 0, bytes.Length))
                {
                    byte[] newBytes = memoryStream.ToArray();
                    char[] chars = encoding.GetChars(newBytes);
                    streamWriter.Write(chars);                    
                    return newBytes.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Method for copy from one file into another using byte array
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied bytes</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] bytes;            
            using (var fileStream1 = new FileStream(sourcePath, FileMode.Open))
            {
                bytes = new byte[fileStream1.Length];
                fileStream1.Read(bytes, 0, bytes.Length);
            }

            using (FileStream fileStream2 = new FileStream(destinationPath, FileMode.OpenOrCreate))
            {
                fileStream2.Write(bytes, 0, bytes.Length);
            }

            return File.ReadAllBytes(destinationPath).Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        /// Method for copy from one file into another using MemoryStream class
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied bytes</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            return InMemoryByByteCopy(sourcePath, destinationPath);
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        /// Method for copy from one file into another using BufferedStream class
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied bytes</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] bytes;            
            using (var fileStream = new FileStream(sourcePath, FileMode.Open))
            using (var bufferedStream = new BufferedStream(fileStream, (int)fileStream.Length))
            {
                bytes = new byte[bufferedStream.Length];
                bufferedStream.Read(bytes, 0, bytes.Length);
            }

            using (var stream = new FileStream(destinationPath, FileMode.OpenOrCreate))
            using (var bufferedStream = new BufferedStream(stream))
            {
                bufferedStream.Write(bytes, 0, bytes.Length);
            }

            return bytes.Length;
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Method for copy from one file into another using reading and writing line by line
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>Number of copied lines (strings)</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int countStrings = 0;

            using (var fileStream = File.OpenRead(sourcePath))
            using (var steramReader = new StreamReader(fileStream))
            using (var streamWriter = new StreamWriter(destinationPath))
            {
                while (steramReader.Peek() > -1)
                {
                    streamWriter.WriteLine(steramReader.ReadLine());
                    countStrings++;
                }
            }

            return countStrings;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        /// <summary>
        /// Method for checking equality of source and destination files after reading and writing
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>True if files are equal; otherwise, false</returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var sourceFileStream = File.OpenRead(sourcePath))
            using (var destinationFileStream = File.OpenRead(destinationPath))
            using (var sourceStreamReader = new StreamReader(sourceFileStream))
            using (var destinationStreamReader = new StreamReader(destinationFileStream))
            {
                if (sourceFileStream.Length != destinationFileStream.Length)
                {
                    return false;
                }

                while (sourceStreamReader.Peek() > -1)
                {
                    if (sourceStreamReader.ReadLine() != destinationStreamReader.ReadLine())
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Method for checking equality of source and destination files by lines after reading and writing
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>
        /// <returns>True if files are equal; otherwise, false</returns>
        public static bool IsContentEqualByLines(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using (var sourceFileStream = new FileStream(sourcePath, FileMode.Open))
            using (var destinationFileStream = new FileStream(destinationPath, FileMode.Create))
            {
                if (sourceFileStream.Length != destinationFileStream.Length)
                {
                    return false;
                }
                                
                return File.ReadAllBytes(sourcePath).SequenceEqual(File.ReadAllBytes(destinationPath));
            }
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        /// <summary>
        /// Method for validating source and destination paths
        /// </summary>
        /// <param name="sourcePath">Path of source file</param>
        /// <param name="destinationPath">Path of destination file</param>        
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentNullException("Wrong path");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File {nameof(sourcePath)} not found");
            }            
        }

        #endregion

        #endregion
    }
}
