using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class projectile : MonoBehaviour
{
    protected Dictionary<string, double> materials =
    new Dictionary<string, double>()
    {
        {"Wood", 800},
        {"Polystyrene", 30},
        {"Glass", 2600},
        {"Lead", 11343},
        {"Iron", 7870},
        {"Gold", 19320}
    };
    [SerializeField] protected string materialName;
    protected double volume;
    protected double density;
    public double mass;
    protected bool isStatic;
    [SerializeField] protected double Restution;
        
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected projectile(string material)
    {
        this.materialName = material;
        density = materials[materialName];
    }

    protected virtual double CalculateMass()
    {
        mass = density * volume;
        return mass;
    }
}
