using Dal.Models;

namespace Dal
{
    public interface ITaskDal
    {
        Task PostTaskDal(TaskModel task);
        Task PutTaskDal(TaskModel task);
        Task DeleteTaskDal(int taskId);
        Task<List<TaskModel>> GetAllTaskDal();

    }
}