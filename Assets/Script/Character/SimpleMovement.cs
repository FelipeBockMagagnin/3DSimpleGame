using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    #region "Variables"
    public Rigidbody Rigid;
    public float MouseSensitivity;
    public float MoveSpeed;
    public float JumpForce;
    public GameObject bullet;
    #endregion
   
    void Update ()
    {
        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        if (Input.GetKeyDown("space"))
            Rigid.AddForce(transform.up * JumpForce);


        if(PlayerStats.life <= 0)
        {
            Debug.Log("Game Over, life: " + PlayerStats.life);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fired");
            Instantiate(bullet, transform.position, this.transform.rotation);
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
