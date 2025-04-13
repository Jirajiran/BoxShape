using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonePoint : MonoBehaviour
{
    public bool GoNextLevel;
    public string LevelChoose;

    private bool playerInTrigger = false;

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (GoNextLevel)
            {
                SceneContro.instance.NextLevel(); // �����С�
            }
            else
            {
                SceneContro.instance.LoadScene(LevelChoose); // �����С�
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            playerInTrigger = true; // ����������� trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            playerInTrigger = false; // �������͡�ҡ trigger
        }
    }
}
