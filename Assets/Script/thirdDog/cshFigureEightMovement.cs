using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshFigureEightMovement : MonoBehaviour
{
    public float speed = 2.0f; // 오브젝트 이동 속도
    public float size = 1.0f; // 8자 모양의 크기
    public float delayTime = 6.0f; // 지연 시간
    public GameObject prefab; // 생성할 프리팹

    private float time;
    private GameObject instantiatedPrefab;

    void Start()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    void Update()
    {
        if (instantiatedPrefab != null)
        {
            time += Time.deltaTime * speed;

            // 가로로 누운 8자 형태의 경로를 따라 이동
            float x = Mathf.Sin(time) * size;
            float y = Mathf.Sin(time * 2) * size / 2;

            instantiatedPrefab.transform.position = new Vector3(transform.position.x+x, transform.position.y+y, instantiatedPrefab.transform.position.z);
        }
    }

    private IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        // 현재 위치에 프리팹 생성
        instantiatedPrefab = Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
