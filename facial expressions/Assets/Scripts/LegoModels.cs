using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class LegoModels : MonoBehaviour
{
    public KeyboardInput playerInput;
    [SerializeField] public List<GameObject> legos = new List<GameObject>();
    [SerializeReference] int index = 0;
    private GameObject currentModel = null;
    private InputAction next;
    private InputAction prev;

    void Start()
    {
        currentModel = Instantiate(legos[index], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void Awake()
    {
        playerInput = new KeyboardInput();
        playerInput.Enable();
        next = playerInput.Player.NextModel;
        prev = playerInput.Player.PrevModel;
        next.performed += Next_performed;
        prev.performed += Prev_performed;
    }

    private void Prev_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(index) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void Next_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index++;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(index) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);

    }

    private void OnDisable()
    {
        playerInput.Disable();
        Destroy(currentModel);
    }
}
