using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Options;
using theWall.Models;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using static Dapper.SqlMapper;

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
        string query = @"SELECT * FROM posts JOIN users on posts.user_id = users.id ORDER BY posts.createdAt DESC; SELECT * FROM comments JOIN users on comments.user_id = users.id";
        dbConnection.Open();
        using (GridReader multi = dbConnection.QueryMultiple(query, null))
        {
          List<Post> Posts = multi.Read<Post, User, Post>((post, user) => {post.user = user; return post;}, splitOn: "user_id").ToList();
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
    public void DeleteComment(int cid)
    {
      using(IDbConnection dbConnection = Connection){
        string query = $"DELETE FROM comments WHERE id = {cid}";
        dbConnection.Open();
        dbConnection.Execute(query);
      }
    }

}
}