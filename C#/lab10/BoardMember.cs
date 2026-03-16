using System;

namespace Task
{
    class BoardMember : Employee
    {
        public void Resign ()
        {
            OnEmployeeLayOff(
                new EmployeeLayOffEventArgs()
                {
                    Cause = LayOffCause.Resigned
                }
            );
        }

        protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            // Board member:
            // - not fired because of age
            // - not fired because of vacation stock
            if (e.Cause == LayOffCause.AgeAboveSixty ||
                e.Cause == LayOffCause.VacationStockNegative)
                return;

            base.OnEmployeeLayOff(e);
        }

        public override string ToString()
        {
            return base.ToString() + ", BoardMember";
        }
    }
}