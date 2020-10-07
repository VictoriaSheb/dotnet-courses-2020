using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Employee : User
    {
        public string Position { set; get; }
        public DateTime DateStartWork { private set; get; }
        public int WorkExperience 
        {
            get 
            {
                if (DateEndWork==null)
                    return CountYears(DateStartWork);
                else
                    return CountYears(DateStartWork)-CountYears((DateTime)DateEndWork);
            } 
        }

        public DateTime? DateEndWork 
        {
            private set;
            get; 
        }

        private bool statusEmployee;

        public bool StatusEmployee 
        {
            set 
            {
                if (value) 
                {
                    DateStartWork = DateTime.Now;
                    DateEndWork = null;
                }
                else
                {
                    DateEndWork = DateTime.Now;
                }
                statusEmployee = value;
            }
            get 
            {
                return statusEmployee;
            } 
        }

        public Employee(string firstName, string middleName, string lastName, DateTime dateOfBirth, string position, DateTime startWork) : base(firstName, middleName, lastName, dateOfBirth) 
        {
            DateStartWork = CheckWorkExperience(CheckDate(startWork,70));
            Position = position;
            StatusEmployee = true;
        }


        protected DateTime CheckWorkExperience(DateTime startWork) 
        {
            if (Age - CountYears(startWork) <= 20)
                throw new ArgumentOutOfRangeException($"{nameof(startWork)}", $"Значение не возможно для возраста сотрудника с возрастом {Age} ");
            else
                return startWork;

        }

        //public void ChangePosition(string newPosition) 
        //{
        //    this.Position = newPosition;
        //}

    }
}
