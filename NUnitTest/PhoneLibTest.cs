using NUnit.Framework;
using phonelib.Class;
using phonelib.Model;
using System;
using System.Linq;

namespace NUnitTest
{
    [TestFixture]
    public class PhoneLibTest
    {
        [Test]
        public void CreatePhonebook()
        {
            Users user = new Users();

            Phonebook phonebook = Deserialize.DeserializeObject();
            int lastID = 1;
            if (phonebook.user.Count > 0)
                lastID = phonebook.User.OrderBy(o => o.UserId).LastOrDefault().UserId;
            lastID++;
            Users newUser = new Users();
            newUser.UserId = lastID++;
            newUser.Firstname = "Test1 First";
            newUser.Lastname = "Test1 Last"; 
            newUser.Type = "Test1 Type"; 
            newUser.Number = "+38971 660 922";
           
            Users newUser1 = new Users();
            newUser1.UserId = lastID++;
            newUser1.Firstname = "Test2 First";
            newUser1.Lastname = "Test3 Last";
            newUser1.Type = "Test4 Type";
            newUser1.Number = "+38971 660 23";
            phonebook.User.Add(newUser);
            phonebook.User.Add(newUser1);

            Assert.IsNotNull(Deserialize.DeserializeObject());
        }
    }
}
