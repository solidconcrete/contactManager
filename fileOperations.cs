using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace contactManager
{
    class fileOperations
    {
        public static string readFile()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(dirPath, "contactList.json");
            string jsonData;

            if (!File.Exists(jsonPath))
            {
                writeToFile("[]");
                jsonData = "[]";
            }
            else
            {
                jsonData = File.ReadAllText(jsonPath);
            }
            return jsonData;
        }
        public static void writeToFile(string toAdd)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(dirPath, "contactList.json");

            if (!File.Exists(jsonPath))
            {
                using (StreamWriter sw = File.CreateText(jsonPath));
            }
            using (StreamWriter sw = File.CreateText(jsonPath))
            {
                sw.Write(toAdd);
            }

        }
    }
}
