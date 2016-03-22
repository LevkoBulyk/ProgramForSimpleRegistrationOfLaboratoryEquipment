using System.Collections.Generic;
using LabEquipment.Entities;

namespace LabEquipment.Repositories
{
    interface IUsageRepository
    {
        IEnumerable<Usage> GetAllUsage();
        Usage TakePieceOfEquipment(int workerId, int equipmentId);
        Usage ReturnPieceOfEquipment(int usageId);
        IEnumerable<Usage> GetAllViolators();

        //IEnumerable<Usage> GetAllOpenedUseges();
    }
}
