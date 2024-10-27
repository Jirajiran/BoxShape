using UnityEngine;

public class PopupObject : MonoBehaviour
{
    public float detectionRadius = 5f; // ระยะตรวจจับ
    public LayerMask playerLayer; // เลเยอร์ของ Player
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ทำให้ SpriteRenderer ล่องหนเริ่มต้น
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        // เช็คว่ามี Player อยู่ในระยะที่กำหนดหรือไม่
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (hitColliders.Length > 0)
        {
            // ถ้ามี Player ในระยะ
            spriteRenderer.enabled = true; // ทำให้เห็น
        }
        else
        {
            // ถ้าไม่มี Player ในระยะ
            spriteRenderer.enabled = false; // ทำให้ล่องหน
        }
    }

    private void OnDrawGizmosSelected()
    {
        // แสดง radius ใน editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
