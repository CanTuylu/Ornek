using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileManagerApp.UnitTests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSupportedFileName_FileNameIsNull_HataVer()
        {
            FileManager fm = new FileManager();
            fm.IsSupportedFileName(null);
        }
        [TestMethod]
        public void IsSupportedFileName_FileNameIsLessThen8_ReturnTrue()
        {
            FileManager m = new FileManager();
            bool ret= m.IsSupportedFileName("abc");
            Assert.AreEqual(ret, true);
        }
        [TestMethod]
        public void IsSupportedFileName_FileNameIsMoreThen8_ReturnFalse()
        {
            FileManager m = new FileManager();
            bool ret = m.IsSupportedFileName("abcdefeafewaf");
            Assert.AreEqual(ret, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteFile_FileNameIsNull_Throw()
        {
            FileManager fm = new FileManager();
            fm.WriteFile(null);
        }

        [TestMethod]
        public void WriteFile_FileCreateThrows_CallLogGonder()
        {
            LoggerStub lstub = new LoggerStub();
          
            FileManager mn = new FileManager(new FileManagerExtensionStub(),lstub);
            mn.WriteFile("abc");
            //exception firlatti cunku simule ettim.
            //Simdi LogGonderMetodu calısıp calısmadıgını kontrol edebilirim.
            //Assert.AreEqual()
            StringAssert.Contains("dosyayaratilamadi", lstub.message);
        }
    }

    //HandwriteStub.
    public class FileManagerExtensionStub : IFileManagerExtension
    {
        public void DosyaYarat(string dosyaisim)
        {
            throw new Exception(); //Hatayi simule ediyorum.
        }
    }
    public class LoggerStub : ILog
    {
        public string message;
        public void LogGonder(string mesaj)
        {
            message = mesaj;
        }
    }

    //Referanslar
    //Art of Unit Testing in .net
    //Working with Legacy Code
    
}
