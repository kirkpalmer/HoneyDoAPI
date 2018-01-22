using HoneyDoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDoAPI.Services
{
    public interface IHoneyDoService
    {
        List<HoneyDoTaskView> GetTasks();
        List<HoneyDoTaskView> GetSeededTasks();
        HoneyDoTaskView GetTask(int id);
        HoneyDoTaskView AddTask(HoneyDoTaskView task);
        void UpdateTask(int id, HoneyDoTaskView task);
        void DeleteTask(int id);
    }
}
