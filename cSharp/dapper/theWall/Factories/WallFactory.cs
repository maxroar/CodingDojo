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

    public void AddPost(Post post, int uid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"INSERT into posts (content, user_id, createdAt, updatedAt) VALUES (@content, {uid}, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query, post);

      }
      
    }
    public List<Post> GetAllPosts()
    {
      using(IDbConnection dbConnection = Connection){
        string query = "SELECT * FROM posts INNER JOIN users on posts.user_id = users.id";
        dbConnection.Open();
        return dbConnection.Query<Post>(query).ToList();
      }
    }

    public void AddComment(Comment comment, int uid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"INSERT into comments (content, user_id, post_id, createdAt, updatedAt) VALUES (@content, {uid}, @post_id, NOW(), NOW())";
        dbConnection.Open();
        dbConnection.Execute(query, comment);

      }
      
    }

    public void DeletePost(int pid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"DELETE FROM comments WHERE post_id = {pid}; DELETE FROM posts WHERE id = {pid}";
        dbConnection.Open();
        dbConnection.Execute(query);
      }
    }
    public List<Comment> GetAllComments()
    {
      using(IDbConnection dbConnection = Connection){
        string query = "SELECT * FROM comments";
        dbConnection.Open();
        return dbConnection.Query<Comment>(query).ToList();
      }
    }

}
}