using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public InputNames inputNames;
    public float inputLifetime;
    public Vector2 perAxisCutoff;
    List<InputAction> inputBuffer = new List<InputAction>();

    // Update is called once per frame
    void Update()
    {
        UpdateBuffer();
        HandleInput();
    }

    void HandleInput()
    {
        JoystickInput joystick = GetJoystickInput();

        inputBuffer.Add(new InputAction(joystick));

        Debug.Log(joystick);
    }

    JoystickInput GetJoystickInput()
    {
        float x = Input.GetAxis(inputNames.HorizontalAxis);
        float y = Input.GetAxis(inputNames.VerticalAxis);

        //Debug.Log("x " + x + " y " + y);


        bool xActive = false;
        float xDirection = 0;

        bool yActive = false;
        float yDirection = 0;

        //if axis input is over cutoff value its considered active
        if (Mathf.Abs(x) >= perAxisCutoff.x)
        {
            xActive = true;
            xDirection = Mathf.Sign(x);
        }

        if (Mathf.Abs(y) >= perAxisCutoff.y)
        {
            yActive = true;
            yDirection = Mathf.Sign(y);
        }

        if (xActive)
        {
            if (yActive)
            {
                if (xDirection < 0)
                {
                    if (yDirection < 0)
                    {
                        return JoystickInput.BOTTOM_LEFT;
                    }
                    else
                    {
                        return JoystickInput.TOP_LEFT;
                    }
                }
                else
                {
                    if (yDirection < 0)
                    {
                        return JoystickInput.BOTTOM_RIGHT;
                    }
                    else
                    {
                        return JoystickInput.TOP_RIGHT;
                    }
                }

            }
            else
            {
                if (xDirection < 0)
                {
                    return JoystickInput.LEFT;
                }
                else
                {
                    return JoystickInput.RIGHT;
                }
            }
        }
        else if (yActive)
        {
            if (yDirection < 0)
                return JoystickInput.DOWN;
            else
                return JoystickInput.UP;
        }
        else
            return JoystickInput.NONE;
    }

    void UpdateBuffer()
    {
        float currentTime = Time.time;
        int deleteToIndex = 0;
        bool foundTarget = false;

        //List<InputAction> copy = new List<InputAction>(inputBuffer);

        for (int i = 0; i < inputBuffer.Count; ++i)
        {
            if(currentTime - inputBuffer[i].timeRecorded >= inputLifetime)
            {
                foundTarget = true;
                continue;
            }
            else
            {
                if(foundTarget)
                    deleteToIndex = i;
            }
        }

        inputBuffer.RemoveRange(0, deleteToIndex);
    }

    bool GetButtonDown(string buttonName)
    {
        if (inputBuffer.Count == 0)
            return false;

        foreach(ButtonAction button in inputBuffer[inputBuffer.Count - 1].buttons)
        {
            if (button.ButtonName == buttonName && button.pressed)
                return true;
        }

        return false;
    }

    bool GetButtonHeld(string buttonName)
    {
        if (inputBuffer.Count == 0)
            return false;

        foreach (ButtonAction button in inputBuffer[inputBuffer.Count - 1].buttons)
        {
            if (button.ButtonName == buttonName && button.held)
                return true;
        }

        return false;
    }

    bool GetButtonReleased(string buttonName)
    {
        if (inputBuffer.Count == 0)
            return false;

        foreach (ButtonAction button in inputBuffer[inputBuffer.Count - 1].buttons)
        {
            if (button.ButtonName == buttonName && button.released)
                return true;
        }

        return false;
    }

    JoystickInput GetJoystickState()
    {
        if (inputBuffer.Count == 0)
            return JoystickInput.NONE;

        return inputBuffer[inputBuffer.Count - 1].joystick;
    }

    float GetRawJoystickAxis(string AxisName)
    {
        return Input.GetAxis(AxisName);
    }
}
