using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMotion : MonoBehaviour
{
    public float w = 1, x = 0, y = 0, z = 0;

    ConfigurableJoint cj;

    // Start is called before the first frame update
    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
        Quaternion q = cj.targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        cj.targetRotation = new Quaternion(x, y, z, w);
    }
}
