using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;

	void Update()
    {
        transform.position = player.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
