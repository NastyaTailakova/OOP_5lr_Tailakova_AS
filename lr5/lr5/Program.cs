using System;

namespace lr5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("Введите первое число:");
            double number1 = ReadNumber(); // Обработка исключения для ввода первого числа

            Console.WriteLine("Введите оператор (+, -, *, /):");
            char operatorChar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.WriteLine("Введите второе число:");
            double number2 = ReadNumber(); // Обработка исключения для ввода второго числа

            try
            {
                double result = Calculate(number1, number2, operatorChar); // Попытка выполнить вычисление
                Console.WriteLine($"Результат: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: Деление на ноль недопустимо."); // Обработка ошибки деления на ноль
            }
            catch (InvalidOperationException e) // Обработка ошибки невалидной операции
            {
                Console.WriteLine($"Ошибка: {e.Message}"); 
            }
            catch (Exception e) // Обработка любой другой неизвестной ошибки
            {
                Console.WriteLine($"Неизвестная ошибка: {e.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double ReadNumber() // Метод для чтения и обработки ввода чисел с исключениями
        {
            while (true)
            {
                string input = Console.ReadLine(); // Читаем ввод пользователя
                if (double.TryParse(input, out double number)) // Проверяем, можно ли преобразовать ввод в число типа double
                {
                    return number; // Возвращаем число, если преобразование успешно
                }
                Console.WriteLine("Неверный формат. Пожалуйста, введите число:"); 
            }
        }

        static double Calculate(double number1, double number2, char operatorChar)
        {
            switch (operatorChar) // Используем оператор switch для определения действия в зависимости от оператора
            {
                case '+':
                    return number1 + number2;
                case '-':
                    return number1 - number2;
                case '*':
                    return number1 * number2;
                case '/':
                    if (number2 == 0) // Проверка на деление на ноль перед выполнением операции
                    {
                        throw new DivideByZeroException(); // Генерируем исключение, если деление на ноль
                    }
                    return number1 / number2;
                default:
                    throw new InvalidOperationException("Недопустимый оператор."); // Генерируем исключение для недопустимого оператора
            }
        }
    }
}
