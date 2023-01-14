using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;


    private Rigidbody rb;
    private Transform tr;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-v, 0, h).normalized;

        if (direction.magnitude >= 0.1)
            tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        Vector3 drop = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = drop + direction * movementSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }

    public Transform Tr
    {
        get
        {
            return tr;
        }
    }
}
