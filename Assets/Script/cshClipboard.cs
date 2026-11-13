using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class cshClipboard : MonoBehaviour
{
    public Transform playerChildObject; // 플레이어의 자식 오브젝트
    private GameObject heldObject; // 플레이어가 들고 있는 오브젝트
    private Vector3 originalPosition; // 오브젝트의 원래 위치를 저장할 변수

    public Text subtitleText; // 자막을 표시할 Text 컴포넌트
    public string[] subtitles = { "흐음..", "아무래도 소형견들은 잦은 근친 교배로 유전병을 달고 있지", "애도 슬개골이 안 좋은가봐.." }; // 표시할 자막들
    public float delay = 5f; // 자막 간의 시간 간격

    private bool isShowingSubtitles = false; // 자막이 표시되고 있는지 여부

    void Update()
    {
        if (heldObject != null) // 오브젝트를 들고 있다면
        {
            heldObject.transform.position = playerChildObject.position; // 오브젝트의 위치를 플레이어의 자식 오브젝트 위치로 업데이트
        }

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 눌렀을 때
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("board")) // 태그가 'board'일 때
                {
                    if (heldObject == null)
                    {
                        heldObject = hit.transform.gameObject; // 새로운 오브젝트를 들게 함
                        originalPosition = heldObject.transform.position; // 오브젝트의 원래 위치를 저장

                        if (!isShowingSubtitles)
                        {
                            StartCoroutine(ShowSubtitles());
                        }
                    }
                    else
                    {
                        heldObject.transform.position = originalPosition; // 오브젝트를 원래 위치로 이동
                        heldObject = null;
                    }
                }
            }
        }
    }

    IEnumerator ShowSubtitles()
    {
        isShowingSubtitles = true; // 자막이 표시되고 있음을 표시
        foreach (string subtitle in subtitles)
        {
            subtitleText.text = subtitle; // 자막을 변경합니다.
            yield return new WaitForSeconds(delay); // 지정된 시간 동안 대기합니다.
        }
        subtitleText.text = ""; // 자막을 지웁니다.
        isShowingSubtitles = false; // 자막 표시가 끝났음을 표시
    }
}
