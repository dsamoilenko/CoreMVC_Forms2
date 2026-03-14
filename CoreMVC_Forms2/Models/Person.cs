namespace CoreMVC_Forms2.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public Person(string name, string address, int age, int weight)
        {
            Name = name;
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
