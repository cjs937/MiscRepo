using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubState
{
    protected SubState nextState = null;

    public virtual void init(SubStateHandler _parentState) { }
    public virtual void onEnter() { }

    public virtual SubState update() { return nextState; }

    public virtual void FixedUpdate() { }

    public virtual void onExit() { }
}