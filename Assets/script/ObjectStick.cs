using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObjectStick : MonoBehaviour
{
    // ฟังก์ชันเรียกเมื่อมีการชน
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่า object ที่ชนมี tag เป็น "Player" หรือไม่
        if (collision.gameObject.CompareTag("Player"))
        {
            // เปลี่ยน parent ของ object ที่ชนให้เป็น object นี้
            collision.transform.SetParent(transform);
        }
    }

    // ฟังก์ชันเรียกเมื่อการชนสิ้นสุดลง
    private void OnCollisionExit2D(Collision2D collision)
    {
        // ตรวจสอบว่า object ที่ชนมี tag เป็น "Player" หรือไม่
        if (collision.gameObject.CompareTag("Player"))
        {
            // ค้นหา object ที่มี tag "GameManager"
            GameObject gameManager = GameObject.FindWithTag("GameManager");

            {
                // เปลี่ยน parent ของ object ที่ชนให้เป็น GameManager
                collision.transform.SetParent(gameManager.transform);
            }

        }
    }
}
