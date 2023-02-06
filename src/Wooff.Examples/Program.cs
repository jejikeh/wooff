using System;
using System.Threading.Tasks;
using Wooff.ECS.World;
using Wooff.Examples.Components;
using Wooff.Examples.Components.CoreComponent;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;

namespace Wooff.Examples
{
    public static class Program
    {
        public static async Task Main()
        {
            var world = await World.Load<Park>();
            foreach (var cat in world.EntityContext.GetAll<Cat>())
                cat?.GetFirst<Speaker>().Speak();
        }
    }
}