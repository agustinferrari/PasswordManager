﻿using Obligatorio1_DA1.Domain;
using Obligatorio1_DA1.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DataAccessDataBreach
    {
        public List<Item> AddDataBreachReport(DataBreachReport dataBreachReport)
        {
            using (PasswordManagerDBContext context = new PasswordManagerDBContext())
            {
                List<Item> breachedItems = new List<Item>();
                HashSet<DataBreachReportEntry> dataBreachItems = dataBreachReport.Entries;
                User dataBreachUserFromDB = context.Users.FirstOrDefault(u => u.MasterName == dataBreachReport.User.MasterName);
                dataBreachReport.User = dataBreachUserFromDB;
                foreach (DataBreachReportEntry dataBreachItem in dataBreachItems)
                {
                    foreach (Password pass in context.Passwords.Include("User").Include("Category"))
                        if (pass.Pass == dataBreachItem.Value && pass.User.Equals(dataBreachUserFromDB))
                            breachedItems.Add(pass);
                    foreach (CreditCard card in context.CreditCards.Include("User").Include("Category"))
                        if (card.Number == dataBreachItem.Value && card.User.Equals(dataBreachUserFromDB))
                            breachedItems.Add(card);
                }
                dataBreachReport.BreachedItems = breachedItems;
                SaveDataBreach(dataBreachReport, context);
                return breachedItems;
            }
        }


        private void SaveDataBreach(DataBreachReport dataBreachReport, PasswordManagerDBContext context)
        {
            context.DataBreachReports.Add(dataBreachReport);
            context.SaveChanges();
        }

        public List<DataBreachReport> GetDataBreachReportsFromUser(String userMasterName)
        {
            using (PasswordManagerDBContext context = new PasswordManagerDBContext())
            {
                List<DataBreachReport> reports = context.DataBreachReports.Include("User").Include("BreachedItems").Include("Entries").Where(report => report.User.MasterName == userMasterName).ToList();
                return reports;
            }
        }
    }
}
