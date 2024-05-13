using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController
{
    private BallController ballController;
    private float movePower = 3f;
    private Vector2 moveInputVector;
    private Coroutine moveCoroutine;

    public MovementController(BallController ballController)
    {
        this.ballController = ballController;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInputVector = context.ReadValue<Vector2>();
            if (moveCoroutine == null)
            {
                moveCoroutine = ballController.StartCoroutine(MoveCoroutine());
            }
        }
        else if (context.canceled)
        {
            moveInputVector = Vector2.zero;
            if (moveCoroutine != null)
            {
                ballController.StopCoroutine(moveCoroutine);
                moveCoroutine = null;
            }
        }
    }

    private IEnumerator MoveCoroutine()
    {
        while (moveInputVector != Vector2.zero)
        {
            Vector3 moveDirection = new Vector3(moveInputVector.x, 0, moveInputVector.y);
            ballController.characterController.Move(moveDirection * movePower * Time.deltaTime);

            var angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            ballController.transform.rotation = Quaternion.Euler(0, angle, 0);

            // при движении по земле characterController.isGrounde не корректно считывается 
            if (!ballController.characterController.isGrounded && 
                ballController.characterController.transform.position.y > 0.6f) 
            {
                Debug.LogWarning(ballController.characterController.transform.position);
                if (ballController.gravity.gravityCoroutine == null)
                {
                    Debug.Log("StartGravity method from MoveCoroutine");
                    ballController.gravity.StartGravity();
                }
            }
            yield return null;
        }
        moveCoroutine = null;
    }
}