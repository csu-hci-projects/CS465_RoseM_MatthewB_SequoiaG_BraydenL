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
    private InputAction chooseModel1;
    private InputAction chooseModel2;
    private InputAction chooseModel3;
    private InputAction chooseModel4;
    private InputAction chooseModelTutorial;

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
        chooseModelTutorial = playerInput.Player.ChooseModel0;
        chooseModel1 = playerInput.Player.ChooseModel1;
        chooseModel2 = playerInput.Player.ChooseModel2;
        chooseModel3 = playerInput.Player.ChooseModel3;
        chooseModel4 = playerInput.Player.ChooseModel4;

        next.performed += Next_performed;
        prev.performed += Prev_performed;
        chooseModelTutorial.performed += ChooseModelTutorial_performed;
        chooseModel1.performed += ChooseModel1_performed;
        chooseModel2.performed += ChooseModel2_performed;
        chooseModel3.performed += ChooseModel3_performed;
        chooseModel4.performed += ChooseModel4_performed;
    }

    private void ChooseModelTutorial_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(0) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void ChooseModel1_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(1) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void ChooseModel2_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(2) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void ChooseModel3_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(3) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
    }

    private void ChooseModel4_performed(InputAction.CallbackContext obj)
    {
        Destroy(currentModel);
        index--;
        Debug.Log(Mathf.Abs(index) % legos.Count);
        currentModel = Instantiate(legos[Mathf.Abs(4) % legos.Count], transform.position, transform.rotation, transform);
        transform.localScale = new Vector3(.05f, .05f, .05f);
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
