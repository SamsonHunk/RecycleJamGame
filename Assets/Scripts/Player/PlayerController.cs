using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector;
    public float speed = 1;
    public bool working { get; set; }
    float rotation;

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
            if (Input.GetKey(KeyCode.W))
            {
                rotation = 0;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotation = 90;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rotation = 180;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rotation = 270;
            }

            this.transform.localRotation = Quaternion.Euler(new Vector3(0, rotation, 0));
            controller.Move(moveVector * Time.deltaTime);
        }
    }
}
