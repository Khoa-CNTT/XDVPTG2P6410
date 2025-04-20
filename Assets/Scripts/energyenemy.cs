using UnityEngine;

public class energyenemy : Enemy
{
    [SerializeField] private GameObject energryObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player !=null)
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
        if(energryObject != null)
        {
            GameObject energry=Instantiate(energryObject, transform.position, Quaternion.identity);
            Destroy(energry, 5f);
        }

        base.die();
    }
}

