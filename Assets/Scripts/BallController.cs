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
    private float gravity = -1.5f; 
    private float coefficient = 3;

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

    private void FixedUpdate() 
    {
        Gravity();
        ////characterController.Move(direction * power * Time.deltaTime);
    }

    private void Movement(InputAction.CallbackContext context)
    {        
        if (context.performed) // ? performed
        {    
            inputVector = context.ReadValue<Vector2>();
            direction = new Vector3(inputVector.x, 0, inputVector.y);
            characterController.Move(direction * power);

            Rotation();         

            ////rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * power, ForceMode.VelocityChange);
            ////rb.velocity = new Vector3(inputVector.x, 0, inputVector.y);
        }    
    }
    
    private void Rotation()
    {
        if (inputVector.sqrMagnitude == 0) { return; }  // ? performed

        var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void Gravity()
    {
        if (!characterController.isGrounded)
            characterController.Move(new Vector3(0, gravity * coefficient * Time.deltaTime, 0));

        //transform.position += Vector3.zero * Time.deltaTime;
        //transform.position.y += gravity * Time.deltaTime;
    }

    private void Jump(InputAction.CallbackContext context)
    { 
        ////rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        
        if (characterController.isGrounded)
            StartCoroutine(Rising(characterController));

        //characterController.Move(new Vector3(0, context.ReadValue<Vector2>().y, 0)); ?
        //characterController.Move(new Vector3(0, 1, 0));
    }

    private IEnumerator Rising(CharacterController character)
    {
        float limitTimer = 1f;
        float timer = 0.0f;
       
        while ((timer += Time.deltaTime) <= limitTimer)
        {
            character.Move(new Vector3(0, timer*100/limitTimer / 100 * Time.deltaTime, 0));
        }
        yield return null;  
    }
}



           

        