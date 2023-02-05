using Wooff.Examples.Components;
using Wooff.Examples.Components.CoreComponent;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;

namespace Wooff.Examples
{
    public static class Program
    {
        public static void Main()
        {
            var world = new Park();
            world.EntityContext.Add<Dog, Information, InformationData, Transform, float[], Speaker, SpeakerData>(
                new InformationData() { Name = "Hall", Description = "OGO"}, new float[] { 2f, 3f, 4f },
                new SpeakerData() { Message = "hi, i am a little message" });

            world.EntityContext.AddDog(
                new InformationData() { Name = "Halley", Description = "Its a small dog, very small in fact" },
                new SpeakerData() { Message = "hello, im a very small dog Halley" },
                1f, 2f, 3f);

            foreach (var dog in world.EntityContext.GetAll<Dog>())
                dog?.WhoAmIm();

            world.EntityContext.GetFirst<Dog>().Remove<Information>();

            foreach (var dog in world.EntityContext.GetAll<Dog>())
                dog?.WhoAmIm();
        }
    }
}