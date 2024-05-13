using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController
{
    private BallController ballController;
    private float jumpForce = 3f;
    private Vector3 jumpVelocity;
    private Vector3 jumpStartPosition;
    private Coroutine jumpCoroutine;
    public bool isJumping = false;

    public JumpController(BallController ballController)
    {
        this.ballController = ballController;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (ballController.isGrounded)
        {
            if (jumpCoroutine == null)
            {
                ballController.jump.isJumping = true;
                jumpVelocity.y = jumpForce;
                jumpStartPosition = ballController.characterController.transform.position;
                Debug.Log("Start JumpCoroutine from OnJump");
                jumpCoroutine = ballController.StartCoroutine(JumpCoroutine());
            }
        }
    }

    private IEnumerator JumpCoroutine()
    {
        while (ballController.jump.isJumping)
        {
            ballController.characterController.Move(jumpVelocity * Time.deltaTime);
            if (ballController.characterController.transform.position.y > jumpStartPosition.y + 1f)
            {
                Debug.Log("CurrentPositionY > StartPositionY + 1");
                ballController.jump.isJumping = false;
                if (jumpCoroutine != null)
                {
                    Debug.Log("Stop jumpCoroutine from JumpCoroutine");
                    ballController.StopCoroutine(jumpCoroutine);
                    jumpCoroutine = null;
                }
                Debug.Log("StartGravity method from JumpCoroutine");
                ballController.gravity.StartGravity();
            }
            yield return null;
        }
    }
}  