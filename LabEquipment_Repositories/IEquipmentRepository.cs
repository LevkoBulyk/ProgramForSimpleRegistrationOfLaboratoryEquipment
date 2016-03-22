using System.Collections.Generic;
using LabEquipment.Entities;

namespace LabEquipment.Repositories
{
    interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        Equipment InsertEquipment(Equipment equipment);

        //IEnumerable<Equipment> SeqrchForEquipment(string name);
    }
}
