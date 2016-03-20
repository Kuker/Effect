using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    public float smoothing = 5.0f;
    Vector3 offset;




	// Use this for initialization
	void Start () {
        offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 playerCamPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerCamPos, smoothing * Time.deltaTime);
	}
}
