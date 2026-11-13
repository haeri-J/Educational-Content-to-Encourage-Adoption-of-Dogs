using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class firstdogSubtitleController : MonoBehaviour
{
    public Text subtitleText; // 자막을 표시할 Text 컴포넌트
    public string[] subtitles = { }; // 표시할 자막들
    public float delay = 5f; // 자막 간의 시간 간격

    void Start()
    {
        StartCoroutine(ShowSubtitles());
    }

    IEnumerator ShowSubtitles()
    {
        foreach (string subtitle in subtitles)
        {
            subtitleText.text = subtitle; // 자막을 변경합니다.
            yield return new WaitForSeconds(delay); // 지정된 시간 동안 대기합니다.
        }
    }
}
