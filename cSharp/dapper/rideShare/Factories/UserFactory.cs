using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using rideShare.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace rideShare.Factory
{
    public class UserFactory : IFactory<User> {
    private readonly IOptions<MySqlOptions> mysqlConfig;
    
    public UserFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
    }
    
    internal IDbConnection Connection {
      get {
         return new MySqlConnection(mysqlConfig.Value.ConnectionString);
      }
    }

    public void AddUser(User user)
    {
      using(IDbConnection dbConnection = Connection){
        string query = "INSERT into users (username, email, password, isDriver, createdAt, updatedAt) VALUES (@username, @email, @password, false, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query, user);

      }
      
    }

    public void SetDriver(int uid){
        using(IDbConnection dbConnection = Connection){
            string query = $"UPDATE users SET isDriver = true WHERE id = {uid}";
            dbConnection.Open();
            dbConnection.Execute(query);
        }

    }
    public User GetCurrentUser(string email)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"SELECT * FROM users WHERE email = '{email}' LIMIT 1";
        dbConnection.Open();
        User current = dbConnection.QuerySingleOrDefault<User>(query);
        System.Console.WriteLine(current);
        return current;
      }
    }

    public User GetUserByID(int id)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"SELECT * FROM users WHERE id = {id} LIMIT 1";
        dbConnection.Open();
        User current = dbConnection.QuerySingleOrDefault<User>(query);
        System.Console.WriteLine(current);
        return current;
      }
    }

    public bool CheckUserInDB(string email){
      User newUser = GetCurrentUser(email);
      return newUser != null;
    }

    public bool CheckLogin(User user){
      User newUser = GetCurrentUser(user.email);
      var hasher = new PasswordHasher<User>();
      if(0 != hasher.VerifyHashedPassword(user, user.password, newUser.password)){
        return true;
      }
      return false;
    }
}
}