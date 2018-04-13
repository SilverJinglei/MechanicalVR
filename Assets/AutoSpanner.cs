using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AutoSpanner : MonoBehaviour
{
    GameObject nutWrench;
    Vector3 originEulerAnglesOfNutWrench;

    bool doWork;

    //public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    //{
    //    base.StartUsing(currentUsingObject);

    //    doWork = true;
    //}

    //public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    //{
    //    base.StopUsing(previousUsingObject);

    //    var controller = VRTK_ControllerReference.GetControllerReference(previousUsingObject.controllerEvents.gameObject);
    //    VRTK_ControllerHaptics.CancelHapticPulse(controller);
    //    doWork = false;
    //}

    // Use this for initialization
    void Start()
    {
        nutWrench = transform.Find("nutWrench").gameObject;
        originEulerAnglesOfNutWrench = nutWrench.transform.localEulerAngles;

        GetComponent<Tool>().InteractableObjectUsed += (us, ue) =>
        {
            //InitJoint();

            var controller = VRTK_ControllerReference.GetControllerReference(ue.interactingObject);
            VRTK_ControllerHaptics.TriggerHapticPulse(controller, 1, 1000, .01f);
        };

        GetComponent<Tool>().InteractableObjectUnused += (us, ue) =>
        {
            var controller = VRTK_ControllerReference.GetControllerReference(ue.interactingObject);
            VRTK_ControllerHaptics.CancelHapticPulse(controller);
        };

    }

    ConfigurableJoint sliderJoint;
    protected virtual void InitJoint()
    {
        if (sliderJoint != null) return;

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

    float speed = 5;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Tool>().DoesToolEmitTrigger)
        {
            nutWrench.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));

            //nutWrench.transform.localEulerAngles = new Vector3(
            //originEulerAnglesOfNutWrench.x, 
            //    5 * Time.deltaTime,
            //    originEulerAnglesOfNutWrench.z);
            return;
        }

        //nutWrench.transform.localEulerAngles = originEulerAnglesOfNutWrench;
    }
}
