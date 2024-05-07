using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _4_ISP : ISOLID
{
    void ISOLID.SOLID()
    {
        Debug.Log("SOLID");
    }
}

public class Kangaroo : IJump
{
    void IJump.Jump()
    {
        Debug.Log("Jump");
    }
}

public class Plane : IFly
{
    void IFly.Fly()
    {
        Debug.Log("Fly");
    }
}
    
interface ISOLID
{
    void SOLID();
}

interface IJump
{
    void Jump();
}

interface IFly
{
    void Fly(); 
}
