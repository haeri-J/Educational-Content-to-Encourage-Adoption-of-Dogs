using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshfirstdogstate : MonoBehaviour
{
    public bool hasTowel = false; // 타월 상태
    public bool hasSyringe = false; // 주사기 상태
    public Button interactButton; // 상호작용 버튼
    private Animator animator; // 애니메이터 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        interactButton.interactable = false;

        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator 컴포넌트를 찾을 수 없습니다. 게임 오브젝트에 추가되어 있는지 확인하세요.");
        }
    }

    void Update()
    {
        // 모든 조건이 트루일 때 버튼 활성화
        if (hasTowel && hasSyringe)
        {
            interactButton.interactable = true;

            // 애니메이션 변수 tail을 true로 설정
            if (animator != null)
            {
                animator.SetBool("sit", false);
                animator.SetBool("tail", true);
            }
        }
    }
}
