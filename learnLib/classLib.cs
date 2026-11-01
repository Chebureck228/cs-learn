using static System.Console;
namespace learnLib;

public class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}

public class Doctor
{
    public void TakePatients(Queue<Person> patients)
    {
        while (patients.Count > 0)
        {
            var patient = patients.Dequeue();
            WriteLine($"Осмотр пациента {patient.Name}");
        }
        WriteLine("Доктор закончил осматривать пациентов");
    }
}