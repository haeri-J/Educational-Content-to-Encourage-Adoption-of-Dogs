using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 로딩을 위해 추가

public class cshCamMovement : MonoBehaviour
{
    public float delayTime = 6.0f; // 지연 시간
    public float speed = 2.0f; // 카메라 이동 속도
    public float amplitude = 1.0f; // 이동 범위
    public string nextSceneName; // 로드할 다음 씬 이름

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(StartMovementAfterDelay());
    }

    private IEnumerator StartMovementAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        float elapsedTime = 0f;

        while (elapsedTime < 5.0f)
        {
            float time = Time.time * speed;
            float y = Mathf.Sin(time) * amplitude;
            float z = Mathf.Cos(time) * amplitude;

            // Y축과 Z축 방향으로 이동
            transform.position = initialPosition + new Vector3(0, y, z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 2초 후 씬 로드
        SceneManager.LoadScene("hospital3");
    }
}
