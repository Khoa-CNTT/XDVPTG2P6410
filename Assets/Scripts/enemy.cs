using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.Tilemaps;
using UnityEngine;  
using UnityEngine.UI;   

public abstract class Enemy: MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed=1f;
    protected player player;
    [SerializeField] protected float maxhp = 50f;
    protected float currenthp;
    [SerializeField] private UnityEngine.UI.Image HPBar;
    [SerializeField] protected float enterdmg = 10f;
    [SerializeField] protected float staydmg = 2f;
    protected virtual void Start()
    {
        player = FindAnyObjectByType<player>();
        currenthp = maxhp;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    public virtual void TakeDmg(float dmg)
    {
        currenthp -= dmg;
        currenthp = Mathf.Max(currenthp, 0);
        UpdateHpBar();
        if (currenthp <= 0)
        {
            die();
        }
    }
    protected virtual void die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if (HPBar != null)
        {
            HPBar.fillAmount = currenthp / maxhp;
        }
    }
}


