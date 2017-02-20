using System;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string author;//Ivo 4ndonov
        private string title;
        private decimal price;
        
        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            protected set
            {
                if (value.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length>1
                    && char.IsDigit(value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }
        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strbuild = new StringBuilder();
            strbuild.Append("Type: ").Append(this.GetType().Name)
                .Append(Environment.NewLine)
                .Append("Title: ").Append(this.Title)
                 .Append(Environment.NewLine)
                 .Append("Author: ").Append(this.Author)
                 .Append(Environment.NewLine)
                 .Append("Price: ").Append(this.Price)
                 .Append(Environment.NewLine);
            return strbuild.ToString();
        }
    }
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
        }

        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }
    }
    class BookShop
    {
        static void Main(string[] args)
        {
            try
            {
                string author = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());

                Book book = new Book(author, title, price);
                GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenEditionBook);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
