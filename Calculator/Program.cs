namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Калькулятор";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1 - Сложение");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                Console.WriteLine("5 - Возведение в степень");
                Console.WriteLine("6 - Квадратный корень");
                Console.WriteLine();

                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                double a = 0, b = 0, result = 0;

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                {
                    Console.WriteLine("Ошибка: неизвестная операция!");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey(); 
                    continue; 
                }

                a = ReadNumber("Введите первое число: ");

                if (choice != "6")
                {
                    b = ReadNumber("Введите второе число: ");
                }

                switch (choice)
                {
                    case "1":
                        result = a + b;
                        break;

                    case "2":
                        result = a - b;
                        break;

                    case "3":
                        result = a * b;
                        break;

                    case "4":
                        if (b == 0)
                        {
                            Console.WriteLine("Ошибка: деление на ноль!");
                            AskToContinue();
                            continue;
                        }
                        result = a / b;
                        break;

                    case "5":
                        result = Math.Pow(a, b);
                        break;

                    case "6":
                        if (a < 0)
                        {
                            Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа!");
                            AskToContinue();
                            continue;
                        }
                        result = Math.Sqrt(a);
                        break;
                }
                Console.WriteLine($"Результат: {result}");
                AskToContinue();
            }
        }

        // Метод для безопасного ввода чисел
        static double ReadNumber(string message)
        {
            double number;
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Ошибка: введено не число! Попробуйте снова.");
                }
            }
        }

        // Отдельный метод для повторного запуска
        static void AskToContinue()
        {
            Console.WriteLine();
            Console.Write("Хотите выполнить новую операцию? (y/n): ");
            string answer = Console.ReadLine().ToLower();
            if (answer != "y")
            {
                Console.WriteLine("Программа завершена.");
                Environment.Exit(0);
            }

        }
    }
}
