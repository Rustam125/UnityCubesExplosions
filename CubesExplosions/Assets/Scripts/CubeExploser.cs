using System.Collections.Generic;
using JetBrains.Annotations;

public class CubeExploser
{
    private const float ExplosionForce = 700f;
    
    public static void Explode([CanBeNull] List<Cube> cubes)
    {
        if (cubes is null)
        {
            return;    
        }
        
        foreach (var cube in cubes)
        {
            cube.Rigidbody.AddForce(-cube.Rigidbody.velocity * ExplosionForce);
        }
    }
}
