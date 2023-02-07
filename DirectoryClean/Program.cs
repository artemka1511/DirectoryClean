using System;
using System.IO;

namespace DirectoryClean
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки: ");
            string path = Console.ReadLine();

            try
            {
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);

                    foreach (var item in files)
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        if (DateTime.Now - TimeSpan.FromMinutes(30) > fileInfo.LastWriteTime)
                        {
                            fileInfo.Delete();
                        }
                    }

                    string[] dirs = Directory.GetDirectories(path);

                    foreach (var item in dirs)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(item);
                        if (DateTime.Now - TimeSpan.FromMinutes(30) > directoryInfo.LastWriteTime)
                        {
                            directoryInfo.Delete(true);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: директория не найдена");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Ошибка: " + exception);
            }
        }
    }
}
