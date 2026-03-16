using System;

namespace Task
{
    class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            EmployeeLayOff?.Invoke(this, e);
        }

        public int EmployeeID { get; set; }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _vacationStock;
        public int VacationStock
        {
            get { return _vacationStock; }
            set 
            { 
                _vacationStock = value; 

                if (_vacationStock < 0)
                {
                    OnEmployeeLayOff(
                        new EmployeeLayOffEventArgs() 
                        { 
                            Cause = LayOffCause.VacationStockNegative 
                        }
                    );
                }
            }
        }

        public bool RequestVacation(DateTime From, DateTime To)
        {
            if (To < From)
                return false;

            int days = (To - From).Days + 1;

            VacationStock -= days;   // apply the request first

            return true;
        }

        public void EndOfYearOperation()
        {
            int age = DateTime.Now.Year - BirthDate.Year;

            if (BirthDate.Date > DateTime.Now.AddYears(-age))
                age--;

            if (age > 60)
            {
                OnEmployeeLayOff(
                    new EmployeeLayOffEventArgs()
                    {
                        Cause = LayOffCause.AgeAboveSixty 
                    }
                );
            }   
        }

        override public string ToString()
        {
            return $"EmployeeID: {EmployeeID}, BirthDate: {BirthDate.ToShortDateString()}, VacationStock: {VacationStock}";
        }
    }
}