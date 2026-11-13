using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // 씬을 변경합니다.
        SceneManager.LoadScene(sceneName);

    }
}
