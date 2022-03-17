using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ : ���� �ٸ� ��ü�� �浹���� �� ���� ȿ���� �߻���Ű�� �ʹ�.
// ���� : 1. ���� �ٸ� ��ü�� �浹 �����ϱ�
//        2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
//        3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
// �ʿ�Ӽ� : ���� ���� �ּ�(�ܺο��� ���� �־��ش�)

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

        // ���� ȿ���� �ϳ� �����
        GameObject explosion = Instantiate(explosionFactory);

        // ���� ȿ���� �߻���Ű�� �ʹ�. enemy�� ��ġ�� ��ġ ��Ų��.
        explosion.transform.position = transform.position;

        // �浹�� ��ü ����
        Destroy(collision.gameObject);

        Destroy(gameObject);
    }
}
