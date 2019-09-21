using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceManager : Service<ServiceManager>
{
    public DialogueService DialogueServicePrefab;

    [HideInInspector]
    public DialogueService DialogueService;

    protected override void Awake()
    {
        base.Awake();
        DialogueService = Instantiate(DialogueServicePrefab);
    }
}
