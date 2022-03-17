using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 적이 다른 물체와 충돌했을 때 폭발 효과를 발생시키고 싶다.
// 순서 : 1. 적이 다른 물체와 충돌 했으니까
//        2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
//        3. 폭발 효과를 발생(위치)시키고 싶다.
// 필요속성 : 폭발 공장 주소(외부에서 값을 넣어준다)

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
    public GameObject explosionFactory;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManager.Instance.Score++;

        // 폭발 효과를 하나 만든다
        GameObject explosion = Instantiate(explosionFactory);

        // 폭발 효과를 발생시키고 싶다. enemy의 위치로 위치 시킨다.
        explosion.transform.position = transform.position;

        // 충돌한 물체 제거
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
