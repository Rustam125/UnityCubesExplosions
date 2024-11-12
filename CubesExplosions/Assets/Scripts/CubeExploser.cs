using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeExploser
{
    private const float ExplosionForce = 1000f;
    private const float ExplosionRadius = 60f;
    
    private readonly Cube _cube;
    
    public CubeExploser(Cube cube)
    {
        _cube = cube;
    }
    
    public void Explode()
    {
        if (_cube.IsSplittable)
        {
            return;
        }
        
        var explosivePoint = _cube.transform.position;
        var cubeSize = _cube.transform.localScale.magnitude;

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
