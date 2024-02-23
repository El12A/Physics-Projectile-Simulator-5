using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereProjectile : projectile
{
    [SerializeField] private double radius;
    // Start is called before the first frame update
    void Start()
    {
        CalculateVolume();
        CalculateMass();
        SetSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public sphereProjectile(string material, double r) : base(material)
    {
        this.materialName = material;
        density = materials[materialName];
        radius = r;
        CalculateVolume();
        CalculateMass();
    }
    public double CalculateVolume()
    {
        // Volume formula for sphere: v = 4/3 x pi x r^3
        volume = (4 / 3) * Mathf.PI * radius * radius * radius;
        return volume;
    }

    public void SetSize()
    {
        //sphere model has default of 0.5m radius when scale is all set to 1
        //therefore the object has to scale by the radius (in metres) times 2 to get correct scale for desired radius
        float newScale = 2.0f * ((float)radius);
        transform.localScale =  new Vector3(newScale, newScale, newScale);
    }


}
