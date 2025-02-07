using DLM.Data.Interfaces;

namespace DLM.Data.Entities;

public class Lesson : IDateTracking
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int Vote { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}