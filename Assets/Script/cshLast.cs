using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 요소를 사용하기 위해 필요

public class cshLast : MonoBehaviour
{
    // 패널과 텍스트를 참조할 변수
    public GameObject panel;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        // Start에서 패널과 텍스트를 비활성화
        panel.SetActive(false);
        text.SetActive(false);
    }

    // 버튼 클릭 시 호출될 메서드
    public void OnCompleteButtonClick()
    {
        // 패널과 텍스트를 활성화
        panel.SetActive(true);
        text.SetActive(true);
    }
}
