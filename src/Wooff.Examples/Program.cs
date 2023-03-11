using System;
using System.Diagnostics;
using System.Linq;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;
using Wooff.Examples.System;
using Wooff.Examples.Worlds;

var park = new Park();
park.SystemContext.ContextAdd(new Speak());
park.SystemContext.ContextAdd(new SpeadyMinimalIncrease());

foreach (var _ in Enumerable.Range(0, 100))
{
    park.EntityContext.ContextAdd(
        new Entity(new Information
        {
            Title = "Vasya",
            Description = "Fat cat"
        },
            new Speedy
            {
                Speed = -10f
            }));

    park.EntityContext.ContextAdd(
        new Entity(new Information
        {
            Title = "Bobik",
            Description = "Fit cat"
        }, 
            new Speedy()
            {
                Speed = 100f
            }));
}

var st = new Stopwatch();
st.Start();

while (true)
{
    park.SystemContext.Process(1f, park.EntityContext);

    Console.WriteLine(6);
    var itemList = park.EntityContext.ContextWhereQuery(
        x => x.ContextGet<Information>()?.Title == "Vasya");

    if (itemList.ToList().Count == 0)
        break;
    
    foreach(var item in itemList.ToList())
        park.EntityContext.ContextRemove(item);
}

st.Stop();
Console.WriteLine(st.ElapsedMilliseconds);