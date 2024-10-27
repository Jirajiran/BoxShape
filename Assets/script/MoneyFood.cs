using UnityEngine;

public class MoneyFood : MonoBehaviour
{
    public int scoreValue = 1; // คะแนนที่ได้เมื่อเก็บ
    public GameObject Effect; // วัตถุที่ต้องการสร้างใหม่

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่าชนกับ Player
        {
            ScoreManager.Instance.AddScore(scoreValue); // เพิ่มคะแนน

            // สร้างวัตถุใหม่
            if (Effect != null)
            {
                Instantiate(Effect, transform.position, Quaternion.identity); // สร้างวัตถุใหม่ที่ตำแหน่งเดิม
            }

            Destroy(gameObject, 0.1f); // ลบวัตถุที่เก็บได้หลังจากสร้างวัตถุใหม่
        }
    }
}
