namespace Pupils
{
    public class Pupil
    {
        private static int _nextId;
        private readonly DateOnly _dateOfBirth;
        private int? _zipCode;
        public int Age => DateTime.Now.Year - _dateOfBirth.Year;

        public string FirstName { get; }
        public int Id { get; }
        public string LastName { get; }
        public int? ZipCode { 
            get => _zipCode;
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
            
            if (this.ZipCode is null)
                return false;
            if(pupil.ZipCode is null)
                return false;
      
            int first2DigitsForeignZip = (int) (pupil.ZipCode / 100);
            int first2DigitsOwnZip = (int) (this.ZipCode / 100);

            return first2DigitsForeignZip == first2DigitsOwnZip;
        }
    }
}
