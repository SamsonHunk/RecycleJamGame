using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MinionsTextScript : MonoBehaviour
{
    Text textbox;
    string baseText;
    MinionManager minionManager;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        baseText = textbox.text;
        minionManager = GameObject.Find("GameManager").GetComponent<MinionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        string outputText = baseText;
        outputText += minionManager.minions.Count.ToString();
        textbox.text = outputText;
    }
}
