using System;
using Unity.VisualScripting;
using UnityEngine;

public class GazeTracking : MonoBehaviour
{
    // Exposed Variables
    [SerializeField] public Camera activeCamera;
    [SerializeReference] public GameObject cakeModel; // ref to cake model to rotate
    private Vector3 pos = new Vector3(0.5f, 0.5f, 0f); // screen position to cast ray from (currently center of the screen)
    void Start()
    {
        if (activeCamera == null) throw new Exception("Invalid refrence to camera");
        if (cakeModel == null) throw new Exception("Invalid refrence to cake model");

    }

    void Update()
    {
        RaycastHit hit;
        Ray gaze = activeCamera.ScreenPointToRay(pos);
        if (Physics.Raycast(gaze, out hit)) // TODO: cast ray and check which object is hit
        {
            if (hit.collider.GetComponent<GazeTarget>())
            {
                if (hit.collider.GetComponent<GazeTarget>()) // check turn left
                {
                    Vector3 target = new Vector3(0f, 0.5f, 0);
                    cakeModel.transform.Rotate(target); // turn model left
                }
                else if (false) // check turn right
                {
                    Vector3 target = new Vector3(0f, -0.5f, 0);
                    cakeModel.transform.Rotate(target); // turn model right
                }
            }

        }
    }
}