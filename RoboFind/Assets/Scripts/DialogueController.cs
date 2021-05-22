using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text text;

    private bool isShowing = false;

    private void Update()
    {
        print("fıssss");
        if (isShowing)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    if (text.text.Length < 3)
                    {
                        text.text += i;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (text.text.Length > 0)
                {
                    text.text = text.text.Substring(0, text.text.Length - 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                panel.SetActive(false);
                isShowing = false;
                text.text = "";
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            isShowing = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panel.SetActive(false);
            isShowing = false;
            text.text = "";
        }
    }
}
