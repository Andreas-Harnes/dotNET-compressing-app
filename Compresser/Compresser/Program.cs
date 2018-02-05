using System;
using System.IO;
using System.IO.Compression;

namespace Compresser
{
    class Program
    {
        static void CompressFile(String FileToCompress, String CompressedFile)
        {
            using(FileStream InputStream = new FileStream( FileToCompress, FileMode.OpenOrCreate, FileAccess.ReadWrite ))
            {
                using(FileStream OutputStream = new FileStream(CompressedFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using(GZipStream Gzip = new GZipStream( OutputStream, CompressionMode.Compress))
                    {
                        InputStream.CopyTo(Gzip);
                    }
                }
            }
        }

        static void DeCompressFile(String CompressedFile)
        {
            String UnCompressedFile = CompressedFile.Substring(0, CompressedFile.Length-5);
            using (FileStream InputStream = new FileStream(CompressedFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (FileStream OutputStream = new FileStream(UnCompressedFile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (GZipStream Gzip = new GZipStream(InputStream, CompressionMode.Decompress))
                    {
                        Gzip.CopyTo(OutputStream);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //int programState = 0;
            //while(programState != 3)
            //{
            //    Console.WriteLine("Enter 1 for compressing");
            //    Console.WriteLine("Enter 2 for decompressing");
            //    Console.WriteLine("Enter 3 for exiting the program");
            //    Console.Write("Enter a number: ");
            //    programState = Convert.ToInt32(Console.ReadLine());
            //}
            String a = "C:\\Users\\Andy\\Desktop\\test.txt";
            String b = a + ".gzip";
            //CompressFile(a, b);
            DeCompressFile(b);
            //Console.WriteLine(b.Substring(0, b.Length - 5));
            //Console.ReadLine();
        }
    }
}
