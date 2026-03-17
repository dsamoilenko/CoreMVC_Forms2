namespace CoreMVC_Forms2.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Agw { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public decimal Salary { get; set; }

        public Person(string name, string address)
        {
            Name = name;
            Address = address;
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
