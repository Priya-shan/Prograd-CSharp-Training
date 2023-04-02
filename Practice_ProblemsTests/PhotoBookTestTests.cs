using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Problems.Tests
    //testibf
{
    [TestClass()]
    public class PhotoBookTestTests
    {
        [TestMethod()]
        public void TestDefaultPages()
        {
            PhotoBook book = new PhotoBook();
            Assert.AreEqual(book.photoBookPages(), 16);
        }
        [TestMethod()]
        public void Test32Pages()
        {
            PhotoBook book = new PhotoBook(32);
            Assert.AreEqual(book.photoBookPages(), 32);
        }
        [TestMethod()]
        public void Test64Pages()
        {
            
            AddPhotoBook book = new AddPhotoBook();
            Assert.AreEqual(book.photoBookPages(), 64);
        }
    }
}