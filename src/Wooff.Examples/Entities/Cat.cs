using Wooff.ECS;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;

namespace Wooff.Examples.Entities;

public class Cat : Entity
{
    public Cat(string descripton, string name)
    {
        ContextAdd(
            new Information(
                new InformationData() {
                    Description = descripton,
                    Name = name
                },
                this
            ));
    }
}