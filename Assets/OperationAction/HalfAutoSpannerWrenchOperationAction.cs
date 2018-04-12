using System;
using UnityEngine;

public class HalfAutoSpannerWrenchOperationAction : ScrewAction
{
    void Update()
    {
        if (Parent == null) return;

        if (!Parent.IsWorking) return;

        var speed = attachedObj.ReverseDirection ? -1 * .01f : .01f;
        attachedObj.transform.localPosition = new Vector3(
            attachedObj.transform.localPosition.x,
            attachedObj.transform.localPosition.y,
            attachedObj.transform.localPosition.z + speed * Time.deltaTime);
    }
}