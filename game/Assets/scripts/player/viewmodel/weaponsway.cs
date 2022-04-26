using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class weaponsway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;
    private Vector3 _startPosition;
    public CharacterController cc;
    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    private void Update()
    {
        Vector3 weaponBob = new Vector3(0.0f, Mathf.Sin(Time.time * 6f) * 0.08f, 0.0f);

        if ((Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f) && cc.isGrounded)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, weaponBob, Time.deltaTime * 4f);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _startPosition, Time.deltaTime * 4f);
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Mathf.Clamp(mouseX, -10f, 10f);
        Mathf.Clamp(mouseY, -10f, 10f);

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;



        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
