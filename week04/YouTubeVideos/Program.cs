using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("C# Fundamentals", "DevMaster", 600);
        v1.AddComment(new Comment("Juan88", "Very good explanation."));
        v1.AddComment(new Comment("Maria_Dev", "Thanks for the tutorial."));
        v1.AddComment(new Comment("CarlosT", "Waiting for part 2."));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Abstraction in OOP", "Software Academy", 450);
        v2.AddComment(new Comment("Lucia", "This cleared up many of my doubts."));
        v2.AddComment(new Comment("Robot01", "Buen video."));
        v2.AddComment(new Comment("Eduardo", "Keep it up."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Top 10 C# Libraries", "Tech Insider", 1200);
        v3.AddComment(new Comment("GamerX", "I didn't know number 5."));
        v3.AddComment(new Comment("Anon", "Interesting."));
        v3.AddComment(new Comment("Developer_Prime", "Excellent content!"));
        videos.Add(v3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}