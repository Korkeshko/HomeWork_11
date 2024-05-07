using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _1_SRP : MonoBehaviour
{
    [SerializeField]
    private PlayerMove playerMove;  
    [SerializeField]
    private PlayerJump playerJump; 
    [SerializeField]
    private PlayerFire playerFire; 
    [SerializeField]
    private PlayerAnimation playerAnimation;   
}

[Serializable]
public class PlayerMove
{
    private float speed;
    public void Move()
    {
        // TODO: Move
    }
}

[Serializable]
public class PlayerJump
{
    private float power;
    public void Jump()
    {
        // TODO: Jump
    }
}

[Serializable]
public class PlayerFire
{
    private float damage;
    public void Fire()
    {
        // TODO: Fire 
    }
}

[Serializable]
public class PlayerAnimation
{
    private Animator animator;
    public void Animation()
    {
        // TODO: Animation  
    }
}