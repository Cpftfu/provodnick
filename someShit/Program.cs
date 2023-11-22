using System;
using System.Diagnostics;
using System.IO;
using Process = System.Diagnostics.Process;

namespace provod
{
    internal class Nik
    {
        static string shit;
        static int porn = 1;
        static void Main()
        {
            Console.WriteLine("\t хотите анекдот? \n\t ЙЕП или НЕ ЙЕП?");
            var смехуёчки = Console.ReadLine();
            if (смехуёчки == "йеп" || смехуёчки == "ЙЕП")
            {
                Console.WriteLine("=====================================");
                Console.WriteLine("на швейной фабрике произошел взрыв... \n\t * * * * * \n\t * * * * * \n'ебаться в узел' - сказал охранник");
                Console.WriteLine("=====================================");
                Console.WriteLine("а теперь! жмякни пробел пажавуста");
                Console.CursorVisible = false;
                diskInfo();
            }

            else
            {
                Console.WriteLine("ну и ладно, я ушла плакать");
                Console.WriteLine("порадуйте меня, жмякни пробел");
                Console.CursorVisible = false;
                diskInfo();
            }
        }
            private static void diskInfo()
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                var klavisha = Console.ReadKey();
                while (klavisha.Key != ConsoleKey.Enter)
                {
                Console.Clear();
                Console.WriteLine("   ДИСК          ВСЕГО          ЗАНЯТО\n" + "   " + "====================================");
                    foreach (DriveInfo disk in allDrives)
                    {
                        Console.WriteLine("   " + disk.Name + "\t\t" + disk.TotalSize / 1073741824 + " Гб" + "\t\t" + disk.TotalFreeSpace / 1073741824 + " Гб");
                    }

                klavisha = Arrow(klavisha, ref porn);
                }

                Console.Clear();
                shit = allDrives[porn - 2].Name;
                WtfInside();
            }

            static void WtfInside()
            {
            porn = 1;
            Console.WriteLine("\t ИМЕЧКО \t           ЛАСТ ИЗМЕНЕНИЯ \t | F1 создание папочки | F2 создание файлика | F3 удаление \n ========================================================|");
        
            string[] allDirectories = Directory.GetDirectories(shit);
            int govno = 2;
                foreach (string directoryy in allDirectories)
                {
                    string directoryyName = new DirectoryInfo(directoryy).Name;
                    DateTime dateTime = File.GetLastWriteTime(directoryy);

                    Console.Write("   " + directoryyName);
                    Console.SetCursorPosition(35, govno);
                    govno++;
                    Console.WriteLine(dateTime);
                }

            string[] allFailiki = Directory.GetFiles(shit);
                foreach (string failik in allFailiki)
                {
                    string fileName = new FileInfo(failik).Name;
                    DateTime dateTime = File.GetLastWriteTime(failik);

                    Console.Write("   " + fileName);
                    Console.SetCursorPosition(35, govno);
                    govno++;
                    Console.WriteLine(dateTime);
                }

            var klavisha = Console.ReadKey(true);
                while (klavisha.Key != ConsoleKey.Enter)
                {
                    for (int piska = 0; piska < (allFailiki.Length + allDirectories.Length + 2); piska++)
                    {
                        Console.SetCursorPosition(0, piska);
                        Console.Write("   ");
                    }

                klavisha = Arrow(klavisha, ref porn);
                }

            Console.Clear();
                if (porn < allDirectories.Length + 2)
                {
                    shit = allDirectories[porn - 2];
                    WtfInside();
                }
                else
                {
                    Process.Start
                    (
                        new ProcessStartInfo
                        {
                            FileName = allFailiki[porn - (allDirectories.Length + 2)],
                            UseShellExecute = true
                        }
                    );
                }
            }

            private static ConsoleKeyInfo Arrow(ConsoleKeyInfo klavisha, ref int porn)
            {
                switch (klavisha.Key)
                {
                    case ConsoleKey.UpArrow:
                        porn = porn - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        porn = porn + 1;
                        break;
                    case ConsoleKey.Escape:
                        diskInfo();
                        break;
                    case ConsoleKey.F1:
                        AddDirectory();
                        break;
                    case ConsoleKey.F2:
                        AddFailic();
                        break;
                    case ConsoleKey.F3:
                        DeleteThatShit();
                        break;
                    case ConsoleKey.Tab:
                        Console.Clear();
                        Console.WriteLine("программочка закрыта");
                        porn = 5;
                        Environment.Exit(Environment.ExitCode);
                        break;
                }

                Console.SetCursorPosition(0, porn);
                Console.WriteLine(">>");
                klavisha = Console.ReadKey();
                return klavisha;
            }

            static void AddDirectory()
            {
                Console.SetCursorPosition(65, 2);
                Console.WriteLine("названька папочки: \n");
                Console.SetCursorPosition(65, 3);
                string title = Console.ReadLine();
                string siski = shit + "\\" + title;
                Directory.CreateDirectory(siski);
                Console.Clear();
                WtfInside();
            }

            static void AddFailic()
            {
                Console.SetCursorPosition(65, 2);
                Console.WriteLine("названька файлика: \n");
                Console.SetCursorPosition(65, 3);
                string title = Console.ReadLine();
                string siski = shit + "\\" + title;
                File.Create(siski).Close();
                Console.Clear();
                WtfInside();
            }
            static void DeleteThatShit()
            {
                Console.SetCursorPosition(65, 5);
                Console.WriteLine("напифите 'Йеп', если вы ТОЧНО хотите это сделать >^<");
                string otvet = Console.ReadLine();
                if (otvet == "Йеп" || otvet == "йеп")
                {
                    Directory.Delete(shit, true);
                    File.Delete(shit);
                }
            else
            {
                Console.WriteLine("упси..что-то пошло не так!");
            }
            }
        }
    }

