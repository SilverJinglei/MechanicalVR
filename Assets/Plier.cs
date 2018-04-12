using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Plier : MonoBehaviour
{
    public GameObject Header;

    GameObject right, left;

    // Use this for initialization
    void Start()
    {
        right = transform.Find("right").gameObject;
        left = transform.Find("left").gameObject;

        GetComponent<Tool>().InteractableObjectUsed += (s, e) =>
        {
            right.transform.Rotate(0, 0, -10);
            left.transform.Rotate(0, 0, -10);
        };

        GetComponent<Tool>().InteractableObjectUnused += (s, e) =>
        {
            right.transform.Rotate(0, 0, 10);
            left.transform.Rotate(0, 0, 10);
        };
    }
}
