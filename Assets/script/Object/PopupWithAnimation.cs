using UnityEngine;

public class PopupWithAnimation : MonoBehaviour
{
    public float detectionRadius = 5f; // ���е�Ǩ�Ѻ
    public LayerMask playerLayer; // �������ͧ Player
    private Animator animator; // Animator ����Ѻ�Ǻ��������� Animation
    private bool hasBeenDetected = false; // �������ʶҹС�õ�Ǩ�Ѻ

    void Start()
    {
        // �������͡Ѻ Component Animator � GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ������� Player ��������з���˹��������
        if (!hasBeenDetected) // ��Ǩ�ͺ੾��������ѧ����¶١��Ǩ�Ѻ
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

            if (hitColliders.Length > 0)
            {
                // ����� Player ���������ѧ����¶١��Ǩ�Ѻ
                animator.SetTrigger("PlayAnimation"); // �� Trigger ᷹����кت��� Animation
                hasBeenDetected = true; // ��駤����Ҷ١��Ǩ�Ѻ����
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // �ʴ� radius � editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
