using System;
using Wooff.ECS;
using Wooff.ECS.Components;
using Wooff.ECS.Entities;

namespace Wooff.Examples.Components
{
    public class Information : Component<InformationData>, IComponent<IConfig>
    {
        public Information(InformationData data, IEntity handler) : base(data, handler)
        {
        }

        public void WhoAmIm()
        {
            Console.WriteLine(Config.Description + Config.Name);
        }

        public override int GetId() => 1;
        IConfig IConfigurable<IConfig>.Config => Config;
    }

    public class InformationData : IConfig
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}