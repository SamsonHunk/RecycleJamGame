using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject mesh;
    public float minDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected virtual void OnMouseDown()
    {
    }

    void OnMouseEnter()
    {
        //when the mouse moves over the object, give it a outline
    }
}
