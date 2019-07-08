using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SubStateHandlers function the same as state handlers, but are states themselves. 
//This allows a secondary state to be be run inside of a CustomState if neccessary
//Example: If there was a jump CustomState, the sub states could be broken down into startup, launch, fall, and landing w/ different logic for each

//The switchParentState function must be called if you want to exit out of the parent CustomState from a SubState 

public class SubStateHandler : CustomState
{
    public SubState currentState = null;

    public override CustomState update()
    {
        updateSubState();

        return nextState;
    }

    public override void FixedUpdate()
    {
        if(currentState != null)
        {
            currentState.FixedUpdate();
        }
    }

    // Update is called once per frame
    public virtual void updateSubState()
    {
        if (currentState != null)
        {
            SubState nextState = currentState.update();

            if (nextState != null)
            {
                switchSubState(nextState);
            }
        }
    }

    public void switchSubState(SubState _nextState, bool _shouldExit = true)
    {
        if (_shouldExit)
            if (currentState != null)
                currentState.onExit();

        currentState = _nextState;

        currentState.init(this);
        currentState.onEnter();
    }

    public void switchParentState(CustomState _nextState)
    {
        nextState = _nextState;
    }

    public override void onExit()
    {
        if (currentState != null)
            currentState.onExit();
    }
}
