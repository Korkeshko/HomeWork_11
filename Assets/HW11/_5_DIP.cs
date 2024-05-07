using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _5_DIP : MonoBehaviour // GameManager
{
    private Player player;
    private void Awake() 
    {
        player = GetComponent<Player>();
        player.HP = 100;
    }
}

public class Player : IPlayer
{
    private int hp;
    public int HP 
    {  
        get { return hp; }
        set { hp = value; }
    } 
    
    public void Movement()
    {
        throw new System.NotImplementedException();
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerConnected()
    {
        throw new System.NotImplementedException();
    }
}

interface IPlayer
{
    void OnPlayerConnected();
    void Jump();
    void Movement();
}
