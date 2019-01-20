using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Cat_Database.Program;
using static Cat_Database.Cat;
using static Cat_Database.Filtering;
using static Cat_Database.ConsoleIO;



namespace Cat_Database
{
    public class IOtxt : ISaveLoadable
    {
        public static string GenerateFileFullName(string subDir, string fileNameTemplate)
        {
            string fileName = fileNameTemplate + DateTime.Now.ToString("yyyy_MM_dd_hh_mm");
            fileName = Path.ChangeExtension(fileName, ".txt");
            if (!Directory.Exists(subDir))
                Directory.CreateDirectory(subDir);

            string fileFullName = Path.Combine(subDir, fileName);
            return Path.GetFullPath(fileFullName);
        }

        public  void Save()
        {
            string[] pickedCats = tempCollection.Select(el => el.ToString()).ToArray();
            string currentFileName = GenerateFileFullName(subDir, fileNameTemplate);
            string[] fileBeginning = { filteredCatsHeader, filtersList, "\n\n" };
            File.WriteAllLines(currentFileName, fileBeginning);
            File.AppendAllLines(currentFileName, pickedCats);

        }
        public void Load()
        {
            //---=== Not needed by now ===---
        }

    }
}
