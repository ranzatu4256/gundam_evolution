using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject Blue1;
    public GameObject Blue2;
    public GameObject Blue3;
    public GameObject Blue4;
    public GameObject Blue5;
    public GameObject Blue6;

    Vector3 myVector;

    float ave;
    float X;

    // Update is called once per frame
    void Update()
    {
        ave = Blue1.transform.position.x + Blue2.transform.position.x + Blue3.transform.position.x + Blue4.transform.position.x + Blue5.transform.position.x + Blue6.transform.position.x;

        myVector = new Vector3(ave/6f, -22f, -10f);
        X = this.transform.position.x;
        if (this.transform.position.x > myVector.x)
        {
            this.transform.position = new Vector3(X-0.1f, -22f, -10f);
        }

        else
        {
            this.transform.position = new Vector3(X+0.1f, -22f, -10f);
        }
    }
}
