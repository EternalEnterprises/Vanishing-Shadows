using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float cameraDistX;
	public float cameraDistY;
	private Camera mainCamera;
	public GameObject player;

	void Start(){
		mainCamera = GetComponent<Camera> ();
	}

	void Update(){
		Vector3 playerInfo = player.transform.transform.position;
		mainCamera.transform.position = new Vector3(playerInfo.x , playerInfo.y - cameraDistY, playerInfo.z - cameraDistX);
	}
}
