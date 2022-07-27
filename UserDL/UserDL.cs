using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UserDL
{
    public class UserDL
    {

     User Get (string password, string email)  
            {using (StreamReader reader = System.IO.File.OpenText("M:/Web/Web_Site/Web_Site/UserList.txt")) //////
            {
                string currentUser;
                while ((currentUser = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUser);
                    if (user.Email == email && user.Password == password)
                        return user;
                }
            }
            return NoContent();
}




        ActionResult<User> Post( User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("M:/Web/Web_Site/Web_Site/UserList.txt").Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("M:/Web/Web_Site/Web_Site/UserList.txt", userJson + Environment.NewLine);
            return user;




        }


        public void Put(int id,  User userToUpdate)
        {


            string textToReplace = "";
            using (StreamReader reader = System.IO.File.OpenText("M:/Web/Web_Site/Web_Site/UserList.txt"))
            {
                string currentUser;
                while ((currentUser = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUser);
                    if (user.Id == userToUpdate.Id)
                        textToReplace = currentUser;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("M:/Web/Web_Site/Web_Site/UserList.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("M:/Web/Web_Site/Web_Site/UserList.txt", text);
            }

        }



    }
}
