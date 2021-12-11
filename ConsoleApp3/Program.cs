using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp3
{
    struct User
    {
        public int x;
        public int y;
        public DateTime time;
        public override string ToString()
        {
            return x + " " + y + " " + time;
        }
    }
    class Program
    {
        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("X:/Doc.csv"))
            {
                //цикл пока не достигли конца файла
                while (sr.EndOfStream != true)
                {
                    //помещаем строку из файла в строковый массив по разделителю, принятому в csv
                    string[] str = sr.ReadLine().Split(';');
                    //помещаем в элемент списка новую структуру типа User
                    users.Add(new User() { x = Convert.ToInt32(str[0]), y = Convert.ToInt32(str[1]), time = Convert.ToDateTime(str[2])});
                }
            }
            Console.Write("Введите начало временного промежутка ");
            DateTime n = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите конец временного промежутка ");
            DateTime k = Convert.ToDateTime(Console.ReadLine());
            foreach (User u in users)
            {
                if(u.time > n && u.time < k)
                {
                    Console.WriteLine(u);
                }
            }
            Console.ReadKey();
        }
    }
}