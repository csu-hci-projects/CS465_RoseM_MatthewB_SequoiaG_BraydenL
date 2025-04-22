using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class Keyboard : MonoBehaviour
{
    public KeyboardInput playerInput;
    private InputAction rotate;
    private InputAction nextScene;
    private Vector2 RotateAngle = new Vector2();
    [SerializeReference, Range(0f,1f)] float speed = 0.5f;
    [SerializeReference] public GameObject cakeModel;
    void Awake() 
    {
        playerInput = new KeyboardInput();
        playerInput.Enable();
        rotate = playerInput.Player.Rotate;
        rotate.performed += Rotate_performed;
    }

    private void Rotate_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
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
