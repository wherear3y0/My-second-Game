using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 cameraOffset;
    public float speed = 50f;
    public GameManager gm;

    private Rigidbody rb;
    private Vector3 controlDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        cameraTransform.position = transform.position + cameraOffset;
        controlDirection = cameraTransform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        if(transform.position.y < -5f)
        {
            gm.EndGame();
            Debug.Log("Конец игры!");
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(controlDirection * speed * Time.deltaTime, ForceMode.VelocityChange);
    }
}
