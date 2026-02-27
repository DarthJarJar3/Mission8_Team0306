using Mission8_Team0306.Models;

namespace Mission8_Team0306.Repositories
{
    public interface ITaskRepository
    {
        IQueryable<TaskItem> Tasks { get; }

        IQueryable<Category> Categories { get; }

        void AddTask(TaskItem task);

        void UpdateTask(TaskItem task);

        void DeleteTask(TaskItem task);

        void SaveChanges();
    }
}