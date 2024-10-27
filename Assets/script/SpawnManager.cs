using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // �ҡ����Ф÷��س��ͧ�������Դ���价����
    public Transform spawnPoint; // �ҡ GameObject SpawnPoint ���价����

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
