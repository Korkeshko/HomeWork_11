using System.Collections;
using UnityEngine;

public class GravityController
{
    private BallController ballController;
    private float gravity = -2f;
    private float gravityCoefficient = 3;
    public Coroutine gravityCoroutine;

    public GravityController(BallController ballController)
    {
        this.ballController = ballController;
    }

    public void StartGravity()
    {
        Debug.Log("StartGravity method");
        if (gravityCoroutine == null)
        {
            Debug.Log("Start GravityCoroutine");
            gravityCoroutine = ballController.StartCoroutine(GravityCoroutine());
            ballController.isGrounded = false;
        }
    }

    public void StopGravity()
    {
        if (gravityCoroutine != null)
        {
            Debug.Log("Stop GravityCoroutine");
            ballController.StopCoroutine(gravityCoroutine);
            gravityCoroutine = null;
            ballController.isGrounded = true;
        }
    }

    private IEnumerator GravityCoroutine()
    {
        while (!ballController.characterController.isGrounded && !ballController.jump.isJumping)
        {
            ballController.characterController.Move(new Vector3(0, gravity * gravityCoefficient * Time.deltaTime, 0));
            yield return null;
        }

        if (ballController.characterController.isGrounded)
        {
            Debug.Log("StopGravity method from GravityCoroutine");
            StopGravity();
        } 
    }
}