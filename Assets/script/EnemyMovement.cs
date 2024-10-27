using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float baseMoveSpeed = 3f;        // ความเร็วของการเคลื่อนที่ของ Square
    public float baseJumpForce = 5f;        // กำลังกระโดดของ Square
    public float detectionRadius = 5f;      // รัศมีการตรวจจับวัตถุ "player"

    private GameObject player;              // วัตถุที่มีแท็ก "player"
    private Rigidbody2D rb;
    private bool Ground;                // ตรวจสอบว่า Square อยู่บนพื้นหรือไม่

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        if (player == null)
        {
            return;
        }

        // ตรวจสอบระยะห่างระหว่าง Square กับวัตถุ "player"
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // ถ้า Square อยู่ในระยะที่สามารถตรวจจับวัตถุ "player" ได้
        if (distanceToPlayer <= detectionRadius)
        {
            // หาเวกเตอร์ที่ชี้ไปที่วัตถุ "player"
            Vector2 direction = player.transform.position - transform.position;

            // ทำให้เวกเตอร์ direction มีความยาวเท่ากับ 1
            direction.Normalize();

            // ขยับ Square ในทิศทางของเวกเตอร์ direction ด้วยความเร็ว moveSpeed
            rb.velocity = new Vector2(direction.x * baseMoveSpeed, rb.velocity.y);

            // ตรวจสอบว่า Square อยู่บนพื้นหรือไม่
            if (Ground)
            {
                // กระโดด
                rb.AddForce(new Vector2(0f, baseJumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            // ถ้า Square ห่างจากวัตถุ "player" มากกว่าระยะที่สามารถตรวจจับได้
            // หยุดขยับ Square
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    private void OnDrawGizmosSelected()
    {
        // แสดง radius ใน editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่า Square อยู่บนพื้นหรือไม่
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {


            Ground = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ตรวจสอบว่า Square ออกจากพื้นหรือไม่
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Ground = false;
        }
    }
}
