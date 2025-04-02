using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 6f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHoriz = Input.GetAxis("Horizontal");
        float inputVert = Input.GetAxis("Vertical");
        player.velocity = new Vector3(inputHoriz * movementSpeed, player.velocity.y, inputVert * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
           player.velocity = new Vector3(player.velocity.x, jumpForce, player.velocity.z);

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
