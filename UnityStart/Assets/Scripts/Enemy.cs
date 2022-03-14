using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);
        
        if( randValue < 3 )
        {
            GameObject target = GameObject.Find("Player");
            if( target == null )
            {
                return;
            }

            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체 제거
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
