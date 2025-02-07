using DLM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DLM.Data;

public static class DbInitializer
{
    public static async Task Seed(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = Enumerable.Range(1, 10).Select(i => new Category
            {
                Name = $"Lập trình {i}",
                Description = $"Khóa học lập trình từ cơ bản {i}",
                ImageUrl = $"/images/programming_{i}.jpg",
                SortOrder = i
            }).ToList();

            context.AddRange(categories);
            await context.SaveChangesAsync();

            var courses = categories.Select((category, i) => new Course
            {
                CategoryId = category.Id,
                Title = $"Học lập trình C# {i + 1}",
                Description = $"Khóa học lập trình C# từ cơ bản {i + 1}",
                ImageUrl = $"/images/programming_{i + 1}.jpg",
                Price = 199 + i * 10,
                JoinNumber = 0,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            }).ToList();

            context.AddRange(courses);
            await context.SaveChangesAsync();

            var lessons = courses.Select((course, i) => new Lesson
            {
                CourseId = course.Id,
                Title = $"Giới thiệu C# {i + 1}",
                Content = $"Cách cài đặt C#, cú pháp cơ bản {i + 1}",
                Vote = 0,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            }).ToList();

            context.AddRange(lessons);
            await context.SaveChangesAsync();
        }
    }
}