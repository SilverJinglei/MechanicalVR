using System;
using UnityEngine;


public class ScrewAction : TOperationActionBase<Screw>
{
    public override void StartWork()
    {
    }

    public override void StopWork()
    {
        OnFinishWork();
    }
}

public class AdjustableWrenchOperationAction : ScrewAction
{
    public override void StartWork()
    {
        var offset = attachedObj.ReverseDirection ? -1 * .005f : .005f;

        attachedObj.transform.localPosition = new Vector3(
            attachedObj.transform.localPosition.x,
            attachedObj.transform.localPosition.y,
            attachedObj.transform.localPosition.z + offset);

        OnFinishWork();
    }

    public override void StopWork()
    {
        //Parent.PrimaryTool.gameObject
    }
}

