using UnityEngine;

public class MoneyFood : MonoBehaviour
{
    public int scoreValue = 1; // ��ṹ������������
    public GameObject Effect; // �ѵ�ط���ͧ������ҧ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ��Ǩ�ͺ��Ҫ��Ѻ Player
        {
            ScoreManager.Instance.AddScore(scoreValue); // ������ṹ

            // ���ҧ�ѵ������
            if (Effect != null)
            {
                Instantiate(Effect, transform.position, Quaternion.identity); // ���ҧ�ѵ����������˹����
            }

            Destroy(gameObject, 0.1f); // ź�ѵ�ط��������ѧ�ҡ���ҧ�ѵ������
        }
    }
}
