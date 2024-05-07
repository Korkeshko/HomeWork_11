using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    ////private Rigidbody rb;
    private CharacterController characterController;
    private ControllerAction controllerAction;   
    private Vector2 inputVector;
    private Vector3 direction;
    private float power = 0.5f;
    // private float gravity = -10f;   

    void Awake()
    {
        ////rb = GetComponent<Rigidbody>(); 
        characterController = GetComponent<CharacterController>();
        controllerAction = new ControllerAction();   

        controllerAction.Ball.Enable();
        controllerAction.Ball.Movement.performed += Movement;
        controllerAction.Ball.Jump.performed += Jump;
        
        var action = new InputAction("Movement", InputActionType.PassThrough);
        action.performed += Movement;
        action.Enable(); 
    }

    // private void FixedUpdate() 
    // {
    //     Gravity();
    //     ////characterController.Move(direction * power * Time.deltaTime);
    // }

    private void Movement(InputAction.CallbackContext context)
    {        
        if (context.performed)
        {    
            inputVector = context.ReadValue<Vector2>();
            direction = new Vector3(inputVector.x, 0, inputVector.y);
            characterController.Move(direction * power);

            Rotation();         

            ////rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * power, ForceMode.VelocityChange);
            ////rb.velocity = new Vector3(inputVector.x, 0, inputVector.y);
        }    
    }

    private void Jump(InputAction.CallbackContext context)
    {
        ////rb.AddForce(Vector3.up * power, ForceMode.Impulse);
    }
    
    private void Rotation()
    {
        if (inputVector.sqrMagnitude == 0) { return; } 
        
        var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    // private void Gravity()
    // {
    //     //transform.position += Vector3.zero * Time.deltaTime;
    //     //transform.position.y += gravity * Time.deltaTime;
    // }
}