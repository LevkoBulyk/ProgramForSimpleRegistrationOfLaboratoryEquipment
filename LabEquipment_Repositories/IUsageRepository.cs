using System.Collections.Generic;
using LabEquipment.Entities;

namespace LabEquipment.Repositories
{
    interface IUsageRepository
    {
        IEnumerable<Usage> GetUsageList();
        Usage TakePieceOfEquipment(int workerId, int equipmentId);
        Usage ReturnPieceOfEquipment(int usageId);

        //IEnumerable<Usage> GetAllOpenedUseges();
    }
}
