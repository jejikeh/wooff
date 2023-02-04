using Wooff.Examples.Components.CoreComponent;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;

internal class Program
{
    private static void Main(string[] args)
    {
        var world = new Park();
        foreach(var i in Enumerable.Range(0,10))
            world.EntityContext.Add<Dog, DogData>(new DogData() {
                Name = HashToString(new Random().Next(100000000)),
                Age = ((char)((byte)new Random().Next()))
            }).Add<Speaker, SpeakerData>(new SpeakerData()
                {
                    Message = "Hello World"
                });

        foreach (var tempDog in world.EntityContext.GetAll<Dog>()) {
            tempDog?.Get<Speaker>().Speak();
            tempDog?.WhoAmIm();
        }
    }

    private static string HashToString(int hash, int asciiShift = 97, int asciiWidth = 17)
    {
        var random = new Random();
        var resultString = string.Empty;
        var digits = hash == 0L ? 1 : (hash > 0L ? 1 : 2) + (int)Math.Log10(Math.Abs((double)hash));
        foreach(var _ in Enumerable.Range(0, digits))
            resultString += (char)(((int)(hash / (Math.Pow(10, random.Next(digits)))) % 10) + (random.Next(asciiWidth) + asciiShift));

        return resultString;
    }
}