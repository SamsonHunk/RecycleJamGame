using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector;
    public float speed = 1;
    public bool working { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        working = false;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {//move the player using Horizontal and vertical controls to move them on the ground
        if (!working)
        {
            moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveVector *= speed;

            controller.Move(moveVector * Time.deltaTime);
        }
    }
}
