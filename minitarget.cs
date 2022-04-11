using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minitarget : MonoBehaviour
{
    public GameObject Blue;

    float X;

    // Update is called once per frame
    void Update()
    {
        X = this.transform.position.x;
        if (this.transform.position.x > Blue.transform.position.x)
        {
            this.transform.position = new Vector3(X-0.1f, -22f, -10f);
        }

        else
        {
            this.transform.position = new Vector3(X+0.1f, -22f, -10f);
        }
    }
}