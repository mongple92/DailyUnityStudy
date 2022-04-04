using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestCollision : MonoBehaviour
{
    // Collision 발동 조건
    // 1) 나 혹은 상대한테 RigidBody가 있어야 한다. (IsKinematic : Off)
    // 2) 나한테 Collider가 있어야 한다. (IsTrigger : Off)
    // 3) 상대한테 Collider가 있어야 한다. (IsTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {   // 물리적 충돌이 있는경우
        Debug.Log("Collision! " + collision.gameObject.name);   
    }

    // Trigger 발동 조건
    // 1) 둘 다 Collider가 있어야 한다.
    // 2) 둘 중 하나는 IsTrigger : On
    // 3) 둘 중 하나는 RigidBody가 있어야 한다.
    private void OnTriggerEnter(Collider other)
    {   // 범위에 포함된 경우
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

        // 픽셀좌표
        // Debug.Log(Input.mousePosition);  // screen position

        // 화면 비
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));  // viewport position

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            // 레이어로 레이케스팅 최적화
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
