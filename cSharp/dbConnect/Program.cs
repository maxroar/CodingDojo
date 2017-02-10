using System;
using System.Collections.Generic;
using System.Linq;
using DbConnection;


namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadDB();
        }

        public static void ReadDB()
        {
            List<object> userList = new List<object>();
                List<Dictionary<string, object>> totalCount = DbConnector.ExecuteQuery("SELECT COUNT(*) FROM Users");
                KeyValuePair<string, object> result;
                foreach (KeyValuePair<string, object> dict in totalCount[0]){
                    result = dict;
                }
                int total = Convert.ToInt32(result.Value);
                for (int uid = 0; uid < total; uid++)
                {
                    userList.Add(DbConnector.ExecuteQuery($"SELECT * FROM Users WHERE id = {uid + 1}"));
                }

                System.Console.WriteLine("Users:");
                System.Console.WriteLine("-------------------------------------------------");
                foreach (List<Dictionary<string, object>> user in userList){
                    var user1 = user[0].Values.ToList();
                    System.Console.WriteLine("Name: " + user1[1] + " " + user1[2]);
                    System.Console.WriteLine("Favorite Num: " + user1[3]);
                    System.Console.WriteLine("-------------------------------------------------");
                }
                WriteDB();
        }

        public static void WriteDB(){
            System.Console.Write("Enter your first name: ");
            string fname = Console.ReadLine();
            System.Console.Write("Enter your last name: ");
            string lname = Console.ReadLine();
            System.Console.Write("Enter your favorite number: ");
            int favnum = Convert.ToInt32(Console.ReadLine());
            DbConnector.ExecuteQuery($"INSERT INTO `Users`(`first_name`, `last_name`, `fav_num`) VALUES('{fname}', '{lname}', {favnum});");
            ReadDB();
        }
    }
}
