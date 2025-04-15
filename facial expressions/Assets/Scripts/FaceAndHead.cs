using UnityEngine;

public class FaceAndHead : MonoBehaviour
{

    [SerializeField] public OVRFaceExpressions _FaceTrackingComponent;
    [SerializeField] public GameObject _CakeModel;
    [SerializeField] public GameObject _Camera;
    [SerializeField] public GameObject _DrawPoint;
    [SerializeField] public OVRFaceExpressions.FaceExpression _RotateExpression;
    [SerializeField][Range(0f, 1f)] public float _Weight = 0.8f;
    private Vector3 _Orgin;
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
            Debug.Log("Tracking Enabled:");
            if (_FaceTrackingComponent.GetWeight(_RotateExpression) >= _Weight) 
            {
                if (!_Rotating) 
                {
                    _Orgin = _Camera.transform.rotation.eulerAngles;
                    _DrawPosition = _DrawPoint.transform.position;
                    _Rotating = true;
                }
                Vector3 rotate = (_Orgin - (_Camera.transform.rotation.eulerAngles)) * .1f;
                _CakeModel.transform.Rotate(rotate.x, rotate.y, 0, Space.World);
                Gizmos.DrawLine(_DrawPosition, _DrawPoint.transform.position);
            }
            else _Rotating = false;
        }
    }
}
