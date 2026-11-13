using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerBody;
    public float m_mouseSensitivity = 100.0f;
    private float m_xRotation = 0f;

    void Update()
    {
        PlayerLook();
    }

    void PlayerLook()
    {
        if (!playerBody.GetComponent<PlayerController>().m_isLookLocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * m_mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * m_mouseSensitivity * Time.deltaTime;

            m_xRotation -= mouseY;
            m_xRotation = Mathf.Clamp(m_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(m_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
