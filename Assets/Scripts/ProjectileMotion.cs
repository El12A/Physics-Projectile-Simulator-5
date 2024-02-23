using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] private GameObject projectile1;
    [SerializeField] private bool airResistanceOn;

    private Vector3 initialVelocity;
    private Vector3 acceleration;

    private bool reset = true;
    private bool inMotion = false;

    private Vector3 initialPosition;
    private Vector3 displacement;


    private float timeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // set initial position of the projectile
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // as soon as the user hits the space bar this will allow the fireprojectile function to be triggered
        if (Input.GetKeyDown(KeyCode.Space) && reset == true)
        {
            inMotion = true;
            reset = false;
        }

        // when R is pressed the projectile is reset.
        if (Input.GetKeyDown(KeyCode.R) && reset == false)
        {
            ResetProjectile();
        }

        if (inMotion == true)
        {
            initialVelocity = GameControl.control.initialVelocity;
            acceleration = GameControl.control.acceleration;
            // continuosly calculates the new position of the projectile and moves the projectile to that location to simulate its movement.
            FireProjectile();
        }

    }

    private void ResetProjectile()
    {
        projectile1.transform.position = initialPosition;
        displacement = new Vector3(0.0f, 0.0f, 0.0f);
        timeElapsed = 0.0f;
        reset = true;
        inMotion = false;
    }

    private void FireProjectile()
    {
        // calculate seperately the displacement in all 3 axis of the projectile based off the acceleration and initial velovity
        displacement.y = initialVelocity.y * timeElapsed + 0.5f * acceleration.y * timeElapsed * timeElapsed;
        displacement.x = initialVelocity.x * timeElapsed + 0.5f * acceleration.x * timeElapsed * timeElapsed;
        displacement.z = initialVelocity.z * timeElapsed + 0.5f * acceleration.z * timeElapsed * timeElapsed;

        projectile1.transform.position = initialPosition + displacement;
        timeElapsed += Time.deltaTime;
    }
}
