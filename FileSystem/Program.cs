using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileSystem fileSystem = new FileSystem("C", 500000, 366000);
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
            Dictionary<string,Folder> newFolder = new Dictionary<string, Folder>();
            public void CreateFolder(string nameFolder)
            {
                newFolder.Add(nameFolder,new Folder());
            }
        }
        public class Folder
        {
            List<string> files { get; set; }=new List<string>();
        }
    }
}
