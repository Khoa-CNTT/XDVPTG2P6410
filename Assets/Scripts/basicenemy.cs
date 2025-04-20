using UnityEngine;

public class basicenemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player != null)
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
}
