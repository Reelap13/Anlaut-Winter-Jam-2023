using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runningFactor;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minTimeBetweenJump;

    [Header("The area under your feet to check the ground")]
    [SerializeField] private Transform center;
    [SerializeField] private Transform point;


    private Rigidbody rb;
    private Transform tr;
    private Animator anim;

    private float timeBetweenJump;
    private bool isGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();

        timeBetweenJump = 0;
        isGround = false;
    }

    private void Update()
    {
        timeBetweenJump += Time.deltaTime;
        if (Player.Instance.IsMove)
        {
            Move();
            Jump();
        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-v, 0, h).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
            direction *= runningFactor;

        if (direction.magnitude >= 0.1)
            tr.rotation = Quaternion.Lerp(tr.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            Vector3 drop = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = drop + direction * movementSpeed;

        anim.SetFloat("Speed", direction.magnitude);
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && isGround && timeBetweenJump >= minTimeBetweenJump)
        {
            rb.velocity = Vector3.up * jumpForce;
            timeBetweenJump = 0;

            anim.SetTrigger("JumpStart");
        }
    }

    private void FixedUpdate()
    {
        if (timeBetweenJump >= minTimeBetweenJump)
            CheckGround();
    }

    private void CheckGround()
    {
        Collider[] colliders = Physics.OverlapSphere(center.position, (point.position - center.position).magnitude);
        isGround = colliders.Length >= 2;

        anim.SetTrigger("JumpEnd");
    }
}
