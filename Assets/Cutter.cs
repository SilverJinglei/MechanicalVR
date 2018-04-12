using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cutter : MonoBehaviour {

    // Use this for initialization
    void Start () {
        foreach (var step in GetComponent<Part>().RelatedOperationSteps)
        {
            step.StartWork += Cutter_Working;
        } 
	}

    private void Cutter_Working(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
	}
}
