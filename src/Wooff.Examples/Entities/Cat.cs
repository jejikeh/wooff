using System.Collections.Generic;
using Wooff.ECS;
using Wooff.ECS.Components;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;

namespace Wooff.Examples.Entities;

public class Cat : Context<IComponent<IConfig, IExampleEntity>, HashSet<IComponent<IConfig, IExampleEntity>>>, IExampleEntity
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