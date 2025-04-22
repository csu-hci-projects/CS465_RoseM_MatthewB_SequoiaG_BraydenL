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
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        currentModel = Instantiate(legos[Mathf.Abs(index) % legos.Count], transform.position, transform.rotation);
        currentModel.transform.parent = transform;
    }

    private void Next_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index++;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(index) % legos.Count], transform.position, transform.rotation);
        currentModel.transform.parent = transform;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        Destroy(currentModel);
    }


    void Start()
    {
        currentModel = Instantiate(legos[index], transform.position, transform.rotation);
        currentModel.transform.parent = transform;
    }
}
