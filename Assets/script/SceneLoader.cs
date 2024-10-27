using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string playerTag = "Player"; // Tag ของ Player
    public Transform targetObject; // Object ที่จะย้ายไปหา
    public float delay = 0.1f; // เวลาหน่วงก่อนที่จะย้าย Player

    private Transform player; // ตัวแปรสำหรับ Player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag)?.transform; // ค้นหา Player ด้วย Tag
        StartCoroutine(MovePlayerAfterDelay());
    }

    private IEnumerator MovePlayerAfterDelay()
    {
        yield return new WaitForSeconds(delay); // รอเวลาตามที่กำหนด
        MovePlayerToTarget();
    }

    void MovePlayerToTarget()
    {
        if (player != null && targetObject != null)
        {
            player.position = targetObject.position; // ย้าย Player ไปยังตำแหน่งของ Object ที่เลือก
        }
    }
}
