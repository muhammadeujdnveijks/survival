using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float speed;
    private Rigidbody body;
    private Vector3 rotations;
    private Camera camera;
    [SerializeField]private float jumpspeed;
    void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(-transform.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(transform.right * speed);
        }
        if (body.velocity.magnitude > 10)
        {
            body.velocity = body.velocity.normalized * 10;
        }
    }

    void mouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit luch;
            if (Physics.Raycast(transform.position, -Vector3.up, out luch, 1.05f))
            {
                body.AddForce(Vector3.up * jumpspeed);
            }
        }
    }

    void rotation()
    {
        float gorizontal = Input.GetAxis("Mouse X") * mouseX;
        float vertiakal = Input.GetAxis("Mouse Y") * mouseY;
        rotations.x += -vertiakal;
        rotations.x = Mathf.Clamp(rotations.x, -90, 90);
        rotations.y += gorizontal;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotations.y, 0);
        camera.transform.rotation = Quaternion.Euler(rotations.x, rotations.y, 0);
    }
    void Start()
    {
        body = GetComponent<Rigidbody>();
        camera = Camera.main;
        mouse();
    }
    void FixedUpdate()
    {
        move();
        rotation();
        jump();
    }
    
}
