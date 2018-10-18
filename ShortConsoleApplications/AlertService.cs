﻿using System.Collections.Generic;
using System;

namespace ShortConsoleApplications
{

    /* Refactor the AlertService and AlertDAO classes:

Create a new interface, named IAlertDAO, that contains the same methods as AlertDAO.
AlertDAO should implement the IAlertDAO interface.
AlertService should have a constructor that accepts IAlertDAO.
The RaiseAlert and GetAlertTime methods should use the object passed through the constructor.

*/
    public class AlertService
    {
        private readonly AlertDAO storage = new AlertDAO();
        private readonly IAlertDAO Istorage;
        public AlertService(IAlertDAO alert)
        {
            Istorage = alert;
        }

        public Guid RaiseAlert()
        {
            return this.Istorage.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return this.Istorage.GetAlert(id);
        }
    }

    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }
    public interface IAlertDAO
    {

        Guid AddAlert(DateTime time);

        DateTime GetAlert(Guid id);
    }
}
