using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerAssignScript : MonoBehaviour
{
    Text textbox;
    int numberWorkers = 1;

    // Start is called before the first frame update
    void Start()
    {
        textbox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string outputText = "Assign ";
        outputText += numberWorkers.ToString();
        outputText += "\n";
        if(numberWorkers == 1)
        {
            outputText += "Worker";
        }
        else
        {
            outputText += "Workers";
        }
        textbox.text = outputText;
    }

    public void IncreaseWorkers()
    {
        ++numberWorkers;
        if(numberWorkers > 3)
        {
            numberWorkers = 3;
        }
    }
    public void DecreaseWorkers()
    {
        --numberWorkers;
        if (numberWorkers < 1)
        {
            numberWorkers = 1;
        }
    }
}
