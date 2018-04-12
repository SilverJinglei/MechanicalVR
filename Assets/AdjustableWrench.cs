using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AdjustableWrench : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<Tool>().InteractableObjectUsed += (us, ue) =>
        //{
        //    var controller = VRTK_ControllerReference.GetControllerReference(ue.interactingObject);
        //    VRTK_ControllerHaptics.TriggerHapticPulse(controller, 1, 1000, .01f);
        //};

        //GetComponent<Tool>().InteractableObjectUnused += (us, ue) =>
        //{
        //    var controller = VRTK_ControllerReference.GetControllerReference(ue.interactingObject);
        //    VRTK_ControllerHaptics.CancelHapticPulse(controller);
        //};
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
