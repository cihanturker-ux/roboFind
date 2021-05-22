using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryWrite : MonoBehaviour
{
    public AudioSource soundEffect;
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public GameObject screenDim;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        screenDim.SetActive(true);
        soundEffect.Stop();
    }
}
