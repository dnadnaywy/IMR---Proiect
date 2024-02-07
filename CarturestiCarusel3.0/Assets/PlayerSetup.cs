using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;

    public GameObject camera;

    //public GameObject defaultCamera;

    private Camera defaultCamera;

    private void Start()
    {
        // Find the camera with the specified tag
        defaultCamera = GameObject.FindGameObjectWithTag("TempCamera").GetComponent<Camera>();

        // Check if the camera was found
        if (defaultCamera == null)
        {
            UnityEngine.Debug.LogError("Main camera not found in the scene!");
        }
    }

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        defaultCamera.gameObject.SetActive(false);
        camera.SetActive(true);
    }
}
