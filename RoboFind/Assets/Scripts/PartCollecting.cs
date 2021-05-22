using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollecting : MonoBehaviour
{
    public GameObject body;
    public Material wallLight;
    public int PartCollect = 0;
   // public bool getPart = false;
    public Light PartLight;
    public bool isShieldEnabled = true;

    private void Start()
    {
        wallLight.SetColor("_EmissionColor", Color.green);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!isShieldEnabled && Input.GetKeyDown(KeyCode.E))
            {
                PartCollect += 1;
                body.SetActive(false);
                PartLight.color = Color.red;
                PartLight.intensity = 20f;
                PartLight.range = 10;
                wallLight.SetColor("_EmissionColor", Color.red);
            }
            
            //getPart = true;
        }
    }
}
