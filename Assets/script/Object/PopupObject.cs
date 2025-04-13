using UnityEngine;

public class PopupObject : MonoBehaviour
{
    public float detectionRadius = 5f; // ���е�Ǩ�Ѻ
    public LayerMask playerLayer; // �������ͧ Player
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ����� SpriteRenderer ��ͧ˹�������
        spriteRenderer.enabled = false;
    }

    void Update()
    {
        // ������� Player ��������з���˹��������
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (hitColliders.Length > 0)
        {
            // ����� Player �����
            spriteRenderer.enabled = true; // ��������
        }
        else
        {
            // �������� Player �����
            spriteRenderer.enabled = false; // �������ͧ˹
        }
    }

    private void OnDrawGizmosSelected()
    {
        // �ʴ� radius � editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
