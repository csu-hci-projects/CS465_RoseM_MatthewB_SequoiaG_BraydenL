using System;
using TMPro;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class TutorialTextScript : MonoBehaviour
{

    // Exposed Variables
    [SerializeField] public OVRFaceExpressions FacialExpressions; // ref to face tracking component
    [SerializeField] public OVRFaceExpressions.FaceExpression EyebrowRaise; // enums for Spin Left/Right 
    [SerializeField][Range(0, 1.0f)] public float Weight = 0.5f; // weight value for comparing face expressions
    public TMP_Text changingText;

    public bool hasRaisedEyebrows = false;
    public int changedTextCount = 0;

    private TextStore textStore;
    private Hashtable textTable = new Hashtable();

    [Serializable]
    public class TextStore
    {
        public List<TextBox> textList = new List<TextBox>();
    }

    [Serializable]
    public class TextBox
    {
        public int id;
        public string text;
    }

    private TextStore loadText(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        string textData = System.IO.File.ReadAllText(filePath);

        return JsonUtility.FromJson<TextStore>(textData);
    }


    void Start()
    {
        if (FacialExpressions == null) throw new Exception("No Refrence To Face Tracking Component");
        if (!FacialExpressions.isActiveAndEnabled) Debug.Log("Facial Expressions not Enabled");

        textStore = loadText("TextBoxes.json");

        foreach (TextBox textBox in textStore.textList)
        {
            textTable.Add(textBox.id, textBox.text);
        }

        changingText.text = textTable[0].ToString();
        Debug.Log(changingText.text);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasRaisedEyebrows = true;
            changedTextCount++;
            changingText.text = textTable[changedTextCount].ToString();
        }
        if (FacialExpressions.isActiveAndEnabled) // check if face tracking is enabled
        {
            if (FacialExpressions.GetWeight(EyebrowRaise) >= Weight) // check turn left
            {
                if (!hasRaisedEyebrows)
                {
                    hasRaisedEyebrows = true;
                    changedTextCount++;
                    changingText.text = textTable[changedTextCount].ToString();
                }
            }
            else
            {
                hasRaisedEyebrows = false;
            }
        }

    }
}
