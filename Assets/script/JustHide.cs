using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustHide : MonoBehaviour
{
    // ฟังก์ชันนี้จะถูกเรียกตอนเริ่มต้น
    void Start()
    {
        // ปิดการมองเห็นของวัตถุที่สคริปต์นี้ถูกแนบอยู่
        gameObject.SetActive(false);
    }
}