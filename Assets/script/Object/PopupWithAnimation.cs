using UnityEngine;

public class PopupWithAnimation : MonoBehaviour
{
    public float detectionRadius = 5f; // ระยะตรวจจับ
    public LayerMask playerLayer; // เลเยอร์ของ Player
    private Animator animator; // Animator สำหรับควบคุมการเล่น Animation
    private bool hasBeenDetected = false; // ตัวแปรเก็บสถานะการตรวจจับ

    void Start()
    {
        // เชื่อมต่อกับ Component Animator ใน GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // เช็คว่ามี Player อยู่ในระยะที่กำหนดหรือไม่
        if (!hasBeenDetected) // ตรวจสอบเฉพาะเมื่อยังไม่เคยถูกตรวจจับ
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

            if (hitColliders.Length > 0)
            {
                // ถ้ามี Player ในระยะและยังไม่เคยถูกตรวจจับ
                animator.SetTrigger("PlayAnimation"); // ใช้ Trigger แทนการระบุชื่อ Animation
                hasBeenDetected = true; // ตั้งค่าว่าถูกตรวจจับแล้ว
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // แสดง radius ใน editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
