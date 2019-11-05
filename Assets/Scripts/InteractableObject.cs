using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void OnMouseDown()
    {
        int test = 0;
    }

    void OnMouseEnter()
    {
        //when the mouse moves over the object, give it a outline
    }
}
