using System.Collections;
using UnityEngine;

public class cshFirstObjectInteraction : MonoBehaviour
{
    public Transform playerChildObject; // 플레이어의 자식 오브젝트
    private GameObject heldObject; // 플레이어가 들고 있는 오브젝트
    public GameObject[] spawnPoints; // 스폰 포인트를 저장할 배열
    private Vector3 originalPosition; // 오브젝트의 원래 위치를 저장할 변수
    public cshfirstdogstate dogState; // 강아지 상태 스크립트

    void Update()
    {
        if (heldObject != null) // 오브젝트를 들고 있고, 던지는 중이 아닐 때
        {
            heldObject.transform.position = playerChildObject.position; // 오브젝트의 위치를 플레이어의 자식 오브젝트 위치로 업데이트
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("towel") || hit.transform.CompareTag("syringe")) // 태그가 'towel'이나 'syringe'인 경우
                {
                    if (heldObject != null) // 이미 오브젝트를 들고 있다면
                    {
                        heldObject.transform.position = originalPosition; // 오브젝트를 원래 위치로 이동
                    }
                    heldObject = hit.transform.gameObject; // 새로운 오브젝트를 들게 함
                    originalPosition = heldObject.transform.position; // 오브젝트의 원래 위치를 저장
                }

                else if (hit.transform.CompareTag("dog")) // 태그가 'dog'인 경우
                {
                    if (heldObject != null) // 오브젝트를 들고 있다면
                    {
                        if (heldObject.CompareTag("towel"))
                        {
                            dogState.hasTowel = true; // 타월 상태 업데이트
                        }
                        else if (heldObject.CompareTag("syringe"))
                        {
                            dogState.hasSyringe = true; // 주사기 상태 업데이트
                        }

                        heldObject.GetComponent<Rigidbody>().AddForce((hit.transform.position - heldObject.transform.position).normalized * 1f, ForceMode.Impulse);
                        heldObject = null; // heldObject를 null로 설정
                    }
                }
            }
        }
    }
}
