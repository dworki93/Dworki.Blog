﻿using Dworki.Blog.Web.Core.Models;
using Dworki.Blog.Web.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dworki.Blog.Web.Persistence.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Post> GetPostsWithTags(int pageIndex, int pageSize)
        {
            //return _context.Posts.In
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsWithoutContents()
        {
            return ApplicationDbContext.Posts
                .Select(p => new Post()
                {
                    Id = p.Id,
                    Author = p.Author,
                    DateTime = p.DateTime,
                    Title = p.Title,
                    Visibility = p.Visibility
                })
                .Include(p => p.Author)
                .ToList();
        }
    }
}