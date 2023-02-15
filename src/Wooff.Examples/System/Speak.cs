using System.Collections.Generic;
using System.Linq;
using Wooff.ECS;
using Wooff.ECS.Context;
using Wooff.ECS.Entities;
using Wooff.Examples.Components;

namespace Wooff.Examples.System;

public class Speak : ECS.Systems.System
{
    public override void Process(float timeScale, IContext<IEntity, List<IEntity>> data)
    {
        foreach(var information in data.Items
                    .Select(x => x.ContextGet<Information>()))
                information?.WhoAmIm();
    }
}