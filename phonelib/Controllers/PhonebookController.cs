using Microsoft.AspNetCore.Mvc;
using phonelib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace phonelib.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhonebookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{number}")]
        public IActionResult Get(string number)
        {
            Users user = new Users();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Users>> CreateTodoItem(Users user)
        {
            Phonebook phonebook = new Phonebook();
            phonebook.User.Add(user);

            string pth = @"D:\Test.bin";

            //Serializing the collection  
            Serialize(user, pth);

            //Deserializing the collection  
            //Deserialize(pth);
        }

        public void Serialize(Users user, String filename)
        {
            //Create the stream to add object into it.  
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, user);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        //Deserializing the List  
        //public void Deserialize(String filename)
        //{
        //    //Format the object as Binary  
        //    BinaryFormatter formatter = new BinaryFormatter();

        //    //Reading the file from the server  
        //    FileStream fs = File.Open(filename, FileMode.Open);

        //    object obj = formatter.Deserialize(fs);
        //    Users emps = (Users)obj;
        //    fs.Flush();
        //    fs.Close();
        //    fs.Dispose();
        //    foreach (Employee employee in emps)
        //    {
        //        Response.Write(employee.Name + "<br/>");
        //    }
        //}

    }
}
