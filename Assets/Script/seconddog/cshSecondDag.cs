using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshSecondDag : MonoBehaviour
{
    public bool hasTowel = false; // 타월 상태
    public bool haspill = false; // 주사기 상태
    public Button interactButton; // 상호작용 버튼
    private Animator animator; // 애니메이터 컴포넌트
    public Transform bowlposition;
    public Transform dogposition;

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
        if (haspill)
        {
            // 게임 오브젝트 위치를 dogposition으로 변경
            transform.position = dogposition.position;

            // 게임 오브젝트의 로테이션을 (0, 0, 0)으로 설정
            transform.rotation = Quaternion.Euler(0, 0, 0);

            // 게임 오브젝트가 bowlposition을 바라보게 회전
            transform.LookAt(new Vector3(bowlposition.position.x, transform.position.y, bowlposition.position.z));

            // 애니메이션 변수 eat을 true로 설정
            if (animator != null)
            {
                animator.SetBool("eat", true);
            }

            // 모든 조건이 트루일 때 버튼 활성화
            if (hasTowel)
            {
                StartCoroutine(ActivateTailAfterDelay(3f)); // 5초 후 tail 애니메이션 활성화
                interactButton.interactable = true;
            }
        }
    }

    private IEnumerator ActivateTailAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (animator != null)
        {
            animator.SetBool("tail", true);
        }
    }
}
