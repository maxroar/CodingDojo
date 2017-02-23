using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using rideShare.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using static Dapper.SqlMapper;

namespace rideShare.Factory
{
    public class RideFactory : IFactory<User> {
    private readonly IOptions<MySqlOptions> mysqlConfig;
    
    public RideFactory(IOptions<MySqlOptions> conf) {
            mysqlConfig = conf;
    }
    
    internal IDbConnection Connection {
      get {
         return new MySqlConnection(mysqlConfig.Value.ConnectionString);
      }
    }

    public void AddCar(Car car, int uid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"INSERT into posts (content, user_id, createdAt, updatedAt) VALUES (@content, {uid}, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query, post);

      }
      
    }
    

}
}