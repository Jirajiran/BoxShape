using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObjectStick : MonoBehaviour
{
    // �ѧ��ѹ���¡������ա�ê�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ǩ�ͺ��� object ��誹�� tag �� "Player" �������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����¹ parent �ͧ object ��誹����� object ���
            collision.transform.SetParent(transform);
        }
    }

    // �ѧ��ѹ���¡����͡�ê�����شŧ
    private void OnCollisionExit2D(Collision2D collision)
    {
        // ��Ǩ�ͺ��� object ��誹�� tag �� "Player" �������
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���� object ����� tag "GameManager"
            GameObject gameManager = GameObject.FindWithTag("GameManager");

            {
                // ����¹ parent �ͧ object ��誹����� GameManager
                collision.transform.SetParent(gameManager.transform);
            }

        }
    }
}
