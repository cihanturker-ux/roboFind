using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathController : MonoBehaviour
{
    public static DeathController instance;

    [SerializeField] GameObject panel;
    public FirstPersonController fps;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        fps.m_MouseLook.XSensitivity = 0;
        fps.m_MouseLook.YSensitivity = 0;
        MouseLook.m_cursorIsLocked = false;
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
