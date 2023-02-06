using Wooff.ECS;
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