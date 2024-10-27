using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSize : MonoBehaviour
{
    // กำหนด min และ max ด้วยตัวเลข
    public float minSize = 0.5f; // ขนาดต่ำสุดที่คุณต้องการ
    public float maxSize = 2f;   // ขนาดสูงสุดที่คุณต้องการ

    // ฟังก์ชันสำหรับสุ่มขนาดโดยรับค่าตัวเลขจากภายนอก
    public void SetRandomSize(float min, float max)
    {
        // สุ่มค่าขนาดสำหรับแกน X และ Y จากค่าที่ผู้ใช้กำหนด
        float randomSizeX = Random.Range(min, max);
        float randomSizeY = Random.Range(min, max);

        // ตั้งค่าขนาดของวัตถุ
        transform.localScale = new Vector3(randomSizeX, randomSizeY, 1f);
    }
    void Start()
    {

        // เรียกใช้งานฟังก์ชัน SetRandomSize
        RandomSize randomSizeScript = GetComponent<RandomSize>();
        randomSizeScript.SetRandomSize(minSize, maxSize);
    }

}
