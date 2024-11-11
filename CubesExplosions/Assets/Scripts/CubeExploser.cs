using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeExploser
{
    private const float ExplosionForce = 900f;
    private const float ExplosionRadius = 50f;
    
    public static void Explode(Cube cube)
    {
        var explosivePoint = cube.transform.position;
        var cubeSize = cube.transform.localScale.magnitude;

        var explosionRadius = ExplosionRadius / cubeSize;
        var explosionForce = ExplosionForce / cubeSize;

        foreach (var explodableObject in GetExplodableObjects(explosivePoint, explosionRadius))
        {
            explodableObject.AddExplosionForce(explosionForce, explosivePoint, explosionRadius);
        }
    }
    
    private static IEnumerable<Rigidbody> GetExplodableObjects(Vector3 explosivePoint, float explosionRadius)
    {
        var hits = Physics.OverlapSphere(explosivePoint, explosionRadius);

        return (from hit in hits where hit.attachedRigidbody != null select hit.attachedRigidbody).ToList();
    }
}
