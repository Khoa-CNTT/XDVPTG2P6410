using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManage gameManage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {

            player player= GetComponent<player>();
            player.takedmg(10f);
        }
        else if (collision.CompareTag("USB"))
        {
            Debug.Log("You Win");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("energry"))
        {
            gameManage.addEnergry();
            Destroy(collision.gameObject);  
        }

    }
}

