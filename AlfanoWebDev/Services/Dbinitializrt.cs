using AlfanoWebDev.Models;

public static class DbInitializer
{
    public static void Initialize(AlfanoDbContext context)
    {
        // Check if there is already data. If so, don't add more.
        if (context.MediaAssets.Any()) return;

        var assets = new MediaAsset[]
        {
            new MediaAsset {
                Title = "My First Project",
                Description = "A cool web app I built.",
                MediaType = "Web",
                MediaUrl = "https://github.com"
            },
            new MediaAsset {
                Title = "Photography Portfolio",
                Description = "A collection of my best shots.",
                MediaType = "Image",
                MediaUrl = "/images/photo1.jpg"
            }
        };

        context.MediaAssets.AddRange(assets);
        context.SaveChanges();
    }
}