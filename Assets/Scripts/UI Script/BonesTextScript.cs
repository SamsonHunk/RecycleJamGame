using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonesTextScript : MonoBehaviour
{
    Text textbox;
    string baseText;
    Tower tower;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        baseText = textbox.text;
        tower = GameObject.Find("Tower").GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        string outputText = baseText;
        outputText += tower.bones.ToString();
        textbox.text = outputText;
    }
}
