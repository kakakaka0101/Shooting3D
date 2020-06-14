using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var force = new Vector3(hori, vert, 0f);
        //transform.position += new Vector3(hori, vert, 0f);
        GetComponent<Rigidbody>().AddForce(force * 100f);

    }
}
