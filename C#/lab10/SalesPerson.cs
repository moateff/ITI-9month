using System;

namespace Task
{
    class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }
        public bool CheckTarget (int Quota)
        {
            if (AchievedTarget < Quota)
            {
                OnEmployeeLayOff(
                    new EmployeeLayOffEventArgs()
                    {
                        Cause = LayOffCause.TargetNotAchieved
                    }
                );

                return false;
            }

            return true;
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            // Sales person is NOT fired because of vacation stock
            if (e.Cause == LayOffCause.VacationStockNegative)
                return;

            base.OnEmployeeLayOff(e);
        }

        public override string ToString()
        {
            return base.ToString() + $", AchievedTarget: {AchievedTarget}";
        }
    }
}