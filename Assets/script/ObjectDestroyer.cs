using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float delay = 3f; // เวลาที่ต้องการให้ลบอ็อบเจ็กต์ (วินาที)

    void Start()
    {
        Invoke("DestroySelf", delay);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
