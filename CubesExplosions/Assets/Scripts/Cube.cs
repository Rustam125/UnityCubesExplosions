using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 100f;

    public event UnityAction<Cube> Split;
    public event Action Destroyed;
    
    public void Init(float splitChance)
    {
        const int scaleReduction = 2;

        SplitChance = splitChance;
        transform.localScale /= scaleReduction;
    }
    
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void OnMouseDown()
    {
        if (IsSplittable())
        {
            ReduceSplitChance();
            Split?.Invoke(this);
        }
        
        Destroy();
        Destroyed?.Invoke();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
    
    private void ReduceSplitChance()
    {
        const int splitChanceReduction = 2;

        SplitChance /= splitChanceReduction;
    }

    private bool IsSplittable()
    {
        const int minPercent = 0;
        const int maxPercent = 100;
        
        return Random.Range(minPercent, maxPercent) < SplitChance;
    }
}
