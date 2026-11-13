using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 컴포넌트를 사용하기 위해 추가

public class cshThirdInterection : MonoBehaviour
{
    public Transform playerChildObject; // 플레이어의 자식 오브젝트
    private GameObject heldObject; // 플레이어가 들고 있는 오브젝트
    public GameObject[] spawnPoints; // 스폰 포인트를 저장할 배열
    private Vector3 originalPosition; // 오브젝트의 원래 위치를 저장할 변수
    private bool hasPickedUpSyringe = false; // Syringe를 들었는지 여부를 확인하는 변수
    public Text warningText; // 경고 메시지를 표시할 텍스트 컴포넌트
    public cshThirdState dogState; // 강아지 상태 스크립트 

   
    void Update()
    {
        if (heldObject != null) // 오브젝트를 들고 있고
        {
            heldObject.transform.position = playerChildObject.position; // 오브젝트의 위치를 플레이어의 자식 오브젝트 위치로 업데이트
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("syringe") && heldObject == null) // 태그가 'syringe'인 경우, 그리고 heldObject가 null인 경우
                {
                    if (heldObject != null) // 이미 오브젝트를 들고 있다면
                    {
                        heldObject.transform.position = originalPosition; // 오브젝트를 원래 위치로 이동
                    }
                    heldObject = hit.transform.gameObject; // 새로운 오브젝트를 들게 함
                    originalPosition = heldObject.transform.position; // 오브젝트의 원래 위치를 저장
                    hasPickedUpSyringe = true; // Syringe를 들었다고 표시
                }
                else if ((hit.transform.CompareTag("bandage") || hit.transform.CompareTag("towel")) && heldObject == null && hasPickedUpSyringe) // 태그가 'bandage'나 'towel'인 경우, 그리고 heldObject가 null이며 syringe를 이미 들었다면
                {
                    if (heldObject != null) // 이미 오브젝트를 들고 있다면
                    {
                        heldObject.transform.position = originalPosition; // 오브젝트를 원래 위치로 이동
                    }
                    heldObject = hit.transform.gameObject; // 새로운 오브젝트를 들게 함
                    originalPosition = heldObject.transform.position; // 오브젝트의 원래 위치를 저장
                }
                else if ((hit.transform.CompareTag("bandage") || hit.transform.CompareTag("towel")) && heldObject == null && !hasPickedUpSyringe) // syringe를 들지 않았는데 bandage나 towel을 클릭한 경우
                {
                    StartCoroutine(ShowWarning("손 물릴 것 같아 마취부터하자")); // 경고 메시지 표시
                }
                else if (hit.transform.CompareTag("dog")) // 태그가 'dog'인 경우
                {
                    if (heldObject != null) // 오브젝트를 들고 있다면
                    {
                       
                        if (heldObject.CompareTag("towel"))
                        {
                            dogState.hasTowel = true; // 타월 상태 업데이트
                        }
                        else if (heldObject.CompareTag("bandage"))
                        {
                            dogState.hasBandage = true; // 주사기 상태 업데이트
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

    private IEnumerator ShowWarning(string message)
    {
        warningText.text = message; // 경고 메시지 설정
        warningText.gameObject.SetActive(true); // 경고 메시지 활성화
        yield return new WaitForSeconds(2f); // 2초 동안 메시지 표시
        warningText.gameObject.SetActive(false); // 경고 메시지 비활성화
    }
}
