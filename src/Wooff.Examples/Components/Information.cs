using System;
using Wooff.ECS;
using Wooff.ECS.Components;

namespace Wooff.Examples.Components
{
    public class Information : Component<InformationData, IExampleEntity>, IComponent<IConfig, IExampleEntity>, IComponent<InformationData, IExampleEntity>
    {
        public Information(InformationData data, IExampleEntity handler) : base(data, handler)
        {
        }

        public void WhoAmIm()
        {
            Console.WriteLine(Config.Description + Config.Name);
        }

        IConfig IConfigurable<IConfig>.Config => Config;
    }
}