using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//агрегированием (или как его еще называют - делегированием) подразумевают методику создания нового класса из уже существующих классов путём их включения.

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] year = { "January", "February",
                        "March", "April",
                        "May", "June",
                        "July", "August",
                        "September", "October",
                        "November", "December" };

            Console.WriteLine("first task\n");

            Console.Write("Введите количество букв в названии месяца: "); //последовательность месяцев с длиной строки равной n

            int n = Convert.ToInt32(Console.ReadLine());

            var request_1 = from m in year
                            where m.Length == n
                            select m;

            foreach (var item in request_1)
                Console.WriteLine(item);

            IEnumerable<string> summer = year.Skip(5).Take(3); //запрос возвращающий только летние и зимние месяцы

            Console.WriteLine("\nЛетние месяцы:");
            foreach (var item in summer)
                Console.WriteLine(item);

            IEnumerable<string> winter = year.Take(2).Concat(year.Skip(11));

            Console.WriteLine("\nЗимние месяцы:");
            foreach (var item in winter)
                Console.WriteLine(item);

            Console.WriteLine("\nМесяцы в алфавитном порядке:"); //запрос вывода месяцев в алфавитном порядке

            var abc = from a in year
                      orderby a  //сортирует по возрастанию
                      select a;

            foreach (var item in abc)
                Console.WriteLine(item);

            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х
            Console.WriteLine("\nМесяцы содержащие букву «u» и длиной имени не менее 4-х");

            var sort = from s in year
                       where s.Contains('u') == true
                       where s.Length > 4
                       select s;

            foreach (var item in sort)
                Console.WriteLine(item);

            Console.WriteLine("================================================");


            List<Book> books = new List<Book>();

            Book book1 = new Book("Botanic", 2000, "FallingLeaf", "Orange");
            Book book2 = new Book("Devil", 2000, "WearsPrada", "White");
            Book book3 = new Book("ShoesOfGlass", 2000, "AgrassiveApe", "Green");
            Book book4 = new Book("HowToDieGracefully", 2009, "PeasefullLorena", "Cyan");
            Book book5 = new Book("TinSoldier", 1995, "PassiveApp", "Orange");

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);

            foreach (var i in books)
            {
                i.Info();
            }

            IEnumerable<Book> SkipBooks = books.Skip(1).Take(1).Concat(books.Skip(3).Take(1)); //Вывести вторую и предпоследнюю книги

            Console.WriteLine("\nВывести вторую и предпоследнюю книги:");
            foreach (var item in SkipBooks)
                item.Info();

            var BookNameSymbol = from i in books //Первая книга, содердащая символ 'о', но не содержит 'i' в названии
                                 where i.Name.Contains('o') == true && i.Name.Contains('i') == false
                                 select i;
            Console.WriteLine("\nПервая книга, которая содержит символ 'о', но не содержит 'i' в названии: ");
            foreach (Book i in BookNameSymbol)
            {
                i.Info();
                break;
            }

            var BookYearSpecific = from i in books //Количество книг заданного года выпуска
                                   where i.Year == 2000
                               select i;
            Console.Write("\nКоличество книг 2000 года выпуска: ");
            int counter=0;
            foreach (Book i in BookYearSpecific)
            {
                counter++;
            }
            Console.WriteLine(counter);

            var BookYearSort = from i in books //сортирует в порядке убывания года
                               orderby i.Year descending
                               select i;
            Console.WriteLine("\nВ порядке убывания года:");
            foreach (Book i in BookYearSort)
            {
                i.Info();
            }


            var BookNameSort = from i in books //сортирует по названию в алфавитном порядке
                               orderby i.Name
                               select i;
            Console.WriteLine("\nВ алфавитном порядке:");
            foreach (Book i in BookNameSort)
            {
                i.Info();
            }
            Console.WriteLine("================================================");
            var BookNameSort1 = from i in books
                                where i.Name.Contains('o') == true //квантор
                                where i.Year > 1999//условие
                                orderby i.Name //упорядочивание
                               select i;//проекция

            Console.WriteLine("\nЗапрос с 5 операторами:");
           
            foreach (Book i in BookNameSort1.Skip(1))//разбиение
            {
                i.Info();
            }


            Console.WriteLine("================================================");
            string[] names = { "Полька", "Маша", "Юля", "Глаша" }; //Join
            int[] key = { 1, 4, 5, 7 };
            var sometype = names
            .Join(
            key, // внутренняя
            w => w.Length, // внешний ключ выбора
            q => q, // внутренний ключ выбора
            (q, w) => new // результат
{
                id = w,
                name = string.Format("{0} ", q),
            });
            foreach (var item in sometype)
                Console.WriteLine(item);
       
        }
    }

   
    public class Book
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Izdat { get; set; }
        public string Color { get; set; }
        public Book(string Name, int Year, string Izdat, string Color)
        {
            this.Name = Name;
            this.Year = Year;
            this.Izdat = Izdat;
            this.Color = Color;
        }
        virtual public void Info()
        {
            Console.WriteLine("Название:" + Name);
            Console.WriteLine("Год:" + Year);
            Console.WriteLine("Издательство:" + Izdat);
            Console.WriteLine("Цвет:" + Color);
            Console.WriteLine();
        }
    }
}
