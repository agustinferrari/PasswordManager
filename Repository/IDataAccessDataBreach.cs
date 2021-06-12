﻿using Obligatorio1_DA1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDataAccessDataBreach
    {
        List<Item> AddDataBreachReport(DataBreachReport dataBreachReport);
        List<DataBreachReport> GetDataBreachReportsFromUser(String userMasterName);
        bool CheckIfPasswordHasBeenBreached(User currentUser, Password passwordToCheck);
    }
}
