using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_F18.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlogDB(
                serviceProvider.GetRequiredService<DbContextOptions<BlogDB>>()))
            {
                // Look for any movies.
                if (!context.AboutInfo.Any())
                {
                    context.AboutInfo.Add(
                     new AboutInfo
                     {
                         BirthDay = new DateTime(1995, 10, 14),
                         CurrentOccupation = "Student",
                         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit ",
                         Name = "Mathies F Hovedskou",
                     });
                }

                if (!context.GalleryEntry.Any())
                {
                    context.GalleryEntry.AddRange(
                        new GalleryEntry
                        {
                            Description = "pink pink pink",
                            Title = "Pink",
                            ImagePath = "/Pink.png"
                        },
                        new GalleryEntry
                        {
                            Description = "green green green",
                            Title = "Green",
                            ImagePath = "/Green.png"
                        }

                        );
                }

                if (!context.Subscriber.Any())
                {
                    context.Subscriber.Add(
                        new Subscriber
                        {
                            Email = "asd@asd.com"
                        });
                }



                

               
                context.SaveChanges();
            }
        }
    }
}

