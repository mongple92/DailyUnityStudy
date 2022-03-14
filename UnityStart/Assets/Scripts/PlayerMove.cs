using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        // P = P0 + vt = P0 + ( v * t )
        // 이동할 위치 = 현재 위치 * (방향 * 속도 * 시간)
        transform.position += dir * speed * Time.deltaTime;
    }
}
