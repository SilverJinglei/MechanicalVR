using UnityEngine;
using VRTK;
using System;

public class Tool : VRTK_InteractableObject
{
    public GameObject TouchSection;

    public Tool()
    {
        isGrabbable = true;
        holdButtonToGrab = false;

        isUsable = true;
        holdButtonToUse = true;

        touchHighlightColor = Color.red;
    }

    private void Start()
    {
        if (TouchSection == null)
            TouchSection = gameObject;
    }

    public bool DoesToolEmitTrigger { get; private set; }

    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
    {
        DoesToolEmitTrigger = true;

        base.OnInteractableObjectUsed(e);
    }

    public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
    {
        DoesToolEmitTrigger = false;

        base.OnInteractableObjectUnused(e);
    }
}
