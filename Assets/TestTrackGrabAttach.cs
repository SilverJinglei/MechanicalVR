using UnityEngine;
using VRTK.GrabAttachMechanics;

public class TestTrackGrabAttach: VRTK_TrackObjectGrabAttach
{
    protected override void SetTrackPointOrientation(ref Transform trackPoint, Transform currentGrabbedObject, Transform controllerPoint)
    {
        base.SetTrackPointOrientation(ref trackPoint, currentGrabbedObject, controllerPoint);
    }
}
