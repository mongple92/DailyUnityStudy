using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject bulletFactory;

    public GameObject firePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {   // ����ڰ� ��ư ������
            
            // �Ѿ��� �ϳ� �����.
            GameObject bullet = Instantiate(bulletFactory);

            // �Ѿ��� �߻��Ѵ�.
            bullet.transform.position = firePosition.transform.position;               
        }
    }
}