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
        var offset = TypedPart.ReverseDirection ? -1 * .005f : .005f;

        TypedPart.transform.localPosition = new Vector3(
            TypedPart.transform.localPosition.x,
            TypedPart.transform.localPosition.y,
            TypedPart.transform.localPosition.z + offset);

        OnFinishWork();
    }

    public override void StopWork()
    {
        //Parent.PrimaryTool.gameObject
    }
}

