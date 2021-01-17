using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository.ListRepository
{
    public class IdGenerator
    {

        private static int currentId = 1;

        public static int getId()
        {
            currentId++;
            return currentId - 1;
        }

    }
}
