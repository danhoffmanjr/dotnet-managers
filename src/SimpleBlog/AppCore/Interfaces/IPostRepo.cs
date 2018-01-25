using System;
using System.Collections.Generic;
using System.Text;
using AppCore.Entities;

namespace AppCore.Interfaces
{
    public interface IPostRepo
    {
        List<Post> AllPosts();
        List<int> AllPostAwScores();
        Post GetById(int id);
        Post GetByPermalink(string perma);
        void CreatePost(Post newPost);
        void UpdatePost(Post updatedPost);
        void DeletePost(Post postToDelete);
        double UpdateAwScore(int newAwScore);
    }
}