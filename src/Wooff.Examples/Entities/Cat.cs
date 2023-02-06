using Wooff.ECS;
using Wooff.ECS.Context;
using Wooff.ECS.Entity;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.Entities;

public class Cat : Entity<Speaker>
{
    public override IInitable<Speaker> Init(Speaker data)
    {
        Add(data);
        return this;
    }
}

public static class CatExt
{
    public static Cat AddCat(this IContext<IEntity> context, SpeakerData speakerData)
    {
        var cat = context.Add<Cat, Speaker, SpeakerData>(speakerData);
        return cat;
    }
}