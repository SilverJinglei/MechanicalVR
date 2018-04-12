using System;
using UnityEngine;

public class AutoSpannerWrenchOperationAction : ScrewAction
{
    void Update()
    {
        if (Parent == null) return;

        if (!Parent.IsWorking) return;


        //Parent.PrimaryTool.transform.position = Parent.Part.transform.position;

        var speed = attachedObj.ReverseDirection ? -1 * .01f : .01f;
        attachedObj.transform.localPosition = new Vector3(
            attachedObj.transform.localPosition.x,
            attachedObj.transform.localPosition.y,
            attachedObj.transform.localPosition.z + speed * Time.deltaTime);
    }



    ConfigurableJoint sliderJoint;

    protected virtual void InitJoint()
    {
        sliderJoint = GetComponent<ConfigurableJoint>();
        if (sliderJoint == null)
            sliderJoint = gameObject.AddComponent<ConfigurableJoint>();

        sliderJoint.xMotion = ConfigurableJointMotion.Locked;
        sliderJoint.yMotion = ConfigurableJointMotion.Free;
        sliderJoint.zMotion = ConfigurableJointMotion.Locked;

        sliderJoint.angularXMotion = ConfigurableJointMotion.Locked;
        sliderJoint.angularYMotion = ConfigurableJointMotion.Locked;
        sliderJoint.angularZMotion = ConfigurableJointMotion.Locked;
    }


    public override void StartWork()
    {
        base.StartWork();

        Parent.PrimaryTool.transform.position = Parent.Part.transform.position;

        InitJoint();

    }
}
