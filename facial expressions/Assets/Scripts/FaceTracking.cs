using UnityEngine;

public class FaceTracking : MonoBehaviour
{
    [SerializeField] public OVRFaceExpressions FacialExpressions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (FacialExpressions == null) Debug.Log("FacialExpresion Object Refrence Valid");
        if (FacialExpressions.isActiveAndEnabled) Debug.Log("Facial Expressions not Enabled");
        if (FacialExpressions.didStart) Debug.Log("Start Called!");
    }

    // Update is called once per frame
    void Update()
    {
        if (FacialExpressions.isActiveAndEnabled) Debug.Log(FacialExpressions.GetWeight(OVRFaceExpressions.FaceExpression.JawDrop));
        
    }
}
