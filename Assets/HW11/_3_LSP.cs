using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3_LSP : MonoBehaviour
{
    public virtual float Jump()
    {
        return 1;
    }
}

public class Ball : _3_LSP
{
    public override float Jump()
    {
        return 2;
    }
}

public class Human : _3_LSP
{
    public override float Jump()
    {
        return 3;
    }
}

public class Bitcoin : _3_LSP
{
    public override float Jump()
    {
        return 206593;
    }
}
