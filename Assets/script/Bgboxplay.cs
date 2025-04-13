using UnityEngine;

public class Bgboxplay: MonoBehaviour
{
    private Vector2 originalPosition;

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้น
        originalPosition = transform.position;
        // เรียกฟังก์ชัน ResetToOriginalPosition หลังจากเวลาสุ่ม
        ScheduleReset();
    }

    void ScheduleReset()
    {
        // ใช้ UnityEngine.Random เพื่อหลีกเลี่ยงความสับสน
        float randomDelay = UnityEngine.Random.Range(6f, 8f);
        Invoke("ResetToOriginalPosition", randomDelay);
    }

    void ResetToOriginalPosition()
    {
        // รีเซ็ตตำแหน่ง
        transform.position = originalPosition;
        // เรียกฟังก์ชัน ScheduleReset อีกครั้งเพื่อสุ่มเวลาใหม่
        ScheduleReset();
    }
}
