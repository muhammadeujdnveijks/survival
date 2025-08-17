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
    [SerializeField] private TerrainChecker check;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float RaiDistanse = 3.5f;
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
            body.velocity = body.velocity.normalized * 10;
        }
    }

    void crosshair()
    {
        Vector3 ecran = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = camera.ScreenPointToRay(ecran);
        RaycastHit luchik;
        Debug.DrawRay(ray.origin, ray.direction * RaiDistanse, Color.white);
        if (Physics.Raycast(ray, out luchik, RaiDistanse))
        {

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
            if (check.IsColayder)
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
        crosshair();
    }
    
}
