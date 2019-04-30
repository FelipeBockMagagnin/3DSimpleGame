using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed);
        Destroy(this.gameObject, 10f);
    }
}
