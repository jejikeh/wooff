using Wooff.ECS;
using Wooff.ECS.Component;
using Wooff.ECS.Entity;
using Wooff.Examples.Components.CoreComponent;

namespace Wooff.Examples.Entities;

public class Dog : Entity<int>
{
    public int Del = 1;
    
    public Dog()
    {
        Add<Transform>(x => new Transform((float)x[0], (float)x[1], (float)x[2]), 3f, 4f, 5f);
    }

    public override IInitable<int> Init(params int[] data)
    {
        Del = data[0];
        return this;
    }
}