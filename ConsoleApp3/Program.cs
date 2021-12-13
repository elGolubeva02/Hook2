using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

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
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Console.WriteLine("Width: {0}, Height: {1}", resolution.Width, resolution.Height);
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;

            using (StreamReader sr = new StreamReader("X:/Doc.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] str = sr.ReadLine().Split(';');
                    users.Add(new User() { x = Convert.ToInt32(str[0]), y = Convert.ToInt32(str[1]), time = Convert.ToDateTime(str[2]) });
                }
            }
            Console.Write("Введите начало временного промежутка ");
            DateTime n = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Введите конец временного промежутка ");
            DateTime k = Convert.ToDateTime(Console.ReadLine());
            foreach (User u in users)
            {
                if (u.time > n && u.time < k)
                {
                    if (u.y < (resolution.Height) / 4)
                    {
                        count1 = count1 + 1;//отвечает за ворд
                    }
                    else if (u.x < (resolution.Width) / 4)
                    {
                        count2 = count2 + 1;//отвечает за соц сети
                    }
                    else if ((u.y > ((resolution.Height) / 4) * 2))
                    {
                        count3 = count3 + 1;//отвечает за мессенджеры
                    }
                    else if ((u.x > (resolution.Width) / 5 * 2) && (u.x < (resolution.Width) / 5 * 3) && (u.y > (resolution.Height) / 5 * 2) && (u.y < (resolution.Height) / 5 * 3))
                    {
                        count4 = count4 + 1;//отвечает за игры
                    }
                    else if ((u.y < (resolution.Width) / 4) && (u.y > (resolution.Width) / 4 * 3))
                    {
                        count5 = count5 + 1;//отвечает за БД
                    }
                }
            }
            int[] nums2 = new int[5] {count1, count2, count3, count4, count5};
            Array.Sort(nums2);
            if(nums2[4]==count1)
            {
                Console.WriteLine("Вероятно, сотрудник большинство времени работал в Word");
            }
            else if(nums2[4]==count2)
            {
                Console.WriteLine("Вероятно, сотрудник большинство времени провел в социальных сетях");
            }
            else if (nums2[4] == count2)
            {
                Console.WriteLine("Вероятно, сотрудник большинство времени провел в мессенджерах");
            }
            else if (nums2[4] == count3)
            {
                Console.WriteLine("Вероятно, сотрудник большинство времени провел за игрой");
            }
            else if (nums2[4] == count4)
            {
                Console.WriteLine("Вероятно, сотрудник большинство времени провел в программах Microsoft(БД/Excel)");
            }

            if (nums2[3] == count1)
            {
                Console.WriteLine("Но, возможно, мы ошиблись, и он работал в Word");
            }
            else if (nums2[3] == count2)
            {
                Console.WriteLine("Но, возможно, мы ошиблись, и он провел время в социальных сетях");
            }
            else if (nums2[3] == count2)
            {
                Console.WriteLine("Но, возможно, мы ошиблись, и он провел время в мессенджерах");
            }
            else if (nums2[3] == count3)
            {
                Console.WriteLine("Но, возможно, мы ошиблись, и он провел время за игрой");
            }
            else if (nums2[3] == count4)
            {
                Console.WriteLine("Но, возможно, мы ошиблись, и он провел время в программах Microsoft(БД/Excel)");
            }
            Console.ReadKey();
        }
    }
}