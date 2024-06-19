using System.Collections.Generic;
using System.Linq;
using Wooff.ECS.Contexts;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;
using NotImplementedException = System.NotImplementedException;

namespace Wooff.Examples.System;

public class Speak : IExampleSystem
{
    public void Process(float timeScale, IContext<IExampleEntity, List<IExampleEntity>> data)
    {
        foreach(var information in data.Items
                    .Select(x => x.ContextGet<Information>()))
            information?.WhoAmIm();
    }
}