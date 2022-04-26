// Some stupid rigidbody based movement by Dani

using System;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 velocity;
    private Vector3 moveInput;
    private Vector3 camRotation;
    public GameObject head;
    [SerializeField] private float moveSpeed;
    private float playerAngle;
    private Vector3 moveInputRelative;
    private float gravity = 9.8f;
    private float velocityY;
    public float jumpMagnitude = 0f;


    public void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");

        camRotation.x = 0f;
        camRotation = head.transform.eulerAngles;

        velocityY -= gravity * (Time.deltaTime / 60f);

        if (cc.isGrounded)
        {
            velocityY = 0f;
        }

        if (Input.GetAxisRaw("Jump") != 0 && cc.isGrounded)
        {
            velocityY = jumpMagnitude;
        }

        velocity.y = velocityY;

        moveInput = new Vector3(movex, 0f, movez);
        moveInputRelative = Quaternion.Euler(camRotation) * moveInput;
        moveInputRelative = Vector3.ProjectOnPlane(moveInputRelative, Vector3.down);
        moveInputRelative = Vector3.ClampMagnitude(moveInputRelative, 1f);

        velocity = Vector3.Lerp(velocity, moveInputRelative * (moveSpeed / 5), Time.deltaTime * 25f);

        cc.Move(velocity);
    }
}

