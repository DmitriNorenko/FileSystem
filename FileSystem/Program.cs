using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.InteropServices.ComTypes;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Person = new Contact("Иван",89884132486,"Ivan1708@Gmail.com");

            BinaryFormatter f = new BinaryFormatter();
            using (var fs = new FileStream("Person.dat", FileMode.OpenOrCreate))
            {
                f.Serialize(fs, Person);
            }
            using (var fr = new FileStream("Person.dat", FileMode.OpenOrCreate))
            {
                var rf = (Contact)f.Deserialize(fr);
                Console.WriteLine($" Имя: {rf.Name} \n Телефон: {rf.PhoneNumber} \n Почта: {rf.Email}");
            }
            Console.ReadKey();

        }
        [Serializable]
        class Contact
        {
            public string Name { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }

            public Contact(string name, long phoneNumber, string email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
        static void SwapFolder()
        {
            DirectoryInfo dir = new DirectoryInfo("/Users/dima/Desktop/TestFolder");
            string newDir = "/$Recycle.Bin/TestFolder";
            if (dir.Exists && !Directory.Exists(newDir))
            {
                dir.MoveTo(newDir);
            }
        }

        static void GetCatalogs()
        {
            int numFiles = 0;
            string dirName = "C://";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                    numFiles++;
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                    numFiles++;
                }
            }
            Console.WriteLine("Всего папок и файлов: {0}", numFiles);
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory("8)");
            dirInfo.Delete(true);
        }

        class FileSystem
        {
            public string _name { get; }
            public double _volume { get; }
            public double _freVolume { get; }

            public FileSystem(string name, double volume, double freVolume)
            {
                _name = name;
                _volume = volume;
                _freVolume = freVolume;
            }
            Dictionary<string, Folder> newFolder = new Dictionary<string, Folder>();

            public void CreateFolder(string nameFolder)
            {
                newFolder.Add(nameFolder, new Folder(null));
            }
        }

        public class Folder
        {
            public string _name { get; set; }
            List<string> files { get; set; } = new List<string>();

            public Folder(string name)
            {
                _name = name;
            }

            public void AddFile(string name)
            {
                if (!files.Contains(name))
                {
                    files.Add(name);
                }
            }

            public void ShowList()
            {
                foreach (string file in files)
                {
                    Console.WriteLine(file + "\n");
                }
            }
        }


    }
}
