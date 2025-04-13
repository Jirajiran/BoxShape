using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float delay = 3f; // ���ҷ���ͧ������ź��ͺ�硵� (�Թҷ�)

    void Start()
    {
        Invoke("DestroySelf", delay);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
