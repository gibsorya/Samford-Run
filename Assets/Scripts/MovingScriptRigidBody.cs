using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScriptRigidBody : MonoBehaviour
{
    [SerializeField] private float rotationRate = 360, moveSpeed = 2, maxSpeed, jumpForce;
    private float time;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    private float addSpeed;
    Rigidbody rb;

    public GameObject Body;
    public GameObject Car;
    public bool isGamePaused;
    Animator animation;
    private bool isAddSpeed;
    private float currtime;

    private Again Again;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
        Again = GetComponent<Again>();
        Car.SetActive(false);
    }

    #region Monobehavior API

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        animation.SetFloat("speed", moveAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        if (!isGamePaused)
        {
            ApplyInput(moveAxis, turnAxis);
            if (isAddSpeed)
            {
                currtime += Time.deltaTime;
                if (currtime >= time)
                {
                    moveSpeed = this.moveSpeed - addSpeed;
                    isAddSpeed = false;
                    currtime = 0;
                }
            }

           
            if (Input.GetMouseButton(0) && isGround)
            {
                Debug.Log("Mouse clicked");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

            checkGround();
        }
    }

    public void Invincible()
    {
        SetSpeed(20, 10);
        Again.IsInvincible = true;
        Body.SetActive(false);
        Car.SetActive(true);
    }

    public void NotInvincible()
    {
        Again.IsInvincible = false;
        Body.SetActive(true);
        Car.SetActive(false);
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

    public void SetSpeed(int Addspeed, float timer)
    {
        addSpeed = Addspeed;
        isAddSpeed = true;
        moveSpeed = moveSpeed + addSpeed;
        time = timer;
    }

    public CapsuleCollider capsuleCollider;

    private bool isGround;

    void checkGround()
    {
        RaycastHit hit;
        float shellOffset = 0.01f;
        float groundCheckDistance = 0.01f;
        Vector3 currentPosition = transform.position;
        currentPosition.y += capsuleCollider.height / 2;
        if (Physics.SphereCast(currentPosition, capsuleCollider.radius * (1.0f - shellOffset), Vector3.down, out hit,
            ((capsuleCollider.height / 2f) - capsuleCollider.radius) + groundCheckDistance, ~0,
            QueryTriggerInteraction.Ignore))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    

    #endregion
}