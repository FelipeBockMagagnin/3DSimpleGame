using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPos;
    public float vel;
    public float jumpForce;
    private Rigidbody rb;
    public bool isGrounded;
    private CapsuleCollider col;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void Update ()
    {
		float move = Input.GetAxis("Vertical") * vel;
        float rotation = Input.GetAxis("Horizontal") * vel;
		move *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if(Input.GetButton("Run"))
        {
            move *= 2;
        }

        transform.Translate(rotation, 0, move);


        if(isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                rb.AddForce(Vector3.up*jumpForce*Time.deltaTime, ForceMode.Impulse);
            }
        }       

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

        isGrounded = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayer);
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
