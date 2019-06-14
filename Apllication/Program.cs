using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileManager App kullan.
            string dosyaadi = Console.ReadLine();

            FileManagerApp.FileManager fm = new FileManagerApp.FileManager();
            fm.WriteFile(dosyaadi);

        }
    }
}
