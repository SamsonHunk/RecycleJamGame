using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera camera;
    public GameObject focus;
    public float speed = 10;
    Vector3 initial;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        initial = camera.transform.localPosition;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetAxis("Refocus") > 0)
        {
            camera.transform.localPosition = initial; 
        }
    }
}
