using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantReviewLibrary
{
    class MyClass
    {

    }
    public class Serializer
    {
        public static void SerializeObj<T>(List<T> serializeObj, string FileName, bool overwrite)
        {
            using (StreamWriter file = new StreamWriter(FileName, !overwrite))
            {
                foreach (T obj in serializeObj)
                {
                    file.WriteLine(JsonConvert.SerializeObject(obj));
                }
            }
        }

        public static List<T> DeserializeObj<T>(string fileName)
        {
            List<T> results = new List<T>();

            using (StreamReader source = File.OpenText(fileName))
            {
                while (!source.EndOfStream)
                {
                    results.Add(JsonConvert.DeserializeObject<T>(source.ReadLine()));
                }
            }

            return results;
        }
    }
}
