using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CustomDataStructures;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Button buttonChangeCamera;
    [SerializeField] private Button buttonCameraFollowProjectile;
    [SerializeField] private List<GameObject> cameras;

    private CircularQueue<GameObject> cameraQueue;
    [SerializeField] private GameObject projectileCamera;

    private int numLastCamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraQueue = new CircularQueue<GameObject> (10);
        foreach (GameObject cam in cameras)
        {
            cameraQueue.Enqueue(cam);
        }
    }

    public void NextCameraInQueue()
    {
        SwitchMainCamera(cameraQueue.GetFrontItem());
    }

    public void SetProjectileCameraAsMain()
    {
        SwitchMainCamera(projectileCamera);
        numLastCamera = -1;
    }

    public void SwitchMainCamera(GameObject newMainCamera)
    {
        Debug.Log("entered");
        newMainCamera.SetActive(true);
        if (numLastCamera == -1)
        {
            Debug.Log("Deactivate projectile camera");
            projectileCamera.SetActive(false);
            numLastCamera = 0;
        }
        else
        {
            cameraQueue.Shift(1);
            cameraQueue.GetFrontItem().SetActive(false);
        }
        
    }
}
