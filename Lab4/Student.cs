using System.Xml.Linq;

namespace Lab4
{
    public class Student : Person
    {
        public Teacher Teacher { get; set; }

        public string Id { get; set; }

        private int course;

        public int Course {
            get
            {
                return course;
            }
            set
            {
                course = value > 0 ? value : 1;
            }
        }

        public Student( string name, int age, int course, Teacher teacher) : base(name, age)
        {
            Id = Guid.NewGuid().ToString();
            Teacher = teacher;
            course = course;
        }

        public Student(string _name, int _age, int _course) : base(_name, _age)
        {
            Id = Guid.NewGuid().ToString();
            Teacher = null;
            Course = _course;
        }

        public override void Print()
        {
            Console.WriteLine($"Имя: {Name}, возраст: {Age}, курс {Course}, учитель: {(Teacher == null ? "нет" : Teacher.Name)}");
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Age}, {Course}";
        }

        public static Student RandomStudent()
        {
            return new Student(PersonGenerator.GenerateRandomPerson(), new Random().Next(18, 25), new Random().Next(1, 7));
        }

        public override Person Clone()
        {

            return new Student(Name, Age, Course, Teacher == null ? null : (Teacher)Teacher.Clone());
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return base.Equals(obj) && Equals(Id, other.Id) && Equals(Course, other.Course);
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Id, Course);
    }

}
