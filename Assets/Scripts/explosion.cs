using UnityEngine;

public class explosion : MonoBehaviour
{
    [SerializeField] private float dmg= 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player player = collision.GetComponent<player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.takedmg(dmg);

        }
        if (collision.CompareTag("enemy"))
        { 
            enemy.TakeDmg(dmg);
        }
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
