using HoneyDo.Data;
using HoneyDo.Data.Entity;
using HoneyDoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDoAPI.Services
{
    public class HoneyDoService : IHoneyDoService
    {
        private HoneyDoContext _context;
        public HoneyDoService(HoneyDoContext context)
        {
            this._context = context;
        }

        public List<HoneyDoTaskView> GetTasks()
        {
            List<HoneyDoTaskView> result = null;
            List<HoneyDoTask> tasks = _context.HoneyDoTasks.ToList();
            if(tasks != null && tasks.Count > 0)
            {
                result = new List<HoneyDoTaskView>();
                tasks.ForEach(x => result.Add(new HoneyDoTaskView(x)));
            }
            
            return result;
        }

        public List<HoneyDoTaskView> GetSeededTasks()
        {
            List<HoneyDoTask> tasks = _context.HoneyDoTasks.ToList();
            List<HoneyDoTaskView> result = new List<HoneyDoTaskView>();
            result.Add(new HoneyDoTaskView(true));
            tasks.ForEach(x => result.Add(new HoneyDoTaskView(x)));
            return result;

        }

        public HoneyDoTaskView GetTask(int id)
        {
            HoneyDoTaskView result = null;
            HoneyDoTask task = _context.HoneyDoTasks.FirstOrDefault(x => x.Id == id);
            if(task != null)
                result = new HoneyDoTaskView(task);
            return result;

        }
        public HoneyDoTaskView AddTask(HoneyDoTaskView task)
        {
            HoneyDoTask dataTask = task.NewTask();
            _context.HoneyDoTasks.Add(dataTask);
            _context.SaveChanges();
            return new HoneyDoTaskView(dataTask);
        }

        public void UpdateTask(int id, HoneyDoTaskView task)
        {
            var dataTask = _context.HoneyDoTasks.FirstOrDefault(x => x.Id == id);
            
            _context.HoneyDoTasks.Update(task.UpdateTask(dataTask));
            _context.SaveChanges();
        }


        public void DeleteTask(int id)
        {
            var dataTask = _context.HoneyDoTasks.FirstOrDefault(x => x.Id == id);
          
            _context.HoneyDoTasks.Remove(dataTask);
            _context.SaveChanges();
        }

    }
}
