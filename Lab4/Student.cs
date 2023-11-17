using System.Xml.Linq;

namespace Lab4
{
    public class Student : Person
    {
        public Teacher teacher { get; set; }

        public string id { get; set; }

        private int _course;

        public int course {
            get
            {
                return _course;
            }
            set
            {
                _course = value > 0 ? value : 1;
            }
        }

        public Student( string _name, int _age, int _course, Teacher _teacher) : base(_name, _age)
        {
            id = Guid.NewGuid().ToString();
            teacher = _teacher;
            course = _course;
        }

        public Student(string _name, int _age, int _course) : base(_name, _age)
        {
            id = Guid.NewGuid().ToString();
            teacher = null;
            course = _course;
        }

        public override void Print()
        {
            Console.WriteLine($"Имя: {name}, возраст: {age}, курс {course}, учитель: {(teacher == null ? "нет" : teacher.name)}");
        }

        public override string ToString()
        {
            return $"{id}, {name}, {age}, {course}";
        }

        public static Student RandomStudent()
        {
            return new Student(PersonGenerator.GenerateRandomPerson(), new Random().Next(18, 25), new Random().Next(1, 7));
        }

        public override Person Clone()
        {

            return new Student(name, age, course, teacher == null ? null : (Teacher)teacher.Clone());
        }

        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return base.Equals(obj) && Equals(id, other.id) && Equals(course, other.course);
            }
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), id, course);
    }

}
