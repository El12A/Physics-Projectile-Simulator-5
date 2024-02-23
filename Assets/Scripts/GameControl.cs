using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> selectedVariables = new List<string>(3);
    public List<string> unselectedVariables = new List<string>(2);
    public List<GameObject> spawnInputsPrefabList;
    public string allSelectedVariableNames;
    public static GameControl control;
    private bool reset = true;
    private bool inMotion = false;

    public Vector3 initialVelocity = Vector3.zero;
    public Vector3 finalVelocity = Vector3.zero;
    public Vector3 displacement = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 time = Vector3.zero;
    
    public FindMissingVariables findMissingVariables;
    public TextController textController;

    private void Start()
    {

    }

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }

        foreach (string var in selectedVariables)
        {
            allSelectedVariableNames = allSelectedVariableNames + var;
        }
    }

    public void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 1000, 30), "selectedVariables:" + allSelectedVariableNames);
        GUI.Label(new Rect(90, 90, 1000, 30), "Displacement:" + displacement + "Initial Velocity:" + initialVelocity + "Final Velocity:" + finalVelocity + "Acceleration:" + acceleration + "Time:" + time);
    }

}

