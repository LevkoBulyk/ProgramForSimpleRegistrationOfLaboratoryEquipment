using System.Collections.Generic;
using LabEquipment.Entities;

namespace LabEquipment.Repositories
{
    interface IWorkerRepository
    {
        IEnumerable<Worker> GetWorkerList();
        IEnumerable<Worker> GetViolatorList();
        Worker InsertWorker(Worker worker);

        //IEnumerable<Worker> SearchForWorker(string name);
    }
}
