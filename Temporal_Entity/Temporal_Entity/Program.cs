// See https://aka.ms/new-console-template for more information


using Temporal_Entity.DbEntity.Entity;
using Temporal_Entity;
using Temporal_Entity.DbEntity;

Post p1 = new() { Content = "A Post Content", PostType = PostType.Talk, Title = "A Post Title" };
Post p2 = new() { Content = "B Post Content", PostType = PostType.Talk, Title = "B Post Title" };
Post p3 = new() { Content = "C Post Content", PostType = PostType.Talk, Title = "C Post Title" };

TemporalExampleDb conext = new();

//await conext.AddRangeAsync(p1, p2, p3);


Post post = await conext.Posts.FindAsync(2);
post.PostType = PostType.Side;
post.Title = "B Post Title - Updated";

await conext.SaveChangesAsync();
