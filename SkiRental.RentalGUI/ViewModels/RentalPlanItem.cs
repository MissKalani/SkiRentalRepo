using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.ViewModels
{
    public class RentalPlanItem
    {
        private string _description;
        private RentalPlan _plan;

        public string Description { get { return _description; } }
        public RentalPlan Plan
        {
            get
            {
                return _plan;
            }

            set
            {
                _plan = value;
                _description = RentalPlanToDescription(_plan);
            }
        }

        private StringBuilder AppendDays(StringBuilder builder, int days)
        {
            if (days == 1)
            {
                builder.AppendFormat("{0} day", days);
            }
            else if (days > 1)
            {
                builder.AppendFormat("{0} days", days);
            }

            return builder;
        }

        private StringBuilder AppendHours(StringBuilder builder, int hours)
        {
            if (hours == 1)
            {
                builder.AppendFormat("{0} hour", hours);
            }
            else if (hours > 1)
            {
                builder.AppendFormat("{0} hours", hours);
            }

            return builder;
        }

        private string RentalPlanToDescription(RentalPlan plan)
        {
            StringBuilder description = new StringBuilder();
            if (plan.Duration < 24)
            {
                AppendHours(description, plan.Duration);
            }
            else
            {
                int days = plan.Duration / 24;
                AppendDays(description, days);

                int hours = plan.Duration % 24;
                AppendHours(description, hours);
            }

            int discountPercentage = (int)(-plan.Discount * 100);
            description.AppendFormat(" ({0}%)", discountPercentage);

            return description.ToString();
        }
    }
}
