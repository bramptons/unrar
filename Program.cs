using System;
using System.IO;
using System.Linq;
using SharpCompress;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Readers;

namespace Comics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Enter a file UNC:");
            string s = Console.ReadLine();
            Console.WriteLine("enter filename and extension:");
            string a = Console.ReadLine();

            using(var filestream = File.OpenRead(s+a))
            using(var reader = new StreamReader(filestream)){
                string itis = reader.EndOfStream.ToString();
                Console.WriteLine("Is it null?" + itis ?? "its null") ;                             
            }
            //un rar a file
            RarRar(s, a);
        }

        private static void RarRar(string unc, string filename)
        {
            using(var archive = RarArchive.Open(unc+filename))
            {
                foreach(var entry in archive.Entries.Where(entry => !entry.IsDirectory)){
                    entry.WriteToDirectory(unc, new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}
