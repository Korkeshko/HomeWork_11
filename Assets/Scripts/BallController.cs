using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private ControllerAction controllerAction;
    public CharacterController characterController;    
    public MovementController movement;
    public GravityController gravity;
    public JumpController jump;
    public bool isGrounded; 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        controllerAction = new ControllerAction();
        movement = new MovementController(this);
        gravity = new GravityController(this);
        jump = new JumpController(this);

        isGrounded = characterController.isGrounded;
        gravity.StartGravity();

        controllerAction.Ball.Enable();
        controllerAction.Ball.Movement.performed += movement.OnMovement;
        controllerAction.Ball.Movement.canceled += movement.OnMovement;
        controllerAction.Ball.Jump.performed += jump.OnJump;
    }
}