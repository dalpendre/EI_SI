using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream originStream = new FileStream("security.jpg", FileMode.Open)) 
            using (FileStream destinationStream = new FileStream("security_copy.jpg", FileMode.Create))
            {
                int bufferSize = 20480;
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0;
                Console.WriteLine("File Copy Start");
                while((bytesRead = originStream.Read(buffer, 0, bufferSize)) > 0) 
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                }
                Console.WriteLine("File Copy End");

                //1b
                using(StreamWriter copies_file = File.AppendText("C:/Users/DIOGOA~1/AppData/Local/Temp/log.txt"))
                {
                    copies_file.WriteLine(buffer.Length);
                }
            }

            Console.ReadKey();
        }
    }
}