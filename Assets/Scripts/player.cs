using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        moveplayer();
    }
    void moveplayer()
    {
        Vector2 playerinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerinput.normalized * movespeed;
        if(playerinput.x < 0)
        {
            sr.flipX= true;
        }
        else if (playerinput.x > 0)
        {
            sr.flipX = false;
        }
        if(playerinput != Vector2.zero)
        {
            animator.SetBool("isrunning", true);

        }
        else
        {
            animator.SetBool("isrunning", false);
        }
    }

}
