using Wooff.ECS.Component;
using Wooff.Examples.Components.CoreComponent;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;

var world = new Park();
var dog = world.EntityContext
    .Add<Dog, int>(2)
        .Add<Speaker, SpeakerData>(new SpeakerData()
        {
            Message = "Hello World"
        });

foreach (var tempDog in world.EntityContext.GetAll<Dog>())
    tempDog?.Get<Speaker>().Speak();


