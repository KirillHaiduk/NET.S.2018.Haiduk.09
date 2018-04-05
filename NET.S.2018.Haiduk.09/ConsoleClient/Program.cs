using System;
using System.Configuration;
using static NET.S._2018.Haiduk._09.StreamsExtension;

namespace NET.S._2018.Haiduk._09
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var source = ConfigurationSettings.AppSettings["sourcePath"];

            var destination = ConfigurationSettings.AppSettings["destinationPath"];

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");

            Console.WriteLine($"InMemoryByBlockCopy() done. Total bytes: {InMemoryByBlockCopy(source, destination)}");

            Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");

            Console.WriteLine($"ByLineCopy() done. Total bytes: {ByLineCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));

            Console.ReadLine();
        }
    }
}
