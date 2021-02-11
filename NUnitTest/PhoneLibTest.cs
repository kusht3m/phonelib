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
            newUser.UserId = 1000;
            newUser.Firstname = "Test1 First";
            newUser.Lastname = "Test1 Last";
            newUser.Type = "Test1 Type";
            newUser.Number = "+38971 660 922";

            Users newUser1 = new Users();
            newUser1.UserId = 1001;
            newUser1.Firstname = "Test2 First";
            newUser1.Lastname = "Test3 Last";
            newUser1.Type = "Test4 Type";
            newUser1.Number = "+38971 660 23";

            phonebook.User.Add(newUser);
            phonebook.User.Add(newUser1);

            Assert.IsNotNull(Deserialize.DeserializeObject());
        }
        [Test]
        public void DeletePhonebook()
        {
            Phonebook phonebook = Deserialize.DeserializeObject();
            var itemtodeDelete = phonebook.User.Where(u => u.UserId == 1000).FirstOrDefault();
            if (itemtodeDelete != null)
            {
                phonebook.User.Remove(itemtodeDelete);
                Serialize.SerializeObject(phonebook);
            }

            Assert.IsNull(phonebook.User.Where(u => u.UserId == 1000).FirstOrDefault());

        }
    }
}
