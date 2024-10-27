using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVisibility : MonoBehaviour
{
    // List ของ GameObject ที่ต้องการให้สุ่มเปิด/ปิดการมองเห็น
    public List<GameObject> objectsToToggle;

    void Start()
    {
        // สุ่มเลือก GameObject หนึ่งจาก List
        int randomIndex = Random.Range(0, objectsToToggle.Count);

        // เปลี่ยนสถานะการมองเห็นของ GameObject ที่สุ่มมา
        bool isActive = objectsToToggle[randomIndex].activeSelf;
        objectsToToggle[randomIndex].SetActive(!isActive);

        // สร้าง List ใหม่สำหรับเก็บ GameObject ที่ไม่ถูกเลือก
        List<GameObject> objectsToDestroy = new List<GameObject>();

        // ตรวจสอบ GameObject ที่ไม่ถูกสุ่มเลือก
        for (int i = 0; i < objectsToToggle.Count; i++)
        {
            if (i != randomIndex)
            {
                // เพิ่ม GameObject ที่ไม่ถูกเลือกลงใน List เพื่อทำการลบ
                objectsToDestroy.Add(objectsToToggle[i]);
            }
        }

        // ลบ GameObject ที่ไม่ถูกเลือก
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        // ถ้าคุณต้องการลบ GameObject ที่ไม่ถูกเลือกออกจาก List ด้วย
        // คุณสามารถใช้ลูปเพื่อลบ GameObject ได้เช่นกัน
        objectsToToggle.RemoveAll(item => objectsToDestroy.Contains(item));
    }
}
