using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionContextScript : MonoBehaviour
{
    Text textbox;
    string outputText;
    Minion self;

    // Start is called before the first frame update
    void Start()
    {
        textbox = gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>();
        if(textbox == null)
        {
            Debug.Log("Could not get textbox");
        }
        self = gameObject.GetComponent<Minion>();
    }

    // Update is called once per frame
    void Update()
    {
        outputText = self.currentCommand.ToString();
        if(self.carryAmount != 0)
        {
            outputText += "\n ";
            outputText += "Bones: ";
            outputText += self.carryAmount.ToString();
        }
        textbox.text = outputText;
    }
}
