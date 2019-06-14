using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStupTanim
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Fake Yada Stub lar testi fail etmez. Sadece testing devam etmesini sağlar. Testin devam etmesini ve test edeceğim yere bağlılıktan koparmak için fake yada stub oluştururum.
             */
            //Kontrolumuzun dışında. Bknz txt tanimi
            //FileManager fm = new FileManager(new FileWriter());
            //fm.IsSupportedFile("abc.txt");
            var fmanager = new FManager();
            if (fmanager.DosyaVarmi()/*File.Exists("")*/)
                Console.WriteLine("var");//Baska class is yaptir
            else
                Console.WriteLine("yok");
        }
    }

    interface IFile
    {
        bool DosyaVarmi();
    }

    class FManager : IFile
    {
        public bool DosyaVarmi()
        {
            return File.Exists("");
        }
    }








    class FileManager
    {
        IWriter wr;
        public FileManager(IWriter writer)
        {
            wr = writer;
        }
        public void IsSupportedFile(string filename)
        {
            //dosya ismi 8 den buyuk degilse,true destekliyor, buyukse desteklemiyor false

            if (filename.Length < 8)
            {
                //mesage gondersin.
                //Dosyayi diske yazsin, dosya olustursun
                //? Hata oluşabilir.
                //Hata oluşursa admine mail atsın.
                try
                {
                    wr.CreateFile(filename);
                    //FileWriter fl = new FileWriter();
                    //fl.CreateFile(filename);
                    //Bunun icin bir stub yada fake yapmam lazim ve hata döndürmesi lazım.
                }
                catch(Exception ex)
                {
                    MailSender ms = new MailSender();
                    ms.SendMail("admin", "hata");
                }

            }
            else
            {
               //log yapsin. dosyaformati uygun degil.
            }
        }
    }
    interface IWriter
    {
        void CreateFile(string filename);
    }
    class FileWriter:IWriter
    {
        public void CreateFile(string filename)
        {
            File.CreateText(@"\\" + filename);
        }
    }
    class FakeWriter : IWriter
    {
        public void CreateFile(string filename)
        {
            throw new Exception();
        }
    }

    class MailSender
    {
        public void SendMail(string to,string body)
        {
            //to , body.
        }
    }
}
