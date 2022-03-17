using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;
    public int poosSize = 10;
    GameObject[] bulletObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new GameObject[poosSize];

        for (int i = 0; i < poosSize; i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletFactory);
            bulletObjectPool[i] = bullet;
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {   // 사용자가 버튼 누르면
            
            // 총알을 하나 만든다.
            GameObject bullet = Instantiate(bulletFactory);

            // 총알을 발사한다.
            bullet.transform.position = firePosition.transform.position;               
        }
    }
}