// See https://aka.ms/new-console-template for more information


using Temporal_Entity.DbEntity.Entity;
using Temporal_Entity;
using Temporal_Entity.DbEntity;
using Microsoft.EntityFrameworkCore;

Post p1 = new() { Content = "A Post Content", PostType = PostType.Talk, Title = "A Post Title" };
Post p2 = new() { Content = "B Post Content", PostType = PostType.Talk, Title = "B Post Title" };
Post p3 = new() { Content = "C Post Content", PostType = PostType.Talk, Title = "C Post Title" };

TemporalExampleDb context = new();

//await conext.AddRangeAsync(p1, p2, p3);


//Post post = await conext.Posts.FindAsync(2);
//post.PostType = PostType.Side;
//post.Title = "B Post Title - Updated";
//await conext.SaveChangesAsync();


var posts = await context.Posts.TemporalAsOf(new DateTime(2023, 4, 2)).Select(data => new
{
    Post = data,
    PeriodStart = EF.Property<DateTime>(data, "PeriodStart"),
    PeriodEnd = EF.Property<DateTime>(data, "PeriodEnd"),
}).ToListAsync();

foreach (var post in posts)
{
    Console.WriteLine($"Id\t\t: {post.Post.Id}");
    Console.WriteLine($"Title\t\t: {post.Post.Title}");
    Console.WriteLine($"Content\t\t: {post.Post.Content}");
    Console.WriteLine($"PeriodStart\t: {post.PeriodStart}");
    Console.WriteLine($"PeriodEnd\t: {post.PeriodEnd}");
    Console.WriteLine("**********");
}
