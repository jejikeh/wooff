using Wooff.ECS;
using Wooff.ECS.Entity;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.Entities;

public class Dog : Entity<DogData>
{
    private string _name = "not set";
    private int _age;
    
    public Dog()
    {
        Add<Transform>(x => new Transform((float)x[0], (float)x[1], (float)x[2]), 3f, 4f, 5f);
    }

    public override IInitable<DogData> Init(params DogData[] data)
    {
        foreach(var dogData in data){
            _name = dogData.Name;
            _age = dogData.Age;
        }
            
        return this;
    }

    public void WhoAmIm()
    {
        Console.WriteLine($"Name: {_name}\nAge: {_age}");
    }
}

public class DogData {
    public string Name {get; set;} = "Not set";
    public int Age {get; set;}
}