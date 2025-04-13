using System;
using TMPro;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialTextScript : MonoBehaviour
{

    // Exposed Variables
    [SerializeField] public OVRFaceExpressions FacialExpressions; // ref to face tracking component
    [SerializeField] public OVRFaceExpressions.FaceExpression EyebrowLower;
    [SerializeField] public OVRFaceExpressions.FaceExpression EyebrowRaise;
    [SerializeField][Range(0, 1.0f)] public float Weight = 0.25f; // weight value for comparing face expressions
    [SerializeField] public GameObject buttonPlane;
    [SerializeField] public Button buttonContinue;

    public TMP_Text changingText;

    public bool hasRaisedEyebrows = false;
    public bool hasLoweredEyebrows = false;
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

    private void ContinueOnClick()
    {
        SceneManager.LoadScene("Face Scene");
    }


    void Start()
    {
        buttonPlane.SetActive(false);
        buttonContinue.onClick.AddListener(ContinueOnClick);

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
        if (FacialExpressions.isActiveAndEnabled) // check if face tracking is enabled
        {
            if (FacialExpressions.GetWeight(EyebrowRaise) >= Weight) // check turn left
            {
                if (!hasRaisedEyebrows)
                {
                    hasRaisedEyebrows = true;
                    if (changedTextCount < textStore.textList.Count) { changedTextCount++; }
                    changingText.text = textTable[changedTextCount].ToString();
                }
            }
            else
            {
                hasRaisedEyebrows = false;
            }

            if (FacialExpressions.GetWeight(EyebrowLower) >= Weight) // check turn left
            {
                if (!hasLoweredEyebrows)
                {
                    hasLoweredEyebrows = true;
                    if (changedTextCount > 0) { changedTextCount--; }
                    changingText.text = textTable[changedTextCount].ToString();
                }
            }
            else
            {
                hasLoweredEyebrows = false;
            }
        }

        if (changedTextCount > textStore.textList.Count - 1) { buttonPlane.SetActive(true); }
        if (changedTextCount <= textStore.textList.Count - 1) { buttonPlane.SetActive(false); }

    }
}
