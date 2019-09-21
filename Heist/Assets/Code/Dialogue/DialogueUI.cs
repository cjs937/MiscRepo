using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class DialogueUI : Yarn.Unity.DialogueUIBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
    {
        //dynamically spawn buttons within paramaters (width, height, screenposition)
        yield break;
    }

    public override IEnumerator RunCommand(Command command)
    {
        //fire an event with the command in tow
        yield break;
    }

    public override IEnumerator RunLine(Line line)
    {
        //run line by line, see example for guide
        //somehow need to know the current speaker so dialogue audio can be used
        yield break;
    }
}
