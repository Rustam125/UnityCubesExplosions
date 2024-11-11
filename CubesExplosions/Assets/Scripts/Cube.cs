using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 100f;
    public bool IsSplittable => CheckSplittable();
    public Rigidbody Rigidbody { get; private set; }
    
    public void Init(float splitChance)
    {
        const int scaleReduction = 2;

        SplitChance = splitChance;
        transform.localScale /= scaleReduction;
        ReduceSplitChance();
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void ReduceSplitChance()
    {
        const int splitChanceReduction = 2;

        SplitChance /= splitChanceReduction;
    }

    private bool CheckSplittable()
    {
        const int minPercent = 0;
        const int maxPercent = 100;
        
        return Random.Range(minPercent, maxPercent) < SplitChance;
    }
}
