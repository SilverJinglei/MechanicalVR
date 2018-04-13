using System;
using UnityEngine;

public class HalfAutoSpannerWrenchOperationAction : ScrewAction
{
    void Update()
    {
        if (Parent == null) return;

        if (!Parent.IsWorking) return;

        var speed = TypedPart.ReverseDirection ? -1 * .01f : .01f;
        TypedPart.transform.localPosition = new Vector3(
            TypedPart.transform.localPosition.x,
            TypedPart.transform.localPosition.y,
            TypedPart.transform.localPosition.z + speed * Time.deltaTime);
    }
}