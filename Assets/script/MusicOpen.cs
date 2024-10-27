using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicOpen : MonoBehaviour
{
    public GameObject objectToToggle;  // Object ที่ต้องการเปิดหรือปิด
    public string[] scenesToActivateIn;  // รายชื่อฉากที่ต้องการเปิด object นี้
    public string[] scenesToDeactivateIn;  // รายชื่อฉากที่ต้องการปิด object นี้

    private bool isActive;  // ตัวแปรเพื่อเก็บสถานะการเปิดหรือปิดของ object

    void OnEnable()
    {
        // ฟังเหตุการณ์เมื่อมีการโหลดฉาก
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // หยุดฟังเหตุการณ์เมื่อมีการโหลดฉาก
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // เริ่มต้นสถานะการเปิดหรือปิดของ object
        isActive = false;
        UpdateObjectStatus(SceneManager.GetActiveScene().name);  // ตรวจสอบสถานะในฉากเริ่มต้น
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateObjectStatus(scene.name);  // ตรวจสอบสถานะเมื่อมีการโหลดฉาก
    }

    void UpdateObjectStatus(string currentSceneName)
    {
        // ตรวจสอบว่าชื่อฉากอยู่ในรายชื่อฉากที่ต้องการเปิดหรือไม่
        if (System.Array.Exists(scenesToActivateIn, sceneName => sceneName == currentSceneName))
        {
            isActive = true;  // เปิดใช้งาน
        }
        else if (System.Array.Exists(scenesToDeactivateIn, sceneName => sceneName == currentSceneName))
        {
            isActive = false;  // ปิดใช้งาน
        }

        // เปิดหรือปิดการใช้งาน object ตามสถานะ
        objectToToggle.SetActive(isActive);
    }
}
