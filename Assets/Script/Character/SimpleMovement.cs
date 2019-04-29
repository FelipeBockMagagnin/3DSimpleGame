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
            Debug.Log("Fired");
            Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shoot"))
        {
            PlayerStats.DoDamage(5);
            Destroy(other.gameObject);
        }
    }
}
