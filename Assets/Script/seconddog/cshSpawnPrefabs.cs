using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스 추가

public class cshSpawnPrefabs : MonoBehaviour
{
    public GameObject prefab; // 프리팹을 연결할 변수
    public GameObject[] spawnPoints; // 스폰 포인트를 저장할 배열
    private List<GameObject> spawnedPrefabs = new List<GameObject>(); // 생성된 프리팹을 저장할 리스트

    void Start()
    {
        StartCoroutine(SpawnAtPoints());
    }

    IEnumerator SpawnAtPoints()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            GameObject go = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
            spawnedPrefabs.Add(go);
            yield return new WaitForSeconds(1f); // 1초 간격으로 프리팹 생성
        }

        yield return new WaitForSeconds(2f); // 모든 프리팹이 생성된 후 2초 대기

        foreach (GameObject go in spawnedPrefabs)
        {
            // 프리팹의 z축이 카메라를 향하도록 회전
            Vector3 direction = (Camera.main.transform.position - go.transform.position).normalized;
            go.transform.rotation = Quaternion.LookRotation(direction);

            // 카메라 방향으로 힘을 가함
            go.GetComponent<Rigidbody>().AddForce(direction * 2f, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(3f); // 모든 프리팹이 움직인 후 5초 대기

        SceneManager.LoadScene("hospital2"); // 다음 씬으로 이동
    }
}
