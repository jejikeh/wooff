using System.Security.Cryptography;
using System.Text;
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

    public override void Update(float timeScale)
    {
        var s = new Random().Next(100000000).ToString();
        var temp = Encoding.ASCII.GetBytes(s);
        var tmpHash = new MD5CryptoServiceProvider().ComputeHash(temp);
        Console.WriteLine(tmpHash.GetHashCode());
    }

    public override async Task UpdateParallelAsync(float timeScale)
    {
        var s = new Random().Next(100000000).ToString();
        var temp = Encoding.ASCII.GetBytes(s);
        var tmpHash = new MD5CryptoServiceProvider().ComputeHash(temp);
        Console.WriteLine(tmpHash.GetHashCode());
    }
}