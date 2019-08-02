using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Alturos.Yolo;
using System.Diagnostics;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Image image = Image.FromFile(@"D:\Visual Project\Alturos.Yolo-master\Images\Bird1.png");
            string path = Directory.GetCurrentDirectory();
            string target = @"D:\Visual Studio 2017\Projects\Alturos.Yolo-master\Images\Bird1.png";
            if (File.Exists(target))
            {
                var configurationDetector = new ConfigurationDetector();
                var config = configurationDetector.Detect();
                using (var yoloWrapper = new YoloWrapper(config))
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var items = yoloWrapper.Detect(target);
                    Console.Write("\n \tNumber of Object Detected: " + items.Count().ToString()+"\n");
                    Console.Write("\n \tIt took " + sw.Elapsed.TotalSeconds + "  seconds to detect the objects in the image.\n");
                    foreach(Alturos.Yolo.Model.YoloItem s in items)
                    {
                        Console.Write("\t\t\n\tObjects Found: "+s.Type.ToString() + "   ");
                        Console.Write("X: " +s.X.ToString() + "   ");
                        Console.Write("Y: " + s.Y.ToString() + "   ");
                        Console.Write("Width: " + s.Width.ToString()+"   ");
                        Console.Write("Height: " + s.Height.ToString() + "\n");


                    }

                    sw.Stop();
                }
            }
            else
            {
                Console.Write("NO");
            }
            Console.ReadKey();
        }
    }
}