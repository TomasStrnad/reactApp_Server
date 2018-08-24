using System;

namespace WebApi.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
    }
}