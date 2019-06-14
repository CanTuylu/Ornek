using System;
using FileManagerApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
//MOCK Nedir
namespace UsingFramework.UnitTests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void WriteFile_FileCreateThrows_CallLogGonder()
        {
            var stub = Substitute.For<IFileManagerExtension>();
            var mock = Substitute.For<ILog>();

            FileManager fm = new FileManager(stub, mock);
            stub.When(x => x.DosyaYarat(Arg.Any<string>())).Do(
                r => { throw new Exception(); }
                );

            fm.WriteFile("abc");

            //devam.
            //LogGonder metodu cagiriliyomu cagrilmiyormu?

            //Stublar testi fail etmezken.
            //Mocklar edebilir.
            mock.Received().LogGonder("v");
        }
    }
}
