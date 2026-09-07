using System;

namespace CurrencyTempConverter
{
    class CurrencyConverter
    {
        public static void ConvertCurrency()
        {
            Console.WriteLine(
                "Please enter If you want to convert to USD or ZAR, Press U for USD and Z for ZAR:"
            );
            string unit = Console.ReadLine();
            unit = unit.ToUpper(); //convert to uppercase to avoid case sensitivity
            if (unit == "U")
            {
                Console.WriteLine("Please enter the amount in ZAR:");
                double amount = double.Parse(Console.ReadLine());
                double usd = ConvertToUSD(amount);
                Console.WriteLine($"{amount} ZAR is {usd} USD");
            }
            else if (unit == "Z")
            {
                Console.WriteLine("Please enter the amount in USD:");
                double amount = double.Parse(Console.ReadLine());
                double zar = ConvertToZAR(amount);
                Console.WriteLine($"{amount} USD is {zar} ZAR");
            }
        }

        public static double ConvertToUSD(double amount)
        {
            return amount / 15.96;
        }

        public static double ConvertToZAR(double amount)
        {
            return amount * 15.96;
        }
    }

    class TemperatureConverter
    {
        public static void ConvertTemperature()
        {
            Console.WriteLine(
                "Please enter the temperature you want to convert to. C for Celsius, F for Fahrenheit:"
            );
            string unit = Console.ReadLine();
            unit = unit.ToUpper(); //convert to uppercase to avoid case sensitivity
            if (unit == "C")
            {
                Console.WriteLine("Please enter the temperature in Celsius:");
                double temperature = double.Parse(Console.ReadLine());

                double fahrenheit = ConvertToFahrenheit(temperature);
                Console.WriteLine($"{temperature}°C is {fahrenheit}°F");
            }
            else if (unit == "F")
            {
                Console.WriteLine("Please enter the temperature in Fahrenheit:");
                double temperature = double.Parse(Console.ReadLine());

                double celsius = ConvertToCelsius(temperature);
                Console.WriteLine($"{temperature}°F is {celsius}°C");
            }
        }

        public static double ConvertToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }

        public static double ConvertToFahrenheit(double temperature)
        {
            return (temperature * 9 / 5) + 32;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Welcome to the Currency and Temperature Converter");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Currency Converter");
                Console.WriteLine("2. Temperature Converter");
                Console.WriteLine("3. Exit");
                Console.WriteLine("--------------------------------");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CurrencyConverter.ConvertCurrency();
                        break;
                    case 2:
                        TemperatureConverter.ConvertTemperature();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 3);
        }
    }
}
