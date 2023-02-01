using Wooff.Examples.Entities;
using Wooff.Examples.Worlds;



var park = new Park();
var dog = park.EntityContext.Add<Dog>();
park.Update(1f);
