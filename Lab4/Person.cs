namespace Lab4
{
	public class Person
	{
		public int age { get; set; }
		public string name { get; set; }

		public Person(string _name, int _age)
		{
			age = _age;
			name = _name;
		}

		public virtual void Print()
		{
			Console.WriteLine($"Имя: {name}, возраст: {age}");
		}

		public override string ToString() => $"{name}, {age}";

		public static Person RandomPerson()
		{
			return new Person(PersonGenerator.GenerateRandomPerson(), new Random().Next(1, 100));
		}

		public virtual Person Clone() => new Person(name, age);

		public override bool Equals(object obj)
		{
			if (obj is Person other)
			{
				return name == other.name && age == other.age;
			}
			return false;
		}
		public override int GetHashCode() => HashCode.Combine(name, age);

	}



}
