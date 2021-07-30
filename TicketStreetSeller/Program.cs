using System;
using System.Collections.Generic;

namespace TicketStreetSeller
{
    class Program
    {
        public static int[] ticketArray = new int[] { 0};
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
                MenuChoice(GetUserInput());
                
            }
        }
        public static void Menu()
        {
            Console.WriteLine("Все в маршрутку! Доступные номера седушек: 1 - 9, хотите другое место? Рандом в помощь!");
            Console.WriteLine("Действия:\n");
            Console.WriteLine("Купить билет с выбором места     - 1\n");
            Console.WriteLine("Купить билет на случайное место  - 2\n");
            Console.WriteLine("Отменить покупку билета на место - 3\n");
            Console.WriteLine("");
            Console.WriteLine("Занятые места: \n");
            PrintTicketArray(ticketArray);
        }
        private static void MenuChoice(int a)
        {
            Console.WriteLine("Вы выбрали: {0}", a);
            switch (a)
            {
                case 1:
                    Console.WriteLine("Купить билет с выбором места - 1\n");
                    ticketArray = BuyTicket(ticketArray);
                    break;
                case 2:
                    Console.WriteLine("Купить билет на случайное место - 2\n");
                    ticketArray = BuyRandomTicket(ticketArray);
                    break;
                case 3:
                    Console.WriteLine("Отменить покупку билета на место - 3\n");
                    ticketArray = CancelTicket(ticketArray);
                    break;
                default:
                    break;
            }
        }
        public static int GetUserInput()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            int a;
            if (int.TryParse(info.KeyChar.ToString(), out a))
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали: " + a.ToString());
            }
            return a;
        }
        public static int[] BuyTicket(int[]  ticketArray)
        {
            int placeNum = GetUserInput(); // выбрали место
            int[] bufferArray = Add(ticketArray, placeNum);
            return bufferArray;
        }
        public static int[] BuyRandomTicket(int[] ticketArray)
        {
            
            int[] bufferArray = RandAdd(ticketArray);
            return bufferArray;
        }

        public static T[] RandAdd<T>(T[] array)
        {
            T[] returnarray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                returnarray[i] = array[i];
            }
            var rnd = new Random();
            T value = (T)(object)rnd.Next(1, 9);
            returnarray[array.Length] = value;
            return returnarray;
        }

        public static int[] CancelTicket(int[] ticketArray)
        {
            int placeNum = GetUserInput();
            int[] bufferArray = Rem(ticketArray, placeNum);
            return bufferArray;
        }
        public static T[] Add<T>(T[] array, T item) // добавляем в массив. я в ахуе, возможно есть способ удобнее
        {
            T[] returnarray = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                returnarray[i] = array[i];
            }
            returnarray[array.Length] = item;
            return returnarray;
        }
        public static void PrintTicketArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write("{0} ",item);
            }
        }
        public static T[] Rem<T>(T[] original, T itemToRemove)
        {
            int numIdx = System.Array.IndexOf(original, itemToRemove);
            if (numIdx == -1) return original;
            List<T> tmp = new List<T>(original);
            tmp.Remove(itemToRemove);
            return tmp.ToArray();
        }
    }
}
