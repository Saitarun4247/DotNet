
public class Student
{
	public int RollNo { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }

	public Student() { }

	public Student(int id, string name, string city)
	{
		RollNo = id;
		Name = name;
		Address = city;
	}

	public void DisplayDetails()
	{
		System.Console.WriteLine($"RollNo: {RollNo}\nName: {Name}\nAddress: {Address}");
	}
}
