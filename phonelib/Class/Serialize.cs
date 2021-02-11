using phonelib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace phonelib.Class
{
    public class Serialize
    {

        public static void SerializeObject(Phonebook user)
        {
            string filename = @"D:\phonelib.bin";
            //Create the stream to add object into it.  
            System.IO.Stream ms = System.IO.File.OpenWrite(filename);
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the user  object  
            formatter.Serialize(ms, user);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }
    }
}
