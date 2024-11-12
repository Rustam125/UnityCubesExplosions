using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 100f;
    public bool IsSplittable { get; private set; } = true;
    
    public void Init(float splitChance)
    {
        const int ScaleReduction = 2;

        SplitChance = splitChance;
        transform.localScale /= ScaleReduction;
        ReduceSplitChance();
        IsSplittable = IsSplit();
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
    
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void ReduceSplitChance()
    {
        const int SplitChanceReduction = 2;

        SplitChance /= SplitChanceReduction;
    }

    private bool IsSplit()
    {
        const int MinPercent = 0;
        const int MaxPercent = 100;
        
        return Random.Range(MinPercent, MaxPercent) < SplitChance;
    }
}
