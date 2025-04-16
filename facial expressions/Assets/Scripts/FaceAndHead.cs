using UnityEngine;

public class FaceAndHead : MonoBehaviour
{

    [SerializeField] public OVRFaceExpressions _FaceTrackingComponent;
    [SerializeField] public GameObject _CakeModel;
    [SerializeField] public GameObject _Camera;
    [SerializeField] public GameObject _DrawPoint;
    [SerializeField] public OVRFaceExpressions.FaceExpression _RotateExpression;
    [SerializeField][Range(0f, 1f)] public float _Weight = 0.3f;
    [SerializeField][Range(0.1f, 2f)] public float _Speed = 1f;
    private Quaternion _Orgin;
    private bool _Rotating = false;
    private Vector3 _DrawPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_FaceTrackingComponent != null) throw new System.Exception("Invalid Refrence Face Tracking Component");
        if (_CakeModel != null) throw new System.Exception("Invalid Refrence to Cake Model");
        if (_Camera != null) throw new System.Exception("Invalid Refrence to Camera Model");
    }

    // Update is called once per frame
    void Update()
    {
        if (_FaceTrackingComponent.isActiveAndEnabled) 
        {
            if (_FaceTrackingComponent.GetWeight(_RotateExpression) >= _Weight) 
            {
                if (!_Rotating) 
                {

                    _Orgin = _Camera.transform.rotation;
                    _Rotating = true;
                }
                //Debug.Log("Origin:" + _Orgin + "\nCamera:" + _Camera.transform.localEulerAngles + "\nRotate:" + Vector3.ClampMagnitude((_Orgin - (_Camera.transform.localEulerAngles)) * _Speed, _ClampValue));

                Quaternion rotate = _Orgin * Quaternion.Inverse(_Camera.transform.rotation); //Vector3.ClampMagnitude((_Orgin - (_Camera.transform.localEulerAngles)) * _Speed, _ClampValue);
                _CakeModel.transform.Rotate(rotate.eulerAngles.x * _Speed, rotate.eulerAngles.y * _Speed, 0, Space.World);
            }
            else _Rotating = false;
        }
    }

}
