using Lab4;

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            Person.RandomPerson(),
            Student.RandomStudent(),
            Teacher.RandomTeacher(),
            Student.RandomStudent()
        };


        foreach (var person in people)
        {
            Console.WriteLine($"ToString(): {person}");
            Console.Write("Print(): ");
            person.Print();
        }
        Console.WriteLine();

        Console.WriteLine("Методы Equals, GetHashCode:");
        Person person1 = new Person("Егор", 25);
        Person person2 = new Person("Анастасия", 25);

        Console.WriteLine(person1.Equals(person2));
        Console.WriteLine(person1.GetHashCode());
        Console.WriteLine(person2.GetHashCode());

        Console.WriteLine();

        Student stud = new Student("Джон", 20, 3);
        Student stud1 = new Student("Джон", 20, 3);
        Console.WriteLine(stud.Equals(stud1));
        Console.WriteLine(stud.GetHashCode());
        Console.WriteLine(stud1.GetHashCode());
        stud1.id = stud.id;
        Console.WriteLine(stud.Equals(stud1));

        Console.WriteLine();
        Console.WriteLine("Подсчет количества людей: ");

        int personsCount = 0, studentsCount = 0, teachersCount = 0;

        foreach (var person in people)
        {
            if (person is Student)
            {
                studentsCount++;
            }
            else if (person is Teacher)
            {
                teachersCount++;
            }
            else
            {
                personsCount++;
            }
        }

        Console.WriteLine($"Людей: {personsCount}, студентов: {studentsCount}, преподавателей: {teachersCount}");
        Console.WriteLine();

        Console.WriteLine("Перевод студентов на следующий курс: ");

        foreach (var person in people)
        {
            if (person is Student student)
            {
                Console.Write($"Курс студента: {student.course}. Переведен на ");
                student.course++;
                Console.WriteLine($"{student.course} курс");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Копирование: ");

        Student s = Student.RandomStudent();
        s.teacher = Teacher.RandomTeacher();
        Console.Write("Студент до изменения: ");
        s.Print();

        Teacher t = Teacher.RandomTeacher();
        t.students.Add(s);
        Console.Write("Учитель до изменения: ");
        t.Print();
        s.teacher = t;
        Console.Write("Учитель после добавления студента: ");
        t.Print();

        Console.Write("Студент после добавления учителя: ");
        s.Print();

        Teacher t1 = (Teacher)t.Clone();
        Console.Write("Учитель после копирования: ");
        t1.Print();
        t1.students.Add(Student.RandomStudent());
        Console.Write("Учитель (копия) после добавления еще 1 студента: ");
        t1.Print();
        Console.Write("Исходный учитель: ");
        t.Print();
        Student s1 = (Student)s.Clone();
        s1.teacher.age = 12;
        Console.Write("Учитель копированного студента после изменения его возраста: ");
        s1.teacher.Print();
        Console.Write("Учитель исходный: ");
        s.teacher.Print();
        Console.Write("Студент скопированного учителя: ");
        t1.students[0].Print();
        t1.students[0].age = 12;
        Console.Write("Студент скопированного учителя после изменения возраста: ");
        t1.students[0].Print();
        Console.Write("Исходный учитель до копирования: ");
        t.students[0].Print();

        Console.WriteLine();
        Console.WriteLine("Копирование на примере массива людей:");

        List<Person> clonedPeople = new List<Person>();
        for (int i = 0; i < people.Count; i++)
        {
            clonedPeople.Add(people[i].Clone());
            Console.WriteLine($"Clone {clonedPeople[i].GetType()}: {clonedPeople[i]}");
        }

        Console.WriteLine();
        Console.WriteLine("Исползование BaseType и GetType:");

        foreach (var person in people)
        {
            PrintAncestors(person.GetType());
        }

        void PrintAncestors(Type type)
        {
            Console.Write($"Иерархия предков {type.Name}: ");
            while (type != null)
            {
                Console.Write($"{type.Name} ");
                type = type.BaseType;
            }
            Console.WriteLine();
        }
    }
}
