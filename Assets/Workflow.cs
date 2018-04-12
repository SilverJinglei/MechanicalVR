using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Workflow : MonoBehaviour
{
    [SerializeField]
    public List<OperationStep> OperationSteps = new List<OperationStep>();

    public OperationStep CurrentStep { get; private set; }

    public int Step;

    public static Workflow Cache { get; private set; }

    public event EventHandler StepChanged;

    public void NextStep()
    {
        CurrentStep.Disable();

        Step++;

        CurrentStep = Step == OperationSteps.Count ? null : OperationSteps[Step];


        if (StepChanged != null)
            StepChanged(this, EventArgs.Empty);

        if (CurrentStep == null)
            return;

        if (!CurrentStep.IsEnabled)
            NextStep();

        CurrentStep.Init();
    }


    public Workflow()
    {
        Cache = this;
    }

    private void Awake()
    {
        CurrentStep = OperationSteps[Step];
        CurrentStep.Init();
    }

    private void Start()
    {

    }
}

