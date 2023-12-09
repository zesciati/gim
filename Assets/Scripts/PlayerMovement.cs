using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   // only this script can access this variable and make changes to it not other scripts
    private Rigidbody2D rb;

    private BoxCollider2D coll;

    // mengakses tab Animator di unity
    private Animator anim;

    // mengakses Sprite Renderer 
    private SpriteRenderer sprite;

    // berhubungan dengan IsGrounded (line 101)
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;

    // menampilkan di script di panel inspector
    [SerializeField] private float moveSpeed = 7f;   
    [SerializeField] private float jumpforce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //support joystick 
        // arah kiri dan kanan diambil dari Edit -> Project Settings -> Input Manager -> Horizontal
        // GetAxisRaw digunakan untuk karakter berhenti ketika kita melepaskan tombol 
        // if dirX adalah 0 maka tidak bergerak
         dirX = Input.GetAxisRaw("Horizontal");
                                                   //z
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        // Menggunakan space bar untuk lompat
        // GetButtonDown("Jump") diambil dari Edit -> Project Settings -> Input Manager -> Jump
        // IsGrounded digunakan ketika player hanya boleh melompat setelah mengenai tanah
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // audio lompat
            jumpSoundEffect.Play();                       
                                        //X             Y                          
            rb.velocity = new Vector3(rb.velocity.x, jumpforce); 
        }

        UpdateAnimationState();
    }

    // void hanya eksekusi kode dan selesai,tidak return result
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        // running di ambil dari tab Animator -> parameter
        {
            // menunjukkan bahwa kita lari, arah ke kanan
            state = MovementState.running;
            // mengakses flip di Sprite Renderer untuk animasi ke arah kiri di cancel
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            // lari arah ke kiri
            state = MovementState.running;

            // mengakses flip di Sprite Renderer untuk animasi ke arah kiri
            sprite.flipX = true;
        }
        else
        {
            // animasi berhenti berlari
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Mengacu kepada panel Animator (Animator -> parameters)
        anim.SetInteger("state", (int)state);
    }

    // Menentukan bahwa pemain hanya bisa lompat lagi setelah mengenai tanah
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
