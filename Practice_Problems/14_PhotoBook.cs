using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
Create a C# program to manage a photo book using OOPs.

To start, create a class called PhotoBook.  It must also have a public method GetNumberPages that 
will return the number of photo book pages.

The default constructor will create an album with 16 pages. There will be an additional 
constructor, with which we can specify the number of pages we want in the album.

There is also a AddPhotoBook class whose constructor will create an album with 64 pages.

Finally create a PhotoBookTest class to perform the following actions:

Create a default photo book and show the number of pages
Create a photo book with 32 pages and show the number of pages
Create a large photo book and show the number of pages
 */
namespace Practice_Problems
{
    public class PhotoBook
    {
        int Album_pages;
        //default constructor
        public PhotoBook() {
            Album_pages = 16;
        }
        //parameterized constructor
        public PhotoBook(int Album_pages)
        {
            this.Album_pages = Album_pages;
        }

        public int photoBookPages()
        {
            return Album_pages;
        }
    }
    //inheritance
    public class AddPhotoBook: PhotoBook
    {
        int Album_pages;
        public AddPhotoBook() : base(64) { }
 
    }
    public class PhotoBookTest
    {
        public static void Main(string[] args)
        {
            int result;
            //Create a default photo book and show the number of pages
            PhotoBook defaultBook = new PhotoBook();
            result=defaultBook.photoBookPages();
            Console.WriteLine(result);
            //Create a photo book with 32 pages and show the number of pages
            PhotoBook customBook = new PhotoBook(32);
            result = customBook.photoBookPages();
            Console.WriteLine(result);
            //Create a large photo book and show the number of pages
            AddPhotoBook largeBook = new AddPhotoBook();
            result = largeBook.photoBookPages();
            Console.WriteLine(result);

        }

    }
}

