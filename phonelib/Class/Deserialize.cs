using phonelib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace phonelib.Class
{
    public class Deserialize
    {
        public static Phonebook DeserializeObject()
        {
            string filename = @"D:\phonelib.bin";
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = System.IO.File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            Phonebook userphone = (Phonebook)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return userphone;
        }

        public static Users getUserbyID( int UserID)
        {
            string filename = @"D:\phonelib.bin";
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = System.IO.File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            Phonebook userphone = (Phonebook)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return userphone.User.Where(i=>i.UserId==UserID).FirstOrDefault();
        }
    }
}
