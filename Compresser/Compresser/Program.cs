using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace Compresser
{
    /// <summary>
    /// This is a compress/decompress console application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Compresses the file.
        /// </summary>
        /// <param name="FileToCompress">The file to compress.</param>
        /// <param name="CompressedFile">The compressed file.</param>
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

        /// <summary>
        /// The Decompress method.
        /// </summary>
        /// <param name="CompressedFile">The compressed file.</param>
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

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            Console.WriteLine("  _____");
            Console.WriteLine(" / ____|");
            Console.WriteLine("| |     ___  _ __ ___  _ __  _ __ ___  ___ ___  ___  _ __");
            Console.WriteLine("| |    / _ \\| '_ ` _ \\| '_ \\| '__/ _ \\/ __/ __|/ _ \\| '__|");
            Console.WriteLine("| |___| (_) | | | | | | |_) | | |  __/\\__ \\__ \\ (_) | |");
            Console.WriteLine(" \\_____\\___/|_| |_| |_| .__/|_|  \\___||___/___/\\___/|_|");
            Console.WriteLine("                      | |");
            Console.WriteLine("                      |_|");

            Console.WriteLine();

            Stopwatch OperationTimer = new Stopwatch();
            int programState = 0;
            while(programState != 3)
            {
                OperationTimer.Reset();
                String FilePath = "";
                String CompressedFilePath = "";
                Console.WriteLine("Enter 1 for compressing");
                Console.WriteLine("Enter 2 for decompressing");
                Console.WriteLine("Enter 3 for exiting the program");
                Console.Write("Select an action: ");
                programState = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine();

                switch (programState)
                {
                    case 1:
                        Console.Write("Enter the file path (this can be done by dragging the file into the console): ");
                        FilePath = Console.ReadLine();
                        CompressedFilePath = FilePath + ".gzip";
                        OperationTimer.Start();
                        CompressFile(FilePath, CompressedFilePath);
                        OperationTimer.Stop();
                        Console.WriteLine("The compressing took " + OperationTimer.ElapsedMilliseconds + " milliseconds");
                        Console.WriteLine();
                        Console.WriteLine("File is compressed, the compressed file can be found in the same directory as the original file.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Enter the file path (this can be done by dragging the file into the console): ");
                        CompressedFilePath = Console.ReadLine();
                        OperationTimer.Start();
                        DeCompressFile(CompressedFilePath);
                        OperationTimer.Stop();
                        Console.WriteLine("The decompressing took " + OperationTimer.ElapsedMilliseconds + " milliseconds");
                        Console.WriteLine();
                        Console.WriteLine("File is decompressed, the decompressed file can be found in the same directory as the compressed file.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                } 
            }
        }
    }
}
