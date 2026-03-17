namespace CoreMVC_Forms2.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal Age { get; set; }

        public decimal Weight { get; }

        public decimal Height { get; }

        public string LastName { get; set; }

        public Person(string name, string lastName, string address, int age, int weight)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            Age = age;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Person: Name: {Name}, Address: {Address}";
        }

        public void Print()
        {

        }
    }
}
