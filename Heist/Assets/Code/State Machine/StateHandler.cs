using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quick overview of how this works
//StateHandlers will switch between custom states based on input/game state
//When a state is switched it calls onExit on the previous one (unless specified otherwise), then init and onEnter for the new state
//Update is called every frame in the state handler's update loop. If the update function returns a CustomState the handler switches to the state that was returned
//If null is returned nothing happens and the currentState continues to loop

public class CustomState
{
    protected CustomState nextState = null;

    public virtual void init(StateHandler _handler) { }

    public virtual void onEnter() { }

    public virtual CustomState update() { return nextState; } //nextState defaults to null

    public virtual void FixedUpdate() { }

    public virtual void onExit() { }
}

public class StateHandler : MonoBehaviour
{
    public bool debugState;
    public CustomState currentState = null; // should be initialized differently depending on the handler
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (currentState != null)
        {
            CustomState nextState = currentState.update();

            if (nextState != null)
            {
                switchState(nextState);
            }
        }
	}

    protected virtual void FixedUpdate()
    {
        if(currentState != null)
        {
            currentState.FixedUpdate();
        }
    }

    public void switchState(CustomState _nextState, bool _shouldExit = true)
    {
        if(_shouldExit)
            if(currentState != null)
                currentState.onExit();

        if(debugState)
            Debug.Log(_nextState);
        
        currentState = _nextState;

        currentState.init(this);

        currentState.onEnter();
    }

    public System.Type getStateType()
    {
        if (currentState == null)
            return null;

        return currentState.GetType();
    }
}
