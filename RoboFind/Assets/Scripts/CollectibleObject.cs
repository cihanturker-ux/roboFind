using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField] GameObject panel, scriptText, scriptText2, areURobot, imNotRobot, cursor, systemDown, Shield;

    private PartCollecting partCollecting;
    int i = 0;

    private void Start()
    {
        partCollecting = GetComponent<PartCollecting>();    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (i == 0)
            {
                StartCoroutine(HackPanelCo());
            }

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(HackPanelCo());
        }
    }

    IEnumerator HackPanelCo()
    {
        panel.SetActive(true);
        areURobot.SetActive(true);
        cursor.SetActive(true);
        yield return new WaitForSeconds(1);
        areURobot.SetActive(false);
        imNotRobot.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        imNotRobot.SetActive(false);
        cursor.SetActive(false);
        scriptText.SetActive(true);
        scriptText2.SetActive(true);
        yield return new WaitForSeconds(1);
        scriptText.SetActive(false);
        scriptText2.SetActive(false);
        systemDown.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        panel.SetActive(false);
        i = 1;
        Shield.SetActive(false);
        partCollecting.isShieldEnabled = false;
    }
}
