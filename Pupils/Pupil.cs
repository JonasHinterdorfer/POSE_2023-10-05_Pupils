using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pupils
{
    public class Pupil
    {
        private static int _nextId;
        private readonly DateOnly _dateOfBirth;
        private int? _zipCode;
        public int Age { 
            get
            {
                return DateTime.Now.Year - _dateOfBirth.Year;
            }
        } 
        public string FirstName { get; }
        public int Id { get; }
        public string LastName { get; }
        public int? ZipCode { 
            get
            {
                return _zipCode;
            }

           set 
            {
                if(value >= 1000 & value <= 9999)
                    _zipCode = value;
            }
        }

        public Pupil(string firstName, string lastName, DateOnly dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = _nextId;
            this._dateOfBirth = dateOfBirth;
            _nextId++;
        }

        public bool IsOfAge(AgeType ageType)
        {
            return this.Age >= (int) ageType;
        }

        public bool IsOlderThan(Pupil pupil)
        {
            return pupil.Age < this.Age;
        }

        public bool LivesNearby(Pupil pupil)
        {
            if(pupil.ZipCode is null)
                return false;
            if (this.ZipCode is null)
                return false;

            return Math.Abs(Convert.ToDecimal(pupil.ZipCode - this.ZipCode)) < 100;
        }
    }
}
