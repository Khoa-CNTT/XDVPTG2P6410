using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] private float movespeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float maxhp = 100f;
    private float currenthp;
    [SerializeField] private UnityEngine.UI.Image HPBar;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        currenthp = maxhp;
        updatehpbar();  
    }
    

    void Update()
    {
        moveplayer();
        
    }
    void moveplayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.linearVelocity = playerInput.normalized * movespeed;
        if (playerInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }
    public void takedmg(float dmg)
    {
        currenthp -= dmg;
        currenthp = Mathf.Max(currenthp, 0);
        if(currenthp <= 0)
        {
            die();
        }
        updatehpbar();
    }
    public void heal(float healval)
    {
        if (currenthp < maxhp)
        {
            currenthp += healval;
            currenthp = Mathf.Min(currenthp, maxhp);
            updatehpbar();
        }
    }
    private void die()
    {
        Destroy(gameObject);
    }
    protected void updatehpbar()
    {
        if (HPBar != null)
        {
            HPBar.fillAmount = currenthp / maxhp;
        }
    }

    
}
