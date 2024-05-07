using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class _2_OCP : MonoBehaviour
{
    public int Speed { get; set; }
    public int Power { get; set; }
    public int Health { get; set; }

    public void Move()
    {
        // TODO: 
        // rb.velocity = new Vector3(inputVector.x, 0, inputVector.y) * Speed;
    }  

    public void Jump()
    {
        // TODO: 
        // rb.AddForce(Vector3.up * Power, ForceMode.Impulse);
    }

    public void Fire()
    {
        // TODO: 
        // Enemy.Health -= Damage(); 
    }
}

