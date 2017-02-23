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
        string query = $"INSERT into cars (make, model, seats, driver, createdAt, updatedAt) VALUES (@make, @model, @seats, {uid}, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query, car);

      }
    }

    public Car GetRiders(Car vehicle)
    {
      using(IDbConnection dbConnection = Connection){
        string query = "SELECT * FROM cars JOIN users on cars.riders = users.id WHERE cars.id = @id";
        dbConnection.Open();

        List<User> riserList = dbConnection.Query(query);
        using (GridReader multi = dbConnection.QueryMultiple(query, null))
        {
          Car Car = multi.Read<Car, User, Car>((car, user) => {car.driver = user; return car;}, splitOn: "user_id").ToList();
          List<Comment> Comments = multi.Read<Comment, User, Comment>((comment, user) => {comment.user = user; return comment;}, splitOn: "user_id").ToList();
          List<Post> combo = Posts.GroupJoin(
            Comments,
            post => post.id,
            comment => comment.post_id,
            (post, comments) =>
            {
              post.comments = comments.ToList();
              return post;
            }
          ).ToList();
          return combo;
        }
      }
    }
    

}
}