using System;
using UnityEngine;

public class FaceTracking : MonoBehaviour
{
    // Exposed Variables
    [SerializeField] public OVRFaceExpressions FacialExpressions; // ref to face tracking component
    [SerializeField] public OVRFaceExpressions.FaceExpression SpinLeft; // enums for Spin Left/Right 
    [SerializeField] public OVRFaceExpressions.FaceExpression SpinRight;
    [SerializeField] [Range(0, 1.0f)] public float Weight = 0.75f; // weight value for comparing face expressions
    [SerializeReference] public GameObject cakeModel; // ref to cake model to rotate

    void Start()
    {
        if (FacialExpressions == null) throw new Exception("No Refrence To Face Tracking Component");
        if (cakeModel == null) throw new Exception("No Refrence To Cake Model");
        if (FacialExpressions.isActiveAndEnabled) Debug.Log("Facial Expressions not Enabled");
    }

    void Update()
    {
        if (FacialExpressions.isActiveAndEnabled) // check if face tracking is enabled
        {
            if (FacialExpressions.GetWeight(SpinLeft) >= Weight) // check turn left
            {
                Vector3 target = new Vector3(0f, 0.5f, 0);
                cakeModel.transform.Rotate(target); // turn model left
            }
            else if (FacialExpressions.GetWeight(SpinRight) >= Weight) // check turn right
            {
                Vector3 target = new Vector3(0f, -0.5f, 0);
                cakeModel.transform.Rotate(target); // turn model right
            }
        }
        
    }
}
