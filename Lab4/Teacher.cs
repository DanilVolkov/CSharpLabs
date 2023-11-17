using System.Xml.Linq;

namespace Lab4
{
    public class Teacher : Person
    {
        public List<Student> students { get; set; }
        public string id { get; set; }

        public Teacher(string _name, int _age, List<Student> _students) : base(_name, _age)
        {
            id = Guid.NewGuid().ToString();
            students = _students;
        }

        public Teacher(string _name, int _age) : base(_name, _age)
    {
            id = Guid.NewGuid().ToString();
            students = new List<Student>();
        }

        public override void Print()
        {
            Console.WriteLine($"Имя: {name}, возраст: {age}, список студентов: [{(students == null ? "" : string.Join(", ", students.Select(student => student.name)))}]"); 
        }

        public override string ToString()
        {
            return $"{id}, {name}, {age}";
        }

        public static Teacher RandomTeacher()
        {
            return new Teacher(PersonGenerator.GenerateRandomPerson(), new Random().Next(30, 60));
        }

        public override Person Clone()
        {
            List<Student> newStudents = new List<Student>();
            foreach (Student student in students)
            {
                var newStudent = new Student(student.name, student.age, student.course, (Teacher)student.teacher.MemberwiseClone());
                newStudents.Add(newStudent);
            }
            return new Teacher(name, age, newStudents);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return base.Equals(obj) && Equals(id, other.id);
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), id);
    }

}
