using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITaskRepository
    {
        public List<TaskItem> GetAll();
        public void Add(TaskItem TaskItem);
        public TaskItem GetById(int Id);
        public void Delete(TaskItem TaskItem);

        public void Update(TaskItem TaskItem);
        public void Save();
    }
}
