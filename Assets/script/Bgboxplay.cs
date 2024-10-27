using UnityEngine;

public class Bgboxplay: MonoBehaviour
{
    private Vector2 originalPosition;

    void Start()
    {
        // �纵��˹��������
        originalPosition = transform.position;
        // ���¡�ѧ��ѹ ResetToOriginalPosition ��ѧ�ҡ��������
        ScheduleReset();
    }

    void ScheduleReset()
    {
        // �� UnityEngine.Random ������ա����§�����Ѻʹ
        float randomDelay = UnityEngine.Random.Range(6f, 8f);
        Invoke("ResetToOriginalPosition", randomDelay);
    }

    void ResetToOriginalPosition()
    {
        // ���絵��˹�
        transform.position = originalPosition;
        // ���¡�ѧ��ѹ ScheduleReset �ա��������������������
        ScheduleReset();
    }
}
