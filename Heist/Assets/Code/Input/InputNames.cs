using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InputNames", menuName = "Create input names", order = 51)]
public class InputNames : ScriptableObject
{
    public string HorizontalAxis;
    public string VerticalAxis;
    public List<string> Buttons;
}
