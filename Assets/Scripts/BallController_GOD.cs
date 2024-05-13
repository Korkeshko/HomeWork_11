using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController_GOD : MonoBehaviour
{
    private CharacterController characterController;
    private ControllerAction controllerAction;   
    private float movePower = 3f;
    private Vector2 moveInputVector;
    private Vector3 moveDirection;
    private Coroutine moveCoroutine; 

    private float gravity = -2f; 
    private float gravityCoefficient = 3;     
    private Coroutine gravityCoroutine;
    private bool isGrounded; 

    private float jumpForce = 3f;
    private Vector3 jumpVelocity;
    private Vector3 jumpStartPosition;   
    private Coroutine jumpCoroutine;    
    private bool isJumping = false;
    private bool canJump = true;
       
    void Awake()
    {    
        characterController = GetComponent<CharacterController>();
        controllerAction = new ControllerAction(); 

        isGrounded = characterController.isGrounded;
        StartGravity();

        controllerAction.Ball.Enable();
        controllerAction.Ball.Movement.performed += OnMovement;
        controllerAction.Ball.Movement.canceled += OnMovement;
        controllerAction.Ball.Jump.performed += OnJump; 
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInputVector = context.ReadValue<Vector2>();
            if (moveCoroutine == null)
            {
                moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }
        else if (context.canceled)
        {
            moveInputVector = Vector2.zero;
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }
    }

    private IEnumerator MoveCoroutine()
    {
        while (moveInputVector != Vector2.zero)
        {            
            moveDirection = new Vector3(moveInputVector.x, 0, moveInputVector.y);
            characterController.Move(moveDirection * movePower * Time.deltaTime);
            
            var angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.Euler(0, angle, 0);

            if (!characterController.isGrounded)
            {
                if (gravityCoroutine == null)
                {
                    StartGravity();
                }
            }
            yield return null;
        }
        moveCoroutine = null;
    }

    private void OnJump(InputAction.CallbackContext context)
    {        
        if (canJump && isGrounded)
        {
            if (jumpCoroutine == null)
            {  
                isJumping = true;
                canJump = false;
                jumpVelocity.y = jumpForce;
                jumpStartPosition = characterController.transform.position;
                jumpCoroutine = StartCoroutine(JumpCoroutine());
            } 
        }
    }

    private IEnumerator JumpCoroutine()
    {
        while (isJumping)
        {
            characterController.Move(jumpVelocity * Time.deltaTime);           
            if (characterController.transform.position.y > jumpStartPosition.y + 1f)
            {
                canJump = true;
                isJumping = false;
                if (jumpCoroutine != null)
                {
                    StopCoroutine(jumpCoroutine);
                    jumpCoroutine = null;
                }
                StartGravity();   
            }
            yield return null;
        }
    }

    private void StartGravity()
    {
        if (gravityCoroutine == null)
        {
            gravityCoroutine = StartCoroutine(GravityCoroutine());
            isGrounded = false;
        }
    }

    private void StopGravity()
    {
        if (gravityCoroutine != null)
        {
            StopCoroutine(gravityCoroutine);
            gravityCoroutine = null;
            isGrounded = true;
        }
    }

    private IEnumerator GravityCoroutine()
    {
        while (!characterController.isGrounded && !isJumping)
        {           
            characterController.Move(new Vector3(0, gravity * gravityCoefficient * Time.deltaTime, 0));
            yield return null;
        }

        if (characterController.isGrounded)
        {
            StopGravity();
        }   
    }
    
    

    

    // private void Rotation(Vector3 moveDirection)
    // {
    //     if (moveDirection != Vector3.zero)
    //     {
    //         // Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    //         // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    //         var angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg; 
    //         transform.rotation = Quaternion.Euler(0, angle, 0);
    //     }
    // }
}



           

        