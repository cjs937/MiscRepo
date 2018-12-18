using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubStateHandler : State
{
    public SubState currentState = null;

    public override State update()
    {
        updateSubState();

        return nextState;
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

        currentState.onEnter(this);
    }

    public void switchParentState(State _nextState)
    {
        nextState = _nextState;
    }

    public override void onExit()
    {
        if (currentState != null)
            currentState.onExit();
    }
}
