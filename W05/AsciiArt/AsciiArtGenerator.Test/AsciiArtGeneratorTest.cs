using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsciiArtGenerator.Test
{
    [TestClass]
    public class AsciiArtGeneratorTest
    {
        private static string StartupPath => System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static string MediaBasePath => System.IO.Path.Combine(StartupPath, "media");

        private static string GetMediaPath(string folder)
        {
            return System.IO.Path.Combine(MediaBasePath, folder);
        }
        
        private IEnumerable<string> GetFilesInFolder(string folder)
        {
            return System.IO.Directory.GetFiles(GetMediaPath(folder));
        } 

        private void PrintAllImages(IEnumerable<string> filenames, int width = 160)
        {
            var sw = new Stopwatch();
            sw.Start();
            foreach (var f in filenames)
            {
                Debug.Write($"Generating ASCII art for file {f}...");
                var sw2 = new Stopwatch();
                sw2.Start();
                var bm = (Bitmap)Image.FromFile(f);
                var generator = new Generator();
                var ascii = generator.GenerateFrom(bm, width);
                sw2.Stop();
                Debug.WriteLine($"Done in {sw.Elapsed.TotalSeconds}s:");

                Debug.WriteLine(ascii);
                Debug.WriteLine(new string('-', width));
            }
            sw.Stop();
            Debug.WriteLine($"Generated ASCII art collection in {sw.Elapsed.TotalSeconds}s");
            Debug.WriteLine(new string('=', width));
        }

        [TestMethod]
        public void TestHeroPix()
        {
            PrintAllImages(GetFilesInFolder("heroes"));
        }

        [TestMethod]
        public void TestNaturePix()
        {
            PrintAllImages(GetFilesInFolder("nature"));
        }

        [TestMethod]
        public void TestThingsPix()
        {
            PrintAllImages(GetFilesInFolder("things"));
        }
    }
}