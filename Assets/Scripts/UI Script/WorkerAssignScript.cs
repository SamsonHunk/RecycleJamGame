using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerAssignScript : MonoBehaviour
{
    Text textbox;
    int numberWorkers;
    GraveHut graveHut;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Worker Script Called");
        textbox = gameObject.GetComponent<Text>();
        graveHut = GameObject.Find("GraveHut").GetComponent<GraveHut>();
        numberWorkers = 1;
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
        Debug.Log("IncreaseWorkers called");
        ++numberWorkers;
        if(numberWorkers > 3)
        {
            numberWorkers = 3;
        }
    }
    public void DecreaseWorkers()
    {
        Debug.Log("DecreaseWorkers called");

        --numberWorkers;
        if (numberWorkers < 1)
        {
            numberWorkers = 1;
        }
    }

    public void CallGraveHutFunc()
    {
        for(int i = 0; i < numberWorkers; ++i)
        {
            graveHut.AddMinionButton();
        }
    }
}
