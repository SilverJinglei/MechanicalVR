using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Plier plier;

    bool isPlierWorking;

    // Use this for initialization
    void Start()
    {
        foreach (var step in GetComponent<Part>().RelatedOperationSteps)
        {
            step.StopWork += (ss, se) =>
            {
                GetComponent<Part>().Drop();

                isPlierWorking = false;
            };

            step.StartWork += OnStartWork;
        }
    }

    private void OnStartWork(object sender, System.EventArgs e)
    {
        var step = sender as OperationStep;

        if (step.WhichTool<Plier>())
        {
            isPlierWorking = true;
            plier = step.PrimaryTool.gameObject.GetComponent<Plier>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlierWorking)
            transform.position = plier.Header.transform.position;
    }
}