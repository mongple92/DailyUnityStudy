using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestCollision : MonoBehaviour
{
    // Collision �ߵ� ����
    // 1) �� Ȥ�� ������� RigidBody�� �־�� �Ѵ�. (IsKinematic : Off)
    // 2) ������ Collider�� �־�� �Ѵ�. (IsTrigger : Off)
    // 3) ������� Collider�� �־�� �Ѵ�. (IsTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {   // ������ �浹�� �ִ°��
        Debug.Log("Collision! " + collision.gameObject.name);   
    }

    // Trigger �ߵ� ����
    // 1) �� �� Collider�� �־�� �Ѵ�.
    // 2) �� �� �ϳ��� IsTrigger : On
    // 3) �� �� �ϳ��� RigidBody�� �־�� �Ѵ�.
    private void OnTriggerEnter(Collider other)
    {   // ������ ���Ե� ���
        Debug.Log("Trigger! " + other.gameObject.name);
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Vector3 look = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        //foreach(RaycastHit hit in hits )
        //{
        //    Debug.Log($"RayCast! {hit.collider.gameObject.name}!");
        //}

        // �ȼ���ǥ
        // Debug.Log(Input.mousePosition);  // screen position

        // ȭ�� ��
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  // viewport position

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            // ���̾�� �����ɽ��� ����ȭ
            int mask = (1 << 8) | (1 << 9);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycase Camera @ {hit.collider.gameObject.name}");
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;
        //    dir.Normalize();

        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //    {
        //        Debug.Log($"Raycase Camera @ {hit.collider.gameObject.name}");
        //    }
        //}
    }
}
