using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class State
{
    protected State nextState = null;

    public virtual void onEnter(StateHandler _handler) { }

    public virtual State update() { return nextState; }

    public virtual void onExit() { }
}

public class StateHandler : MonoBehaviour
{
    public bool debugState;
    public State currentState = null; // should be initialized differently depending on the handler
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (currentState != null)
        {
            State nextState = currentState.update();

            if (nextState != null)
            {
                switchState(nextState);
            }
        }
	}

    public void switchState(State _nextState, bool _shouldExit = true)
    {
        if(_shouldExit)
            if(currentState != null)
                currentState.onExit();

        if(debugState)
            Debug.Log(_nextState);
        
        currentState = _nextState;

        currentState.onEnter(this);
    }

    public System.Type getStateType()
    {
        if (currentState == null)
            return null;

        return currentState.GetType();
    }
}
