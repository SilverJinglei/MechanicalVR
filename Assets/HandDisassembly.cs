using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisassembly : MonoBehaviour {

    public HandDisassembly()
    {
        
    }

	// Use this for initialization
	void Start () {
        Workflow.Cache.StepChanged += Cache_StepChanged;
	}

    private void Cache_StepChanged(object sender, System.EventArgs e)
    {
        if (Workflow.Cache.Step == 5)
        {
            gameObject.AddComponent<Tool>();

            gameObject.GetComponent<Tool>().holdButtonToGrab = true;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
