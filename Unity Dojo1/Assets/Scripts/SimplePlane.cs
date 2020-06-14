﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlane : MonoBehaviour
{
    public float target_kmph_ = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var rb = GetComponent<Rigidbody>();
        rb.AddRelativeTorque(new Vector3(0, hori, -hori));
        rb.AddRelativeTorque(new Vector3(-vert, 0, 0));

        var left = transform.TransformVector(Vector3.left);
        var hori_left = new Vector3(left.x, 0f, left.z).normalized;
        rb.AddTorque(Vector3.Cross(left, hori_left) * 2);

        var forward = transform.TransformVector(Vector3.forward);
        var hori_forward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, hori_forward) * 2);

        var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) / (1f - rb.drag * Time.fixedDeltaTime);
        rb.AddRelativeForce(new Vector3(0f, 0f, force));


    }
}
