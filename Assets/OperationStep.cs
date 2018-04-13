using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OperationStep
{
    [SerializeField]
    public bool IsEnabled = false;

    public string Name;

    public Part Part;

    public Tool PrimaryTool;

    //public Tool AssistTool;

    bool isToolTouch;

    public OperationActionBase Action;

    public bool HasChild
    {
        get { return ChildrenSteps.Count != 0; }
    }

    [SerializeField]
    public List<OperationStep> ChildrenSteps = new List<OperationStep>();


    private void OnGUI()
    {
        //Action = EditorGUILayout.ObjectField(Action, typeof(Transform), true) as OperationActionBase;
    }

    public bool WhichTool<T>()
    {
        return PrimaryTool.gameObject.GetComponent<T>() != null;
    }

    public OperationStep()
    {

    }

    public void Init()
    {
        if (!IsEnabled)
            return;

        if (Action == null)
            Action = NullOperationAction.Me;

        Action.FinishWork += Action_FinishWork;

        Action.Parent = this;

        PrimaryTool.InteractableObjectUsed += Tool_InteractableObjectUsed;
        PrimaryTool.InteractableObjectUnused += Tool_InteractableObjectUnused;

        Part.TriggerEnter += Part_TriggerEnter;
        Part.TriggerExit += Part_TriggerExit;
    }

    private void Action_FinishWork(object sender, EventArgs e)
    {
        Workflow.Cache.NextStep();
    }

    public void Disable()
    {
        IsEnabled = false;

        Action.FinishWork -= Action_FinishWork;


        PrimaryTool.InteractableObjectUsed -= Tool_InteractableObjectUsed;
        PrimaryTool.InteractableObjectUnused -= Tool_InteractableObjectUnused;


        Part.TriggerEnter -= Part_TriggerEnter;
        Part.TriggerExit -= Part_TriggerExit;
    }

    private void Part_TriggerExit(object sender, Collider other)
    {
        return;

        if (!IsTouchSection(other))
            return;

        isToolTouch = false;
        Part.Unhighlight();

        if (IsWorking)
            OnStopWork();
    }

    bool IsTouchSection(Collider other)
    {
        return other.gameObject == PrimaryTool.TouchSection;
    }

    private void Part_TriggerEnter(object sender, Collider other)
    {
        if (!IsTouchSection(other))
            return;

        isToolTouch = true;
        Part.Highlight();
    }

    private void Tool_InteractableObjectUnused(object sender, VRTK.InteractableObjectEventArgs e)
    {
        if (IsWorking)
            OnStopWork();
    }

    private void Tool_InteractableObjectUsed(object sender, VRTK.InteractableObjectEventArgs e)
    {
        if (isToolTouch)
            OnWorking();
    }

    public event EventHandler StopWork;

    void OnStopWork()
    {
        IsWorking = false;

        Action.StopWork();

        if (StopWork != null)
            StopWork(this, EventArgs.Empty);
    }

    public bool IsWorking { get; private set; }

    public event EventHandler StartWork;

    void OnWorking()
    {
        IsWorking = true;

        Action.StartWork();

        if (StartWork != null)
            StartWork.Invoke(this, EventArgs.Empty);
    }

    // Update is called once per frame
    public void Update()
    {

    }

    //public static OperationStep EmptyOperationStep = new OperationStep()
    //{
    //    Part = new Part(),
    //    PrimaryTool = new Tool()
    //};
}

public interface IOperationAction
{
    //bool CanFinish();

    OperationStep Parent { get; set; }

    void StartWork();

    void StopWork();

    event EventHandler FinishWork;
}

public abstract class OperationActionBase : MonoBehaviour, IOperationAction
{
    public OperationStep Parent { get; set; }

    public event EventHandler FinishWork;

    protected void OnFinishWork()
    {
        FinishWork.EventEmit(this);
    }

    public abstract void StartWork();
    public abstract void StopWork();

    //public abstract bool CanFinish();
}

public abstract class TOperationActionBase<T> : OperationActionBase
{
    protected T TypedPart
    {
        get { return Parent.Part.gameObject.GetComponent<T>(); }
    }
}

public class NullOperationAction : OperationActionBase
{
    public override void StartWork()
    {
    }

    public override void StopWork()
    {
        OnFinishWork();
    }

    public readonly static NullOperationAction Me = new NullOperationAction();
}