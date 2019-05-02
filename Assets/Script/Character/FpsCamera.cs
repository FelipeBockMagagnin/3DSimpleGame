using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCamera : MonoBehaviour {

	public GameObject player;           //player game object
	private Vector2 offset;             //offset of camera in the current frame
	private Vector2 look;               //where camera is looking
	public float sensitivity;           //mouse sensitivity

	private void Awake()
	{
		Screen.lockCursor = true;
	}

	private void Update()
	{
		offset = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		offset.Scale(new Vector2(sensitivity,sensitivity));
		look += offset;
		transform.localRotation = Quaternion.AngleAxis(-look.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(look.x, player.transform.up); 

		if(Input.GetButtonDown("Cancel"))
		{
			Screen.lockCursor = false;
		}
	}
}
