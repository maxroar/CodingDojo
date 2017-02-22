using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using theWall.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace theWall.Factory
{
    public class WallFactory : IFactory<User> {
    private readonly IOptions<MySqlOptions> mysqlConfig;
    
    public WallFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
    }
    
    internal IDbConnection Connection {
      get {
         return new MySqlConnection(mysqlConfig.Value.ConnectionString);
      }
    }

    public void AddPost(string content, int uid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"INSERT into posts (content, user_id, createdAt, updatedAt) VALUES ('" + content + $"', {uid}, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query);

      }
      
    }
    public List<Post> GetAllPosts()
    {
      using(IDbConnection dbConnection = Connection){
        string query = "SELECT * FROM posts";
        dbConnection.Open();
        return dbConnection.Query<Post>(query).ToList();
      }
    }

    // public User GetUserByID(int id)
    // {
    //   using(IDbConnection dbConnection = Connection){
    //     string query = $"SELECT * FROM users WHERE id = {id} LIMIT 1";
    //     dbConnection.Open();
    //     User current = dbConnection.QuerySingleOrDefault<User>(query);
    //     System.Console.WriteLine(current);
    //     return current;
    //   }
    // }

    // public bool CheckUserInDB(string email){
    //   User newUser = GetCurrentUser(email);
    //   return newUser != null;
    // }

    // public bool CheckLogin(User user){
    //   User newUser = GetCurrentUser(user.email);
    //   var hasher = new PasswordHasher<User>();
    //   if(0 != hasher.VerifyHashedPassword(user, user.password, newUser.password)){
    //     return true;
    //   }
    //   return false;
    // }
}
}