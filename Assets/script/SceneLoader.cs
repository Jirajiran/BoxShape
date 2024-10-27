using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string playerTag = "Player"; // Tag �ͧ Player
    public Transform targetObject; // Object �����������
    public float delay = 0.1f; // ����˹�ǧ��͹�������� Player

    private Transform player; // ���������Ѻ Player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform; // ���� Player ���� Tag
        StartCoroutine(MovePlayerAfterDelay());
    }

    private IEnumerator MovePlayerAfterDelay()
    {
        yield return new WaitForSeconds(delay); // �����ҵ������˹�
        MovePlayerToTarget();
    }

    void MovePlayerToTarget()
    {
        if (player != null && targetObject != null)
        {
            player.position = targetObject.position; // ���� Player ��ѧ���˹觢ͧ Object ������͡
        }
    }
}
