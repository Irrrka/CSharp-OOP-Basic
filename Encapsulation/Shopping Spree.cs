using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr_4
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> basketOfProducts;
        public Person() { }
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.basketOfProducts = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException($"{nameof(this.Name)} cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException($"{nameof(this.Money)} cannot be negative");
                }
                this.money = value;
            }
        }
        public void BuyProduct(Product product)
        {
            if (product.Cost<=this.Money)
            {
                this.Money--;
                basketOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else if (product.Cost>this.Money)
            {
                throw new InvalidOperationException(
                    $"{this.Name} can't afford {product.Name}");
            }

        }

        public void DisplayPersonProducts()
        {
            if (this.basketOfProducts.Count>0)
            {
                Console.WriteLine($"{this.Name} - {string.Join(", ", this.basketOfProducts)}");
            }
            else
            {
                Console.WriteLine($"{this.Name} - Nothing bought");
            }
        }
    }
    public class Product
    {
        private string name;
        private decimal cost;
        public Product() { }
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

            public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArithmeticException($"{nameof(Name)} cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                if (value <0)
                {
                    throw new ArithmeticException($"Money cannot be negative");
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleTokens = Console.ReadLine().Split(';');
            string[] productsTokens = Console.ReadLine().Split(';');

            Person person = new Person();
            List<Person> people = new List<Person>();

            Product product = new Product();
            List<Product> products = new List<Product>();

            foreach (var per in peopleTokens)
            {
                string[] personCash = per.Split('=');
                string name = personCash[0];
                decimal cash = decimal.Parse(personCash[1]);
                try
                {
                    person = new Person(name, cash);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                    throw;
                }
            }

            foreach (var pro in productsTokens)
            {
                string[] foodInfo = pro.Split('=');
                string foodName = foodInfo[0];
                decimal foodPrice = decimal.Parse(foodInfo[1]);
                try
                {
                    product = new Product(foodName, foodPrice);
                    products.Add(product);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split();
                string personName = inputArgs[0];
                string productName = inputArgs[1];

                Person ourPerson = people.First(x => x.Name == personName);
                Product productToBuy = products.First(x => x.Name == productName);

                ourPerson.BuyProduct(productToBuy);
            }
            foreach (var per in people)
            {
                person.DisplayPersonProducts();
            }
        }
    }
}
