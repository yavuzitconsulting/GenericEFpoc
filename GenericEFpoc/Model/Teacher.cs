namespace GenericEFpoc.Model
{
    public class Teacher : ISharedEntityInterface
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
