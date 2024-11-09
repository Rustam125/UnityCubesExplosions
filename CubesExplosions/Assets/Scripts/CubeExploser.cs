using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeExploser : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;

    [SerializeField] private float _explosionForce;

    [SerializeField] private Cube _cube;
    
    [SerializeField] private ParticleSystem _effect;

    private void Awake()
    {
        _cube.Destroyed += Explode;
    }

    private void Explode()
    {
        Instantiate(_effect, transform.position, transform.rotation);

        foreach(var explodableObjects in GetExplodableObjects())
        {
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        var hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        return (from hit in hits where hit.attachedRigidbody != null select hit.attachedRigidbody)
            .ToList();
    }
}
