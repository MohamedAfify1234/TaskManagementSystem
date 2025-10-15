using Core.Interfaces;
using Core.Models;
using InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        TaskMangDbContext Context;
        public TaskRepository(TaskMangDbContext _Context)
        {
            Context = _Context;

        }

        public List<TaskItem> GetAll()
        {
            return Context.TaskItems.ToList();
        }
        public void Add(TaskItem TaskItem)
        {
            Context.Add(TaskItem);
        }
        public TaskItem GetById(int Id)
        {
            return Context.TaskItems.FirstOrDefault(TI => TI.Id == Id);
        }
        public void Delete(TaskItem TaskItem)
        {
            Context.TaskItems.Remove(TaskItem);
        }

        public void Update(TaskItem TaskItem)
        {
            Context.Update(TaskItem);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
