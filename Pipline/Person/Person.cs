using System;

namespace ElZino.Models.PersonLib
{
    public class Person
    {
        private string firstName;
        private string lastName;
        public Person() { }
        public Person(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LasttName = lastname;
        }
        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(FirstName)}");
                this.firstName = value;
            }
        }
        public string LasttName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception($"{nameof(Person)}:{nameof(LasttName)}");
                this.lastName = value;
            }
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LasttName}";
        }
    }
}
