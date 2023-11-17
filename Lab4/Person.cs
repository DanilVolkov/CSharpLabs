namespace Lab4
{
	public class Person
	{
		public int Age { get; set; }
		public string Name { get; set; }

		public Person(string name, int age)
		{
			Age = age;
			Name = name;
		}

		public virtual void Print()
		{
			Console.WriteLine($"Имя: {Name}, возраст: {Age}");
		}

		public override string ToString() => $"{Name}, {Age}";

		public static Person RandomPerson()
		{
			return new Person(PersonGenerator.GenerateRandomPerson(), new Random().Next(1, 100));
		}

		public virtual Person Clone() => new Person(Name, Age);

		public override bool Equals(object obj)
		{
			if (obj is Person other)
			{
				return Name == other.Name && Age == other.Age;
			}
			return false;
		}
		public override int GetHashCode() => HashCode.Combine(Name, Age);

	}



}
