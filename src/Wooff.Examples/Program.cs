using System.Linq;
using System.Threading.Tasks;
using Wooff.Examples.Components;
using Wooff.Examples.Components.CoreComponent;
using Wooff.Examples.Entities;
using Wooff.Examples.System;
using Wooff.Examples.Worlds;

namespace Wooff.Examples
{
    public static class Program
    {
        public static async Task Main()
        {
            var park = new Park();
            foreach (var _ in Enumerable.Range(0,5000))
            {
                park.EntityContext.AddDog(
                    new InformationData()
                    {
                        Description = "Small dog",
                        Name = "Bob"
                    },
                    new SpeakerData()
                    {
                        Message = "Whoof Whof Whooof"
                    },
                    3f, 2f, 4f);
                
                park.EntityContext.AddCat(new SpeakerData()
                {
                    Message = "Meow meoow Meoow"
                });
            }
            
            park.SystemContext.Add<Speak>();
            await park.Save("park.json");
        }
    }
}