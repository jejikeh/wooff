using Wooff.ECS;
using Wooff.ECS.Context;
using Wooff.ECS.Entity;
using Wooff.Examples.Components;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.Entities;

public class Dog : Entity<Information, Transform, Speaker>
{
    public void WhoAmIm()
    {
        var information = GetFirstNullable<Information>();
        Console.WriteLine($"INFORMATION COMPONENT\nName: {information?.Data.Name}\tAge: {information?.Data.Description}");
        
        var transform = GetFirst<Transform>();
        Console.WriteLine($"TRANSFORM COMPONENT\nX: {transform.X}\tY: {transform.Y}\tZ: {transform.Z}");

        var speaker = GetFirst<Speaker>();
        Console.WriteLine($"SPEAKER COMPONENT\nSpeak: {speaker.Message}");
        speaker.Speak();
        Console.WriteLine("--- --- --- --- --- --- ---");
    }

    public override IInitable<Information, Transform, Speaker> Init(Information dataT, Transform dataT1, Speaker dataT2)
    {
        Add(dataT);
        Add(dataT1);
        Add(dataT2);

        return this;
    }
}

public static class DogExt 
{
    public static Dog AddDog(this IContext<IEntity> context, InformationData informationData, SpeakerData speakerData,
        params float[] transformData)
    {
        var dog = context.Add<Dog, Information, InformationData,Transform, float[], Speaker, SpeakerData>(informationData,transformData, speakerData);
        return dog;
    }
}