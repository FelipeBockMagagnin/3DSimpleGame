using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPos;

    void Update ()
    {
        if(PlayerStats.life <= 0)
        {
            Debug.Log("Game Over, life: " + PlayerStats.life);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (PlayerStats.ammo > 0)
            {
                Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
                PlayerStats.ammo--;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shoot"))
        {
            PlayerStats.DoDamage(5);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("LifeItem"))
        {
            PlayerStats.Heal(10);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("AmmoItem"))
        {
            PlayerStats.PickAmmo(5);
            Destroy(other.gameObject);
        }
    }
}
