using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerApp
{
    public class FileManager
    {
        IFileManagerExtension exmanager;
        ILog logger;
        public FileManager()
        {

        }
        public FileManager(IFileManagerExtension ex,ILog log)  //UnitTest yazabilmek icin construct
        {
            exmanager = ex;
            logger = log;
        }
        public bool IsSupportedFileName(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException();

            if (filename.Length < 8)
            {
                return true;
            }
            else
                return false;
        }

        public void WriteFile(string dosyadi)
        {
            //dosyaya yaziyor.
            if(IsSupportedFileName(dosyadi))
            {
                try
                {
                    //File.Create("\\" + dosyadi); //External Dependency
                    //IFileManagerExtension ex = new FileManagerExtension();
                    exmanager.DosyaYarat(dosyadi);
                    //Eger yaratilmadiysa 
                }
                catch (Exception ex)
                {
                    //Logger lg = new Logger();
                    logger.LogGonder("v");
                }

            }
            else
            {
                Logger lg = new Logger();
                lg.LogGonder("dosyadibuyuk");
            }
        }
    }
    public interface ILog
    {
        void LogGonder(string mesaj);
    }
    public class Logger :ILog
    {
        public void LogGonder(string mesaj)
        {
            //
        }

    }

    public interface IFileManagerExtension
    {
        void DosyaYarat(string dosyaisim);
    }
    public class FileManagerExtension:IFileManagerExtension
    {
        public void DosyaYarat(string dosyaisim)
        {
            File.Create("\\" + dosyaisim);
        }
    }
}
