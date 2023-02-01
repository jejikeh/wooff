using Wooff.ECS.Entity;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.Entities;

public class Dog : Entity
{
    public Dog()
    {
        Add<Speaker, SpeakerData>(new SpeakerData()
        {
            Message = "\n\tHello, im am a Speaker Component\n"
        });
    }
    
    public void Woof()
    {
        Console.WriteLine($"WOOF WOOF {Get<Speaker>().Message} WOOF WOF");
    }
}