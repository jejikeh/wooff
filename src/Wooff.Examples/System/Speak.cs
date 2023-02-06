using System.Numerics;
using Wooff.ECS.System;

namespace Wooff.Examples.System;

public class Moving : System<GravityData>
{
    public override void Update(float timeScale)
    {
        base.Update(timeScale);
    }
}

public struct GravityData
{
    public float Force = 2f;
    public Vector3 Direction = Vector3.Zero;

    public GravityData(float force, Vector3 direction)
    {
        Force = force;
        Direction = direction;
    }
}