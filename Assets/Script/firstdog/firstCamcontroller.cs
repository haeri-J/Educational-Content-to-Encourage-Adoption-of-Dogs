using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class firstCamcontroller : MonoBehaviour
{
    public string sceneName; // 변경하려는 씬의 이름
    public float delayBeforeMoving = 60f; // 움직임 전 대기 시간 (초)
    public float moveDuration = 5f; // 움직임 지속 시간 (초)
    public Vector3 moveDirection = new Vector3(0, 1, -1); // 움직일 방향
    public float moveSpeed = 1f; // 움직임 속도
    public Transform target; // 바라볼 대상 오브젝트

    void Start()
    {
        StartCoroutine(MoveCamera());
    }
    void Update()
    {
        transform.LookAt(target);
    }

    IEnumerator MoveCamera()
    {
        // 움직임 전 대기
        yield return new WaitForSeconds(delayBeforeMoving);

        // 움직임 시작 시간 저장
        float startTime = Time.time;

        // 움직임 시작 위치 저장
        Vector3 startPosition = transform.position;

        // 지정된 시간 동안 움직임
        while (Time.time < startTime + moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            transform.position = startPosition + moveDirection * moveSpeed * t;
            yield return null;
        }

        // 움직임 완료 후 씬 변경
        SceneManager.LoadScene(sceneName);
    }
}
