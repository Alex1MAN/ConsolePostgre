namespace ConsolePostgre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitFlag = false;
            while (!exitFlag)
            {
                Console.Clear();
                Console.WriteLine("Действия:");
                Console.WriteLine("1 - получить все записи из БД;");
                Console.WriteLine("2 - найти запись в БД по ID;");
                Console.WriteLine("3 - добавить запись в БД;");
                Console.WriteLine("4 - обновить запись в БД;");
                Console.WriteLine("5 - удалить запись в БД;");
                Console.WriteLine("6 - выйти из приложения.");
                Console.Write("\nВыберите нужный пункт: ");
                int iUserChoice = Convert.ToInt32(Console.ReadLine());

                switch (iUserChoice)
                {
                    case 1:
                        using (DatabaseContextClass db = new DatabaseContextClass())
                        {
                            var products = db.Products.ToList();
                            Console.WriteLine("\nID\tName\t\tPrice\tQuantity\tDescription");
                            Console.WriteLine("------------------------------------------------------------");
                            foreach (Product p in products)
                            {
                                Console.WriteLine($"{p.ID}\t{p.Name}\t{p.Price}\t{p.Quantity}\t\t{p.Description}");
                            }
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню...");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("\nВведите ID для поиска: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        
                        using (DatabaseContextClass db = new DatabaseContextClass())
                        {
                            var products = db.Products.ToList();
                            var product = products.FirstOrDefault(p => p.ID == id);

                            if (product == null)
                                Console.WriteLine("\nТакой продукт по ID не найден!");
                            else
                            {
                                Console.WriteLine("\nID\tName\t\tPrice\tQuantity\tDescription");
                                Console.WriteLine("------------------------------------------------------------");
                                Console.WriteLine($"{product.ID}\t{product.Name}\t{product.Price}\t{product.Quantity}\t\t{product.Description}");
                            }
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню...");
                        Console.ReadKey();
                        break;
                        
                    case 3:
                        using (DatabaseContextClass db = new DatabaseContextClass())
                        {
                            var products = db.Products.ToList();
                            int NextProductID = products.Count() == 0 ? 1 : products.Max(x => x.ID) + 1;

                            Console.Write("Название нового продукта: ");
                            string newName = Console.ReadLine().ToString();
                            Console.Write("Цена нового продукта: ");
                            decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Количество нового продукта: ");
                            int newCount = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Описание нового продукта: ");
                            string newDescr = Console.ReadLine().ToString();

                            Product prod = new Product() { ID = NextProductID, Name = newName, Price = newPrice, Quantity = newCount, Description = newDescr };

                            db.Products.Add(prod);
                            db.SaveChanges();
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню...");
                        Console.ReadKey();
                        break;
                        
                    case 4:
                        using (DatabaseContextClass db = new DatabaseContextClass())
                        {
                            var products = db.Products.ToList();
                            Console.WriteLine("\nID\tName\t\tPrice\tQuantity\tDescription");
                            Console.WriteLine("------------------------------------------------------------");
                            foreach (Product p in products)
                            {
                                Console.WriteLine($"{p.ID}\t{p.Name}\t{p.Price}\t{p.Quantity}\t\t{p.Description}");
                            }

                            Console.Write("\nВведите ID записи для её обновления: ");
                            int idUpdate = Convert.ToInt32(Console.ReadLine());
                            var productUpdate = products.FirstOrDefault(p => p.ID == idUpdate);

                            Console.Write("Новое название: ");
                            productUpdate.Name = Console.ReadLine().ToString();
                            Console.Write("Новая цена: ");
                            productUpdate.Price = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Новое количество: ");
                            productUpdate.Quantity = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Новое описание: ");
                            productUpdate.Description = Console.ReadLine().ToString();

                            db.Products.Update(productUpdate);
                            db.SaveChanges();
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню...");
                        Console.ReadKey();
                        break;
                        
                    case 5:
                        using (DatabaseContextClass db = new DatabaseContextClass())
                        {
                            var products = db.Products.ToList();
                            Console.WriteLine("\nID\tName\t\tPrice\tQuantity\tDescription");
                            Console.WriteLine("------------------------------------------------------------");
                            foreach (Product p in products)
                            {
                                Console.WriteLine($"{p.ID}\t{p.Name}\t{p.Price}\t{p.Quantity}\t\t{p.Description}");
                            }

                            Console.Write("\nВведите ID записи для удаления: ");
                            int idDel = Convert.ToInt32(Console.ReadLine());

                            var productDel = products.FirstOrDefault(p => p.ID == idDel);

                            if (productDel == null)
                                Console.WriteLine("\nТакой продукт по ID не найден!");
                            else
                            {
                                db.Products.Remove(productDel);
                                db.SaveChanges();
                            }
                        }

                        Console.WriteLine("\nНажмите любую клавишу для возвращения в меню...");
                        Console.ReadKey();
                        break;
                        
                    case 6:
                        exitFlag = true;
                        break;
                }
            }
        }
    }
}