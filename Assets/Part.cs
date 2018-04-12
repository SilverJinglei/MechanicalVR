using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Part : MonoBehaviour
{
    public bool IsWorking
    {
        get
        {
            //if (Workflow.Cache.CurrentStep == null) return false;

            return Workflow.Cache.CurrentStep.Part == this ? 
                Workflow.Cache.CurrentStep.IsWorking : false;
        }
    }

    public IEnumerable<OperationStep> RelatedOperationSteps
    {
        get
        {
            return Workflow.Cache.OperationSteps.Where(o => o.Part == this);
        }
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;

        if (GetComponent<HightligherHelper>() == null)
            gameObject.AddComponent<HightligherHelper>();

        GetComponent<HightligherHelper>().InitialiseHighlighter();
    }

    public void Drop()
    {
        if (gameObject.GetComponent<Rigidbody>() == null)
            gameObject.AddComponent<Rigidbody>();

        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    public event TEventHandler<Collider> TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (TriggerEnter != null)
            TriggerEnter(this, other);
    }

    public event TEventHandler<Collider> TriggerExit;

    private void OnTriggerExit(Collider other)
    {
        if (TriggerExit != null)
            TriggerExit(this, other);
    }

    public void Highlight()
    {
        GetComponent<HightligherHelper>().Highlight();
    }

    public void Unhighlight()
    {
        GetComponent<HightligherHelper>().Unhighlight();
    }
}