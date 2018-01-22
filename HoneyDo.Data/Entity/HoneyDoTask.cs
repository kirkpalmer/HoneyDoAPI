using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HoneyDo.Data.Entity
{
    public class HoneyDoTask: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public string Status { get; set; }
        public int ImportanceRank { get; set; }

        public HoneyDoTask(string name, string description, DateTime startDate, int importance = 5 )
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.ImportanceRank = importance;

            if (startDate > DateTime.Today)
                this.Status = "FUTURE";
            else
                this.Status = "OPEN";
        }

        public HoneyDoTask Update(int id, string name, string description, string status, int importance)
        {
            if(name != null)
            this.Name = name;
            if(description != null)
            this.Description = description;
            this.ImportanceRank = importance;
            this.Status = status;
            if (status == "COMPLETE" || status == "CANCELED")
                this.ClosedDate = DateTime.Now;

            return this;
        }

        private HoneyDoTask() { }
    }

}
