namespace ExcelTask
{
    internal class Person
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }

        public int PhoneNumber { get; set; }

        public Person(string lastName, string firstName, int age, int phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            PhoneNumber = phoneNumber;
        }
    }
}
