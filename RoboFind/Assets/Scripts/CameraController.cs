using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float angle;

    private float minAngle;
    private float maxAngle;

    private void Awake()
    {
        minAngle = transform.eulerAngles.y - angle;
        maxAngle = transform.eulerAngles.y + angle;
    }

    void Update()
    {
        float value = Mathf.Lerp(minAngle, maxAngle, (Mathf.Cos(Time.time) + 1f) / 2f);
        transform.rotation = Quaternion.Euler(0, value, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DeathController.instance.GameOver();
        }
    }
}
