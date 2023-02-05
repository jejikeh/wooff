
using Wooff.ECS;
using Wooff.ECS.Component;

namespace Wooff.Examples.Components
{
    public class Information : IComponent<InformationData>
    {
        public InformationData Data;

        public IInitable Init(params object[] data)
        {
            foreach (var obj in data)
                if (obj is InformationData informationData)
                    Data = informationData;

            return this;
        }

        public IInitable<InformationData> Init(InformationData data)
        {
            Data = data;
            return this;
        }

        public IInitable<InformationData> Init(params InformationData[] data)
        {
            Data = data[0];
            return this;
        }
    }

    public struct InformationData
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}