using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMotion : MonoBehaviour
{
    public float speed = 0.006f;
    public float zoomSpeed = 10.0f;
    public float rotateSpeed = 0.1f;

    public float maxHeight = 40f;
    public float minHeight = 4f;

    public Camera camera;
    public bool Orthographic;
    Vector2 p1;
    Vector2 p2;

    void Start()
    {
        camera = transform.GetChild(0).gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (camera.orthographic == true)
        {
            camera.transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
            transform.position = new Vector3(-4.55f, 8.74f, -0.7f);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 0.006f;
                zoomSpeed = 20.0f;
            }
            else
            {
                speed = 0.0035f;
                zoomSpeed = 10.0f;
            }
            float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
            float vsp = transform.position.y * speed * Input.GetAxis("Vertical");
            float scrollSp = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

            if ((transform.position.y >= maxHeight) && (scrollSp > 0))
            {
                scrollSp = 0;
            }
            else if ((transform.position.y <= minHeight) && (scrollSp < 0))
            {
                scrollSp = 0;
            }

            if ((transform.position.y + scrollSp) > maxHeight)
            {
                scrollSp = maxHeight - transform.position.y;
            }
            else if ((transform.position.y + scrollSp) < minHeight)
            {
                scrollSp = minHeight - transform.position.y;
            }

            Vector3 verticalMove = new Vector3(0, scrollSp, 0);
            Vector3 lateralMove = hsp * transform.right;
            Vector3 forwardMove = transform.forward;
            forwardMove.y = 0;
            forwardMove.Normalize();
            forwardMove *= vsp;

            Vector3 move = verticalMove + lateralMove + forwardMove;
            transform.position += move;

            getCameraRotation();
        }
    }

    void getCameraRotation()
    {
        if(Input.GetMouseButtonDown(2)) 
        {
            p1 = Input.mousePosition;
        }
        if (Input.GetMouseButton(2))
        {
            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotateSpeed;
            float dy = (p2 - p1).y * rotateSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));

            p1 = p2;
        }
    }
    

}

