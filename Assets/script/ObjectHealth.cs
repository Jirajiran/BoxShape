using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private bool canTakeDamage = true;
    public float damageCooldown = 0.25f;
    public GameObject Dead;
    public List<GameObject> Drop;


    public Sprite[] damageSprites; // รายการรูปภาพที่จะใช้เมื่อถูกทำลาย
    private SpriteRenderer spriteRenderer;
    public AudioClip[] damageSounds; // รายการเสียงที่จะใช้เล่นเมื่อถูกทำลาย

    private AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (canTakeDamage && (collision.CompareTag("Player") || collision.CompareTag("Neutral")))
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                maxHealth--;
                canTakeDamage = false;
                StartCoroutine(ResetDamageCooldown());

                // เล่นเสียงที่สุ่มมาจากรายการเสียงที่กำหนด
                if (damageSounds.Length > 0)
                {
                    int randomSoundIndex = Random.Range(0, damageSounds.Length);
                    AudioClip randomSound = damageSounds[randomSoundIndex];
                    audioSource.PlayOneShot(randomSound);
                }

                // เปลี่ยนรูปภาพตามสถานะที่ถูกทำลาย
                if (damageSprites.Length > 0)
                {
                    int spriteIndex = Mathf.Clamp(maxHealth, 0, damageSprites.Length - 1);
                    spriteRenderer.sprite = damageSprites[spriteIndex];

                }
            }
        }
    }

    private IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

    private void Die()
    {
        // ทำอะไรก็ตามที่ต้องการเมื่อ Object Health ถูกทำลาย
        Instantiate(Dead, transform.position, Quaternion.identity);

        foreach (GameObject item in Drop)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    
}
