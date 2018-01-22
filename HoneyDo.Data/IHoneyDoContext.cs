
using HoneyDo.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyDo.Data
{
    public interface IHoneyDoContext
    {
        DbSet<HoneyDoTask> HoneyDoTasks { get; set; }
        
    }
}
