using System;

namespace Program
{
    internal class Program
    {
        // cart
        public static Dictionary<int, string> CART = new Dictionary<int, string>();
        public static Dictionary<int, int> CART_PRICE = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            string NAME = "Sussy cafe for incels and maids, not Falkman";

            // menu choices
            string[] menu = { "Cart", "Varmeretter", "Sandwich", "Drikkevarer" };
            int[] menu_price = { 0, 0, 0, 0 };

            // foods & prices
            string[] varmeretter = { "Varm Kebab", "Varm Sandwich", "Varmt Vand" };
            int[] varmeretter_price = { 20, 15, 35 };

            string[] sandwich = { "Sandwich med bacon og karry", "Sandwich med skinke og ost", "Sandwich med sovs :)" };
            int[] sandwich_price = { 30, 25, 99 };

            string[] drikkevarer = { "Mælk", "Mælk igen", "MILK!", "I LUV MILK <3" };
            int[] drikkevarer_price = { 10, 15, 20, 1000000 };

            string menu_choice = "";
            while (menu_choice != "Error") // if AutoMenu() coundn't covert to num
            {
                Console.WriteLine($"Hello, welcome to {NAME}, order your kebab...");

                // call method that displays items
                // returns "Error" if it couldn't convert to num
                menu_choice = AutoMenu(menu, menu_price, false);

                // show choice sub menu and add to cart
                switch (menu_choice)
                {
                    case "Varmeretter":
                        AddToCart(varmeretter, varmeretter_price);
                        break;
                    case "Sandwich":
                        AddToCart(sandwich, sandwich_price);
                        break;
                    case "Drikkevarer":
                        AddToCart(drikkevarer, drikkevarer_price);
                        break;
                    case "Cart":
                        ShowCart();
                        break;
                    default:
                        Console.WriteLine("Not an option, be careful, i might open paint.exe :)");
                        break;
                }
            }
        }
        static string AutoMenu(string[] names, int[] prices, bool showPrice)
        {
            Console.Clear();

            // show options like this => 1. Food Name,  Price: 20
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}{(showPrice ? $",\tPrice: {prices[i]}" : "")}"); // ternary in string interpolation
            }

            // get choosen item
            string choice = Console.ReadLine();

            // try to convert to num
            int choice_num;
            bool choice_bool = int.TryParse(choice, out choice_num);
            if (!choice_bool)
            {
                return "Error";
            }

            // return the choosen item
            return $"{names[choice_num - 1]}";
        }
        static void AddToCart(
            string[] names,
            int[] prices
            )
        {
            Console.Clear();

            // add name to name dict
            string food_choice = AutoMenu(names, prices, true);
            CART.Add(CART.Count + 1, $"{food_choice}");

            // add price to price dict
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == food_choice)
                {
                    CART_PRICE.Add(CART_PRICE.Count + 1, prices[i]);
                }
            }
            Console.Clear();
        }
        static void ShowCart()
        {
            Console.Clear();

            // show items added to cart
            Console.WriteLine("ADDED TO CART:");
            for (int i = 1; i <= CART.Count; i++)
            {
                Console.WriteLine($"{i}. {CART[i]},\tPrice: {CART_PRICE[i]}");
            }
            Console.WriteLine("99. Exit Cart");

            // calculate total price & and show it
            int total = 0;
            for (int i = 0; i < CART_PRICE.Count; i++)
            {
                total += CART_PRICE[i + 1];
            }
            Console.WriteLine($"\nTotal Price: {total}");

            // lets user exit
            string choice = Console.ReadLine();
            if (choice != "99")
            {
                ShowCart();
            }
        }
    }
}