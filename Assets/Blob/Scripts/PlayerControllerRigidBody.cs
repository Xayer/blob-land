using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidBody : MonoBehaviour
{
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = 10;

    public float jumpVelocity = 100;

    private Rigidbody body;

    void Start(){
        body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        ApplyInput(moveAxis, turnAxis);
        if(Input.GetKeyDown("space")) {
            Jump();
        }
    }

    private void ApplyInput(float moveInput, float turnInput){
        Move(moveInput);
        Turn(turnInput);

    }
    private void Move(float input){
        // transform.Translate(Vector3.forward * input * moveSpeed); // You can also use time.DeltaTime instead of MoveSpeed
        body.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
    }

    private void Turn(float input){
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    private void Jump(){
        Debug.Log("space was pressed");
        body.AddForce(transform.up * jumpVelocity * moveSpeed, ForceMode.Force);
    }
}