using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject target;		// staring target
	public double radians;
	public double theta;

	// Use this for initialization
	void Start() {
		target = GameObject.Find("BlockPool/Plane");
	}
	
	// Update is called once per frame
	void Update() {
		Vector3 poolPos = target.transform.position;
		poolPos = new Vector3(poolPos.x, poolPos.y + 5, poolPos.z);
		transform.LookAt(poolPos);
	}

	public void RotateCam(int direct) {
		transform.RotateAround( target.transform.position, Vector3.up, direct * 45 * Time.deltaTime );
	}

	public double WatchingDirection() {
		radians = Mathf.Atan2(transform.position.y, transform.position.x);
		theta = radians * Mathf.Rad2Deg;
		Debug.Log(theta);
		return theta;
	}
}
