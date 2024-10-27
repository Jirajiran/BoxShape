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
                SceneContro.instance.NextLevel(); // แก้การสะกด
            }
            else
            {
                SceneContro.instance.LoadScene(LevelChoose); // แก้การสะกด
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            playerInTrigger = true; // ผู้เล่นอยู่ใน trigger
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            playerInTrigger = false; // ผู้เล่นออกจาก trigger
        }
    }
}
