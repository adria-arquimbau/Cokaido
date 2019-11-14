using System;
using System.Collections.Generic;

namespace LongMethods
{
    public class TechnicalDebt
    {
        private readonly IList<Issue> issues = new List<Issue>();

        public float Total { get; private set; }

        public Issue LastIssue
        {
            get
            {
                return issues[(issues.Count - 1)];
            }
        }

        public string LastIssueDate { get; private set; }

        public void Fixed(float amount)
        {
            Total -= amount;
        }

        public void Register(float effortManHours, string description)
        {
            EffortOutOfMargins(effortManHours);

            var priority = Priority.Low;

            priority = EffortHigher100Medium(effortManHours, priority);

            priority = EffortHigher250High(effortManHours, priority);

            priority = EffortHigher500Critical(effortManHours, priority);

            Total += effortManHours;

            RecordIssue(effortManHours, description, priority);

            UpdateLastIssueDate();
        }

        private void RecordIssue(float effortManHours, string description, Priority priority)
        {
            issues.Add(new Issue(effortManHours, description, priority));
        }

        private void UpdateLastIssueDate()
        {
            var now = DateTime.Now;
            LastIssueDate = now.Date + "/" + now.Month + "/" + now.Year;
        }

        private static Priority EffortHigher500Critical(float effortManHours, Priority priority)
        {
            if (effortManHours > 500)
            {
                priority = Priority.Critical;
            }

            return priority;
        }

        private static Priority EffortHigher250High(float effortManHours, Priority priority)
        {
            if (effortManHours > 250)
            {
                priority = Priority.High;
            }

            return priority;
        }

        private static Priority EffortHigher100Medium(float effortManHours, Priority priority)
        {
            if (effortManHours > 100)
            {
                priority = Priority.Medium;
            }

            return priority;
        }

        private static void EffortOutOfMargins(float effortManHours)
        {
            if (effortManHours > 1000 || effortManHours <= 0)
            {
                throw new ArgumentException("Cannot register tech debt where effort is bigger than 1000 man hours to fix");
            }
        }
    }
}