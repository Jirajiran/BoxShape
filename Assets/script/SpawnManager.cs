using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // ลากตัวละครที่คุณต้องการให้เกิดเข้าไปที่นี่
    public Transform spawnPoint; // ลาก GameObject SpawnPoint เข้าไปที่นี่

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
