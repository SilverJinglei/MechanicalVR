using System;
using UnityEngine;

public class AutoSpannerWrenchOperationAction : ScrewAction
{
    void Update()
    {
        if (Parent == null) return;

        if (!Parent.IsWorking) return;


        //Parent.PrimaryTool.transform.position = Parent.Part.transform.position;

        var speed = TypedPart.ReverseDirection ? -1 * .01f : .01f;
        TypedPart.transform.localPosition = new Vector3(
            TypedPart.transform.localPosition.x,
            TypedPart.transform.localPosition.y,
            TypedPart.transform.localPosition.z + speed * Time.deltaTime);
    }



    ConfigurableJoint sliderJoint;

    protected virtual void InitJoint()
    {
        if (sliderJoint != null) return;

        sliderJoint = Parent.PrimaryTool.GetComponent<ConfigurableJoint>();
        if (sliderJoint == null)
            sliderJoint = Parent.PrimaryTool.gameObject.AddComponent<ConfigurableJoint>();

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

        //Parent.PrimaryTool.transform.position = Parent.Part.transform.position;
        //Parent.PrimaryTool.GetComponent

        InitJoint();

    }
}
