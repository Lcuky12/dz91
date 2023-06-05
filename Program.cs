using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp95
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandProductAddProduct = "1";
            const string CommandShowProducts = "2";
            const string CommandBuyGoods = "3";
            const string CommandShowPlayerBag = "4";
            const string CommandExitProgramm = "5";

            string userInput;
            bool isOpen = true;

            Salesman salesman = new Salesman();
            Player player = new Player(500);


            while (isOpen)
            {
                Console.WriteLine("Добро пожаловать в магазин");

                Console.WriteLine($"{CommandProductAddProduct} - добавить товар");
                Console.WriteLine($"{CommandShowProducts} - показать товары");
                Console.WriteLine($"{CommandBuyGoods} - купить товар");
                Console.WriteLine($"{CommandShowPlayerBag} - показать сумку игрока");
                Console.WriteLine($"{CommandExitProgramm} - выход из программы");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandProductAddProduct:
                        salesman.AddItem();
                        break;

                    case CommandShowProducts:
                        salesman.ShowAllProducts();
                        break;

                    case CommandBuyGoods:
                        salesman.Buy();
                        break;

                    case CommandShowPlayerBag:
                        player.ShowPlayerBag();
                        break;

                    case CommandExitProgramm:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка выбора меню.Выберите подходящие");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }

    class Salesman
    {
        private List<Product> _products = new List<Product>();

        public void ShowAllProducts()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].ShowProducts();
            }
        }

        public void AddItem()
        {
            Console.Write("Пропишите название товара");
            string productName = Console.ReadLine();
            int priceOfProduct = GetPriceOfProduct("Пропишите цену за товар");

            _products.Add(new Product(productName, priceOfProduct));
        }

        private int GetPriceOfProduct(string text)
        {
            Console.Write(text);
            int.TryParse(Console.ReadLine(), out int number);
            return number;
        }

        public void Buy()
        {
            Console.Write("Какой товар хотите купить:");
            string userInput = Console.ReadLine();

        }
    }

    class Player
    {

        private int _money;
        private int _bag;

        public Player( int money)
        {
            _money = money;          
        }

        public void ShowPlayerBag()
        {
            Console.WriteLine($"Денег у игрока - {_money} рублей");
        }

        public int GetMoney()
        {
            return _money;
        }
    }

    class Product
    {
        private string _productName;
        private int _priceOfProduct;

        public Product(string productName, int priceOfProduct)
        {
            _productName = productName;
            _priceOfProduct = priceOfProduct;
        }


        public void ShowProducts()
        {
            Console.WriteLine($"Название товара - {_productName}, цена товара - {_priceOfProduct} рублей");
        }

        public int GetPriceOfProducts()
        {
            return _priceOfProduct;
        }

    }

}
