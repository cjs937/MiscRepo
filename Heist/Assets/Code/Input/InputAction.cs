using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JoystickInput
{
    NONE = -1,
    UP,
    TOP_RIGHT,
    RIGHT,
    BOTTOM_RIGHT,
    DOWN,
    BOTTOM_LEFT,
    LEFT,
    TOP_LEFT
}

public struct ButtonAction
{
    public string ButtonName;
    public bool pressed;
    public bool held;
    public bool released;
}


public class InputAction
{
    public JoystickInput joystick;
    public List<ButtonAction> buttons = new List<ButtonAction>();
    public float timeRecorded;

    public InputAction(JoystickInput joystickInput, ButtonAction buttonInput)
    {
        joystick = joystickInput;
        buttons.Add(buttonInput);
    }

    public InputAction(JoystickInput joystickInput, List<ButtonAction> buttonInputs)
    {
        joystick = joystickInput;
        buttons = buttonInputs;
    }

    public InputAction(JoystickInput joystickInput)
    {
        joystick = joystickInput;
    }

    public InputAction(ButtonAction buttonInput)
    {
        joystick = JoystickInput.NONE;
        buttons.Add(buttonInput);
    }

    public InputAction(List<ButtonAction> buttonInputs)
    {
        joystick = JoystickInput.NONE;
        buttons = buttonInputs;
    }

    public InputAction()
    {
        joystick = JoystickInput.NONE;
    }
}
