using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Dal
{
    public class TaskDal: ITaskDal
    {
        TaskApiContext _myDB;
        public TaskDal(TaskApiContext appDbContext)
        {
            _myDB = appDbContext;
        }

        public async Task PostTaskDal([FromBody]TaskModel task)
        {
            await _myDB.Tasks.AddAsync(task);
            await _myDB.SaveChangesAsync();
        }

        public async Task PutTaskDal(TaskModel task)
        {
            TaskModel taskToUpdate = await _myDB.Tasks.FindAsync(task.Id);
            if (taskToUpdate == null)
            {

                await _myDB.Tasks.AddAsync(task);
            }
            else
            {
                _myDB.Entry(taskToUpdate).CurrentValues.SetValues(task);
            }

            await _myDB.SaveChangesAsync();
        }

        public async Task DeleteTaskDal(int taskId)
        {
            TaskModel taskToDelete = await _myDB.Tasks.FindAsync(taskId);
            _myDB.Tasks.Remove(taskToDelete);
            await _myDB.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> GetAllTaskDal()
        {
            List<TaskModel> productsList = new List<TaskModel>();

            productsList = await _myDB.Tasks.ToListAsync();


            return productsList;
        }

    }
}
