using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionContextScript : MonoBehaviour
{
    Text textbox;
    string outputText;
    Minion self;
    Camera camera;
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        textbox = canvas.GetComponentInChildren<Text>();
        if(textbox == null)
        {
            Debug.Log("Could not get textbox");
        }
        self = gameObject.GetComponent<Minion>();
        camera = GameObject.Find("Camera").GetComponent<Camera>();
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

        Vector3 v = camera.transform.position - canvas.transform.position;
        v.x = v.z = 0.0f;
        canvas.transform.LookAt(camera.transform.position - v);
        canvas.transform.Rotate(0, 180, 0);
    }
}
