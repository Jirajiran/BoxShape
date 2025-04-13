using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSize : MonoBehaviour
{
    // ��˹� min ��� max ���µ���Ţ
    public float minSize = 0.5f; // ��Ҵ����ش���س��ͧ���
    public float maxSize = 2f;   // ��Ҵ�٧�ش���س��ͧ���

    // �ѧ��ѹ����Ѻ������Ҵ���Ѻ��ҵ���Ţ�ҡ��¹͡
    public void SetRandomSize(float min, float max)
    {
        // ������Ң�Ҵ����Ѻ᡹ X ��� Y �ҡ��ҷ�������˹�
        float randomSizeX = Random.Range(min, max);
        float randomSizeY = Random.Range(min, max);

        // ��駤�Ң�Ҵ�ͧ�ѵ��
        transform.localScale = new Vector3(randomSizeX, randomSizeY, 1f);
    }
    void Start()
    {

        // ���¡��ҹ�ѧ��ѹ SetRandomSize
        RandomSize randomSizeScript = GetComponent<RandomSize>();
        randomSizeScript.SetRandomSize(minSize, maxSize);
    }

}
