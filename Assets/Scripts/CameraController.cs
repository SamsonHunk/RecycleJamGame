using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;
    Vector3 offset;
    public GameObject focus;
    public float speed = 10;
    bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Confined;
        offset = camera.transform.position - focus.transform.position;
    }

    // Update is called once per frame
    void Update()
    {//move the camera according to the mouse input if the camera is not locked to the player
        if (locked)
        {//if we are locked set the transform of the camera to the focus object's transform
            camera.transform.position = focus.transform.position + offset;
        }
        else
        {
            if (Input.mousePosition.y >= Screen.height * .95f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed, focus.transform);
            }
            else if (Input.mousePosition.y <= Screen.height * .05f)
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed, focus.transform);
            }

            if (Input.mousePosition.x >= Screen.width * .95f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed, focus.transform);
            }
            else if (Input.mousePosition.x <= Screen.width * .05f)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed, focus.transform);
            }
        }

        //if space is pressed lock the camera to the player
        if (Input.GetKeyUp(KeyCode.Space))
        {
            locked = !locked;
        }
    }
}
