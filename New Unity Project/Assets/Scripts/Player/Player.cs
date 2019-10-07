using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
   // public event Action<Player> onPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void CollidedWithEnemy(ENEMY enemy)
    {
        enemy.Attack(this);
        if(health<=0)
        {
          //  onPlayerDeath(this);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        ENEMY enemy = col.collider.gameObject.GetComponent<ENEMY>();
        if(enemy)
        {
            CollidedWithEnemy(enemy);
        }
        
    }
}
