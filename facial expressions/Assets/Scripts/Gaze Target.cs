using UnityEngine;

public class GazeTarget : MonoBehaviour
{
    [SerializeField] public enum direction {right, left};
    Material material;

    private void Start()
    {
        var myMaterial = GetComponent<Renderer>().material; //get mateiral of object to change color
    }

    public void changeColor(bool isGaze) 
    {
        if (isGaze) material.color = Color.green; 
        else material.color = Color.red;
    }
}
