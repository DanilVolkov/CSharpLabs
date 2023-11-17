using System.Xml.Linq;

namespace Lab4
{
    public class Teacher : Person
    {
        public List<Student> Students { get; set; }
        public string Id { get; set; }

        public Teacher(string name, int age, List<Student> students) : base(name, age)
        {
            Id = Guid.NewGuid().ToString();
            Students = students;
        }

        public Teacher(string name, int age) : base(name, age)
    {
            Id = Guid.NewGuid().ToString();
            Students = new List<Student>();
        }

        public override void Print()
        {
            Console.WriteLine($"Имя: {Name}, возраст: {Age}, список студентов: [{(Students == null ? "" : string.Join(", ", Students.Select(student => student.Name)))}]"); 
        }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Age}";
        }

        public static Teacher RandomTeacher()
        {
            return new Teacher(PersonGenerator.GenerateRandomPerson(), new Random().Next(30, 60));
        }

        public override Person Clone()
        {
            List<Student> newStudents = new List<Student>();
            foreach (Student student in Students)
            {
                var newStudent = new Student(student.Name, student.Age, student.Course, (Teacher)student.Teacher.MemberwiseClone());
                newStudents.Add(newStudent);
            }
            return new Teacher(Name, Age, newStudents);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return base.Equals(obj) && Equals(Id, other.Id);
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), Id);
    }

}
