using System;
using System.Linq;
using Wooff.Examples.Components;
using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;

var park = new Park();
foreach (var _ in Enumerable.Range(0, 10))
{
    park.EntityContext.ContextAdd(
        new Cat("Vasya", "Fat cat"));

    park.EntityContext.ContextAdd(
        new Cat("Barsik", "Slim cat"));
}

while (true)
{
    park.Update(1f);
    var d = new Random().Next(0, 10);
    if (d != 6)
    {
        Console.WriteLine(d);
        continue;
    }

    Console.WriteLine(6);
    var itemList = park.EntityContext.Items.FindAll(
        x => x.ContextGet<Information>().Config.Description == "Vasya");
    foreach(var item in itemList)
        park.EntityContext.ContextRemove(item);
}