using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    

    private Transform spawnPoint;
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;

    public GameObject ShildPlayer;

    private bool canDash = true;
    private bool isDashing;
    private Coroutine dashCoroutine;
    private Coroutine immunityCoroutine;
    private float dashingPower = 80f;
    private float dashingTime = 0.05f;
    private float dashingCooldown = 0.5f;

    [SerializeField] private AudioClip takedamgesSound;
    //[SerializeField] private AudioClip GameOverSound;
    [SerializeField] private AudioClip[] dashSounds; // อาร์เรย์เสียง Dash

    private AudioSource audioSource; // ตัวเก็บเสียง

    private bool isJumping;
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    public int HpValue;
    public int NumberHp;
    private bool isDamageCooldown = false;

    public Image[] HpImages;
    public Sprite FullHp;
    public Sprite EmptyHp;

    public GameObject gameOverScreen;



 

    private void Start()
    {

        audioSource = GetComponent<AudioSource>(); // เริ่มต้น AudioSource

    }

   
    private void Update()
    {
            if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
        }

        if (Input.GetMouseButton(0) && canDash)
        {
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }

            dashCoroutine = StartCoroutine(Dash());
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if ((Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        Flip();

        UpdateHpUI();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        ////Debug.Log("Start Dash");
        canDash = false;
        isDashing = true;

        // ตรวจสอบว่าตัว Rigidbody ไม่ใช่ null
        if (rb == null)
        {
            ////Debug.LogError("Rigidbody is not assigned!");
            yield break;
        }

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        ////Debug.Log("Gravity set to 0 for Dash");

        if (dashSounds.Length > 0 )
        {
            int randomIndex = UnityEngine.Random.Range(0, dashSounds.Length); // ระบุ namespace ที่ชัดเจน
            audioSource.PlayOneShot(dashSounds[randomIndex]);
        }
        else
        {
            //Debug.LogError("AudioManager or dashSounds is not set properly.");
        }


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = (mousePosition - transform.position).normalized;

        float initialVerticalVelocity = rb.velocity.y;

        rb.velocity = new Vector2(dashDirection.x * dashingPower, initialVerticalVelocity);
        tr.emitting = true;

        //Debug.Log("Dashing...");
        yield return new WaitForSeconds(dashingTime);
        //Debug.Log("Dash complete");

        tr.emitting = false;
        rb.gravityScale = originalGravity;  // รีเซ็ตค่า gravity กลับ
        //Debug.Log("Gravity reset to original value");

        isDashing = false;

        if (immunityCoroutine != null)
        {
            StopCoroutine(immunityCoroutine);
        }

        immunityCoroutine = StartCoroutine(ImmunityCooldown());

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        ////Debug.Log("Dash cooldown complete, can dash again");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDashing)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Neutral"))
            {
                StartCoroutine(ImmunityCooldown());
                return;
            }
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Neutral"))
        {
            TakeDamage();
        }
    }

    private IEnumerator ImmunityCooldown()
    {
        isDamageCooldown = true;
        ShildPlayer.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        ShildPlayer.SetActive(false);
        isDamageCooldown = false;
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }

    private void UpdateHpUI()
    {
        if (HpValue > NumberHp)
        {
            HpValue = NumberHp;
        }

        for (int i = 0; i < HpImages.Length; i++)
        {
            if (i < HpValue)
            {
                HpImages[i].sprite = FullHp;
            }
            else
            {
                HpImages[i].sprite = EmptyHp;
            }

            if (i < NumberHp)
            {
                HpImages[i].enabled = true;
            }
            else
            {
                HpImages[i].enabled = false;
            }
        }

        if (HpValue <= 0)
        {
            GameOver();
        }
    }

    public void TakeDamage()
    {
        if (!isDamageCooldown)
        {
            HpValue -= 1;
            audioSource.PlayOneShot(takedamgesSound);


            isDamageCooldown = true;
            StartCoroutine(DamageCooldownCoroutine());
        }
    }

    private IEnumerator DamageCooldownCoroutine()
    {
        yield return new WaitForSeconds(0.01f);
        isDamageCooldown = false;
    }

    private void GameOver()
    {
        //audioSource.PlayOneShot(GameOverSound);

        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        // ค้นหา spawn point ที่ใกล้ที่สุด
        //FindNearestSpawnPoint();

        //// รีเซ็ตตำแหน่งผู้เล่นและค่า HP
        //Respawn();
    }

//    private void FindNearestSpawnPoint()
//    {
//        // ค้นหาออบเจกต์ทั้งหมดที่มีแท็ก "SpawnPoint"
//        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

//        float closestDistance = Mathf.Infinity;
//        GameObject nearestSpawnPoint = null;

//        // วนลูปหาจุดเกิดที่ใกล้ที่สุด
//        foreach (GameObject spawnPoint in spawnPoints)
//        {
//            float distance = Vector3.Distance(transform.position, spawnPoint.transform.position);

//            if (distance < closestDistance)
//            {
//                closestDistance = distance;
//                nearestSpawnPoint = spawnPoint;
//            }
//        }

//        // ถ้าพบจุดเกิดที่ใกล้ที่สุด กำหนดค่า spawnPoint ใหม่
//        if (nearestSpawnPoint != null)
//        {
//            spawnPoint = nearestSpawnPoint.transform;
//        }
//    }

//    private void Respawn()
//    {

//        gameOverScreen.SetActive(false);
//        gameObject.SetActive(true); // เปิดการใช้งานผู้เล่นอีกครั้ง

//        transform.position = spawnPoint.position; // ย้ายผู้เล่นไปยังจุดเกิดใหม่ที่ใกล้ที่สุด
//        HpValue = NumberHp; // รีเซ็ตค่า Hp ของผู้เล่น
//        UpdateHpUI(); // อัปเดต UI ของค่า Hp
//    }

}
