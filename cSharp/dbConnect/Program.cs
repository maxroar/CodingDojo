using System;
using System.Collections.Generic;
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
                    System.Console.WriteLine(userList[uid]);
                }

                System.Console.WriteLine("Users:");
                foreach (List<Dictionary<string, object>> user in userList){
                    System.Console.WriteLine(user[0].Values);
                    foreach (KeyValuePair<string, object> userData in user[0].Values){
                        System.Console.WriteLine(userData.Value);
                    }
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
        }
    }
}
