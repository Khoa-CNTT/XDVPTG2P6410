using UnityEngine;

public class healenemy : Enemy
{
    [SerializeField] private float healval= 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takedmg(enterdmg);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takedmg(staydmg);
            }
        }
    }
    protected override void die()
    {
        healplayer();
        base.die();
    }
    private void healplayer()
    {
        if (player != null)
        {
            player.heal(healval);
        }
    }
}

    

