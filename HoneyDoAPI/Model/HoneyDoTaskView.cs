using HoneyDo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDoAPI.Model
{
    public class HoneyDoTaskView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public StatusView Status { get; set; }
        public int ImportanceRank { get; set; }

        public HoneyDoTaskView(HoneyDoTask task)
        {
            if(task != null)
            {
                this.Id = task.Id;
                this.Name = task.Name;
                this.Description = task.Description;
                this.StartDate = task.StartDate;
                this.ClosedDate = task.ClosedDate;
                this.Status = new StatusView(task.Status);
                this.ImportanceRank = task.ImportanceRank;
            }
            
        }

        public HoneyDoTaskView(bool seed)
        {
            this.Name = "New Task";
            this.Description = "First Seeded Task";
            this.StartDate = DateTime.Today;
            this.Status = new StatusView("OPEN");
            this.ImportanceRank = 2;
        }
        public HoneyDoTaskView() { }

        public HoneyDoTask NewTask()
        {
            return new HoneyDoTask(this.Name, this.Description, this.StartDate, this.ImportanceRank);
        }

        public HoneyDoTask UpdateTask(HoneyDoTask task)
        {
            return task.Update(this.Id, this.Name, this.Description, this.Status.Type, this.ImportanceRank);
        }
    }
}
