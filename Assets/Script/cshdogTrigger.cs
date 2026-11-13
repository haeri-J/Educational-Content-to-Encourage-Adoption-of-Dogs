using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshdogTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dog")|| other.CompareTag("bowl"))
        {
            Debug.Log("충돌됨");
            Destroy(gameObject); // 스크립트가 연결된 자신의 오브젝트를 파괴
        }
    }
}
