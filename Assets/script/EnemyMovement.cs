using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float baseMoveSpeed = 3f;        // �������Ǣͧ�������͹���ͧ Square
    public float baseJumpForce = 5f;        // ���ѧ���ⴴ�ͧ Square
    public float detectionRadius = 5f;      // ����ա�õ�Ǩ�Ѻ�ѵ�� "player"

    private GameObject player;              // �ѵ�ط������ "player"
    private Rigidbody2D rb;
    private bool Ground;                // ��Ǩ�ͺ��� Square ���躹����������

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

        // ��Ǩ�ͺ������ҧ�����ҧ Square �Ѻ�ѵ�� "player"
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // ��� Square ��������з������ö��Ǩ�Ѻ�ѵ�� "player" ��
        if (distanceToPlayer <= detectionRadius)
        {
            // ���ǡ��������价���ѵ�� "player"
            Vector2 direction = player.transform.position - transform.position;

            // ������ǡ���� direction �դ��������ҡѺ 1
            direction.Normalize();

            // ��Ѻ Square 㹷�ȷҧ�ͧ�ǡ���� direction ���¤������� moveSpeed
            rb.velocity = new Vector2(direction.x * baseMoveSpeed, rb.velocity.y);

            // ��Ǩ�ͺ��� Square ���躹����������
            if (Ground)
            {
                // ���ⴴ
                rb.AddForce(new Vector2(0f, baseJumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            // ��� Square ��ҧ�ҡ�ѵ�� "player" �ҡ�������з������ö��Ǩ�Ѻ��
            // ��ش��Ѻ Square
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    private void OnDrawGizmosSelected()
    {
        // �ʴ� radius � editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ǩ�ͺ��� Square ���躹����������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {


            Ground = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // ��Ǩ�ͺ��� Square �͡�ҡ����������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Ground = false;
        }
    }
}
