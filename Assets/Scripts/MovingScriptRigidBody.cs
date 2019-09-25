using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScriptRigidBody : MonoBehaviour
{
    [SerializeField]
    private float rotationRate = 360, moveSpeed = 2;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    Rigidbody rb;

    private bool isMoving;

    Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
    }

    #region Monobehavior API
    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        animation.SetFloat("speed", moveAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    private void Move(float input)
    {
        //transform.Translate(Vector3.forward * input * moveSpeed);
        rb.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    #endregion
}
