using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 나 혹은 상대에게 rigidBody 가 있어야함 ( IsKinematic : Off )
    // 나한테 Collider 가 있어야함 ( IsTrigger : off )
    // 상대한테 Collider 가 있어야함 ( IsTrigger : Off )
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} !");
    }
    // 둘다 Collider 가 있어야 한다.
    // 둘 중 하나는 IsTrigger : On
    // 둘 중 하나는 RigidBody 가 있어야 함
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }

    void Start()
    {
        
    }

    void Update()
    {

        // Local <-> World <-> (Viewport <-> Screen) (화면)

        // 현재 마우스 좌표를 픽셀 좌표로 -> screen 좌표계
        //Debug.Log(Input.mousePosition);

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // view port

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 아래 3줄과 같은 의미
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir = dir.normalized;

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            int mask = (1 << 8) | (1 << 9); // layer 설정한 것만 raycast 되도록 설정
            //LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("wall");

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask)) // 설정한 layer 만 되도록 mask 입
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
            }

            //if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
            //{
             //   Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
           // }
        }
        
    }
}
