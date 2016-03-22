using System.Collections.Generic;
using LabEquipment.Entities;

namespace LabEquipment.Repositories
{
    interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker InsertWorker(Worker worker);

        //IEnumerable<Worker> SearchForWorker(string name);
    }
}
