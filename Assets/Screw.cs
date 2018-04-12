using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour {

    public IOperationAction Action;

    // Use this for initialization
    void Start()
    {
        //foreach (var step in GetComponent<Part>().RelatedOperationSteps)
        //{
        //    step.StartWork += OnWorking;
        //    step.StopWork += OnStopWork;
        //}
    }

    private void OnStopWork(object sender, EventArgs e)
    {
        var step = sender as OperationStep;

        if (step.WhichTool<AdjustableWrench>())
            isAdjustableWrenchWorking = false;

        if (step.WhichTool<AutoSpanner>())
            isAutoSpanner = false;
    }

    bool isAdjustableWrenchWorking, isAutoSpanner;

    private void OnWorking(object sender, EventArgs e)
    {
        var step = sender as OperationStep;

        if (step.WhichTool<AdjustableWrench>())
        {
            isAdjustableWrenchWorking = true;
            isAutoSpanner = false;

            var offset = ReverseDirection ? -1 * .005f : .005f;
            
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z + offset);
            return;
        }

        if (step.WhichTool<AutoSpanner>())
        {
            isAdjustableWrenchWorking = false;
            isAutoSpanner = true;
        }
    }

    public bool ReverseDirection;

    // Update is called once per frame
    void Update () {
        return;

        if(isAdjustableWrenchWorking)
        {
        }

        if (isAutoSpanner)
        {
            var speed = ReverseDirection ? -1 * .01f : .01f ;
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z + speed * Time.deltaTime);
        }
    }
}
