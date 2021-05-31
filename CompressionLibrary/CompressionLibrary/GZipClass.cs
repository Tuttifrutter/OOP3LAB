using System;
using System.IO;
using System.IO.Compression;

namespace CompressionLibrary
{
    public class GZipClass
    {
        public static string sourceFileType { get; set; } = ".*";
        public static string outputFileType { get; set; } = ".gz";
        public static void Transform(string sourceFile, string outputFile)
        {
            Compress(sourceFile, outputFile);
        }
        public static void Retransform(string sourceFile, string outputFile)
        {
            Decompress(sourceFile, outputFile);
        }
        private static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                    }
                }
            }
        }

        private static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
        }
    }
}
