using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubState
{
    protected SubState nextState = null;

    public virtual void onEnter(SubStateHandler _parentState) { }

    public virtual SubState update() { return nextState; }

    public virtual void onExit() { }
}
