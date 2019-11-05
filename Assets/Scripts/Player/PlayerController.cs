using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Camera playerCamera;
    Vector3 moveVector;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {//move the player using Horizontal and vertical controls to move them on the ground
        moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveVector *= speed;

        controller.Move(moveVector * Time.deltaTime);


    }
}
