using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalculateButton : VariableControllerInput
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInputtedVariables()
    {
        foreach (string var in GameControl.control.selectedVariables)
        {
            int index = GameControl.control.selectedVariables.IndexOf(var);
            if (var == "Displacement")
            {
                GameControl.control.displacement = SetVariableVector3(GameControl.control.displacement, index);
            }
            
            if (var == "Initial Velocity")
            {
                GameControl.control.initialVelocity = SetVariableVector3(GameControl.control.initialVelocity, index);
            }
            if (var == "Final Velocity")
            {
                GameControl.control.finalVelocity = SetVariableVector3(GameControl.control.finalVelocity, index);
            }
            if (var == "Acceleration")
            {
                GameControl.control.acceleration = SetVariableSingle(GameControl.control.acceleration, index);
                GameControl.control.acceleration.x = 0.0f;
                GameControl.control.acceleration.z = 0.0f;

            }
            if (var == "Time")
            {
                GameControl.control.time = SetVariableSingle(GameControl.control.time, index);
            }

        }

        GameControl.control.textController.UpdateAllText();

    }

    private Vector3 SetVariableVector3(Vector3 variable, int index)
    {
        GameObject parentObject = GameControl.control.spawnInputsPrefabList[index];

        TMP_InputField[] inputFields = parentObject.GetComponentsInChildren<TMP_InputField>();

        // Access the text of each InputField
        float inputText1 = float.Parse(inputFields[0].text);
        float inputText2 = float.Parse(inputFields[1].text);
        float inputText3 = float.Parse(inputFields[2].text);
        return new Vector3(inputText1, inputText2, inputText3);
    }

    private Vector3 SetVariableSingle(Vector3 variable, int index)
    {
        GameObject parentObject = GameControl.control.spawnInputsPrefabList[index];

        TMP_InputField[] inputFields = parentObject.GetComponentsInChildren<TMP_InputField>();
        float inputText = float.Parse(inputFields[0].text);
        return new Vector3(inputText,inputText,inputText);

    }
}
