using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	public float rateY = 12f;
	public float limitY = 20f;

	void Update ()
	{
		Vector3 pos = transform.localPosition;
		pos.y += rateY * Time.deltaTime;
		if(pos.y > limitY)
		{
			Destroy(gameObject);
		}
		else
		{
			transform.localPosition = pos;
		}
	}
	void OnTriggerEnter(Collider other)   //衝突したら消す
	{
	Destroy(gameObject);
	}
}
