using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
