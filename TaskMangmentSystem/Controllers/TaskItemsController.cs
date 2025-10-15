using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using InfraStructure.Data;
//using TaskMangmentSystem.Models;
using Core.Interfaces;

namespace TaskMangmentSystem.Controllers
{
    public class TaskItemsController : Controller
    {
        ITaskRepository TaskRepository;
        public TaskItemsController(ITaskRepository TaskRepo)
        {
            TaskRepository = TaskRepo;
        }
        // GET: TaskItems/index
        public IActionResult Index()
        {
            return View(TaskRepository.GetAll());
        }

        // GET: TaskItems/Details/5
        public IActionResult Details(int id)
        {

            TaskItem TaskItem = TaskRepository.GetById(id);
            if (TaskItem == null)
            {
                return NotFound();
            }

            return View(TaskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Iscompleted,CreateAt")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                TaskRepository.Add(taskItem);
                TaskRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public IActionResult Edit(int id)
        {
            TaskItem TaskItem = TaskRepository.GetById(id);
            if (TaskItem == null)
            {
                return NotFound();
            }
            return View(TaskItem);
        }

        // POST: TaskItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,Iscompleted,CreateAt")] TaskItem taskItem)
        {

            if (ModelState.IsValid)
            {
                TaskRepository.Update(taskItem);
                TaskRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public IActionResult Delete(int id)
        {
            TaskItem TaskItem = TaskRepository.GetById(id);
            if (TaskItem == null)
            {
                return NotFound();
            }

            return View(TaskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TaskItem TaskItem = TaskRepository.GetById(id);
            if (TaskItem != null)
            {
                TaskRepository.Delete(TaskItem);
            }
            TaskRepository.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
