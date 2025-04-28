using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Keyboard : MonoBehaviour
{
    public KeyboardInput playerInput;
    private InputAction rotate;
    private InputAction resetModel;
    private Vector2 RotateAngle = new Vector2();
    [SerializeReference, Range(0f,10f)] float speed = 5f;
    [SerializeReference] public GameObject cakeModel;
    void Awake() 
    {
        playerInput = new KeyboardInput();
        playerInput.Enable();
        rotate = playerInput.Player.Rotate;
        rotate.performed += Rotate_performed;
        resetModel = playerInput.Player.ResetModel;
        resetModel.performed += ResetModel_performed;
    }

    private void ResetModel_performed(InputAction.CallbackContext obj)
    {
        cakeModel.transform.rotation = Quaternion.identity;
        Debug.Log("Reset Model Rotation");
    }

    private void Rotate_performed(InputAction.CallbackContext context)
    {
        RotateAngle = (context.ReadValue<Vector2>() * speed);
    }

    void OnDisable() 
    {
        playerInput.Disable();
    }

    private void Update()
    {
        if (rotate.IsPressed())
        {
            cakeModel.transform.Rotate(RotateAngle, Space.World);
        }
        
    }
}
