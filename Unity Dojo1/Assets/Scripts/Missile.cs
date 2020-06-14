using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 position;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float period;//着弾時間

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var acceleration = Vector3.zero;

        var diff = target.position - position;//距離を撮ってる


        accelaration += (diff - velocity * period) * 2f / (period * period);

        period -= Time.deltaTime;
        if(period < 0f)
        {
            return;

        }

        if(acceleration.magnitude > 100f)
        {
            acceleration = acceleration.normalized * 100f;

        }

        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        transform.position = position;

        
    }
}
