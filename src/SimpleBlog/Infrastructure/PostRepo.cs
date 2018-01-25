using AppCore.Entities;
using AppCore.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class PostRepo : IPostRepo
    {
        private static List<Post> _posts;
        private List<int> _awScores = new List<int>();
        private static int _nextId = 1;

        // Code to write to file system
        private const string PATH = "Data";
        private const string FILENAME = "postsData.json";
        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        // Constructor to Load Posts from File
        public PostRepo()
        {
            if (_posts == null)
            {
                _posts = LoadFile();
                _nextId = _posts.Max(t => t.Id) + 1;
            }
        }

        public List<int> AllPostAwScores()
        {
            return _awScores;
        }

        public List<Post> AllPosts()
        {
            return _posts;
        }

        public void CreatePost(Post newPost)
        {
            newPost.Id = _nextId++;
            newPost.AvgAwScore = newPost.AwScore;
            _awScores.Add(newPost.AwScore);
            _posts.Add(newPost);
            SaveFile();
        }

        public void DeletePost(Post postToDelete)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            return _posts.Find(post => post.Id == id);
        }

        public Post GetByPermalink(string perma)
        {
            return _posts.Find(post => post.Permalink == perma);
        }

        public double UpdateAwScore(int newAwScore)
        {
            _awScores.Add(newAwScore);
            return _awScores.Average();
        }

        public void UpdatePost(Post updatedPost)
        {
            throw new NotImplementedException();
        }


        //Save to File System
        public void SaveFile()
        {
            try
            {
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }

                string rawListStr = JsonConvert.SerializeObject(_posts);

                File.WriteAllText(_fileFullPath, rawListStr);
            }
            catch (Exception ex)
            {
                // TODO Log the exception
            }
        }

        //Load from File System
        public List<Post> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);

                List<Post> rawTelgramList = JsonConvert.DeserializeObject<List<Post>>(rawListStr);

                return rawTelgramList;
            }
            catch (Exception ex)
            {
                // TODO Log the exception

                return new List<Post>();
            }
        }
    }
}
