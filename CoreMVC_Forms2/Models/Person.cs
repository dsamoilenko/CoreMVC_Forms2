namespace CoreMVC_Forms2.Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Agw { get; set; }

        public int Weight { get; set; }

        public Person()
        {
                
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
