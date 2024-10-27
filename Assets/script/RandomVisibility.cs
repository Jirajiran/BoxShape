using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVisibility : MonoBehaviour
{
    // List �ͧ GameObject ����ͧ�����������Դ/�Դ����ͧ���
    public List<GameObject> objectsToToggle;

    void Start()
    {
        // �������͡ GameObject ˹�觨ҡ List
        int randomIndex = Random.Range(0, objectsToToggle.Count);

        // ����¹ʶҹС���ͧ��繢ͧ GameObject ���������
        bool isActive = objectsToToggle[randomIndex].activeSelf;
        objectsToToggle[randomIndex].SetActive(!isActive);

        // ���ҧ List ��������Ѻ�� GameObject ������١���͡
        List<GameObject> objectsToDestroy = new List<GameObject>();

        // ��Ǩ�ͺ GameObject ������١�������͡
        for (int i = 0; i < objectsToToggle.Count; i++)
        {
            if (i != randomIndex)
            {
                // ���� GameObject ������١���͡ŧ� List ���ͷӡ��ź
                objectsToDestroy.Add(objectsToToggle[i]);
            }
        }

        // ź GameObject ������١���͡
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        // ��Ҥس��ͧ���ź GameObject ������١���͡�͡�ҡ List ����
        // �س����ö���ٻ����ź GameObject ���蹡ѹ
        objectsToToggle.RemoveAll(item => objectsToDestroy.Contains(item));
    }
}
