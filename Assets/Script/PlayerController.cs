using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 2.0f;
    public bool m_isLookLocked = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // 마우스 포인터를 보이게
    }

    void Update()
    {
        PlayerMove();

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            m_isLookLocked = !m_isLookLocked;
        }
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = Vector3.right * h;
        Vector3 moveVertical = Vector3.forward * v;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized;

        transform.Translate(velocity * m_moveSpeed * Time.deltaTime, Space.World);
    }
}
