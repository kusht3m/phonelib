using Microsoft.AspNetCore.Mvc;
using phonelib.Class;
using phonelib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phonelib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public List<Users> GetAllUser()
        {
            return Deserialize.DeserializeObject().User.OrderBy(o => o.Firstname).ToList();
        }

        /// <param id="1">Phonebook deafult starting ID</param>
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            return Deserialize.getUserbyID(id);
        }

 
        [HttpPost]
        public Users Post(string strName, string strLast, string strType, string Number)
        {
            Phonebook phonebook = Deserialize.DeserializeObject();
            //deafult starting ID=1
            int lastID = 1;
            if (phonebook.user.Count > 0)
                lastID = phonebook.User.OrderBy(o => o.UserId).LastOrDefault().UserId;

            //UserID or Phonebook ID increments by 1 for each insert
            lastID++;
            Users newUser = new Users();
            newUser.UserId = lastID;
            newUser.Firstname = strName;
            newUser.Lastname = strLast;
            newUser.Type = strType;
            newUser.Number = Number;
            phonebook.User.Add(newUser);

            /// <summary>
            // Serialize Class is used to Save date in file (bit) and returns the new user
            /// </summary>
            Serialize.SerializeObject(phonebook);
            return newUser;
        }


        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Users values)
        {
            Phonebook phonebook = Deserialize.DeserializeObject();

            var itemtodeUpdate = phonebook.User.Where(u => u.UserId == id).FirstOrDefault();
            if (itemtodeUpdate != null)
            {
                itemtodeUpdate.Firstname = values.Firstname;
                itemtodeUpdate.Lastname = values.Lastname;
                itemtodeUpdate.Type = values.Type;
                itemtodeUpdate.Number = values.Number;
                Serialize.SerializeObject(phonebook);

                return "Updated Successfully";
            }
            else
                return StatusCode(404).ToString();

        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Phonebook phonebook = Deserialize.DeserializeObject();
            var itemtodeDelete = phonebook.User.Where(u => u.UserId == id).FirstOrDefault();
            if (itemtodeDelete != null)
            {
                phonebook.User.Remove(itemtodeDelete);
                Serialize.SerializeObject(phonebook);

                return "Deleted Successfully";
            }
            else
                return StatusCode(404).ToString();

        }
    }
}
