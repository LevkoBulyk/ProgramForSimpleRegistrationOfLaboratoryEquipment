using LabEquipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabEquipment.DesctopUI
{
    // IP: the location of its file itself is controversial ... & why it isn't "static class" (all its members is static)
    public class CurrentWorker
    {
        private static Worker currentWorker;

        public static void Initialize(Worker worcer)
        {
            if (currentWorker != null)
            {
                throw new Exception("Current user has been already initialized.");
            }
            currentWorker = worcer;
        }

        public static int Id
        {
            get { return currentWorker.Id; }
        }

        public static string FirstName
        {
            get { return currentWorker.FirstName; }
        }

        public static string LastName
        {
            get { return currentWorker.LastName; }
        }

        public static string Login
        {
            get { return currentWorker.Login; }
        }
    }
}
