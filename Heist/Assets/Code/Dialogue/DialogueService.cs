using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueService : Service<DialogueService>
{
    public Yarn.Unity.DialogueRunner DialogueRunner;
    public DialogueUI DialogueUI;
    public DialogueVariableStorage VariableStorage;

    protected override void Awake()
    {
        base.Awake();

        DialogueRunner = GetComponent<Yarn.Unity.DialogueRunner>();
        DialogueUI = GetComponent<DialogueUI>();
        VariableStorage = GetComponent<DialogueVariableStorage>();

        
    }
}
