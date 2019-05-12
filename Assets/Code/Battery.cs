using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	public float rateX = 11f;   //1秒間に移動する量
	public float minX = -31f;   //移動範囲
	public float maxX = 31f;    //移動範囲
	public float reload = 0f;    //連射制御用のパラメータ
	public int rapidFire;  //連射のOn/Offフラグ
	public GameObject battery;
	public Transform missile;

	void Start()
	{
		battery = GameObject.Find("Battery");
		battery.GetComponent<Renderer>().material.color = Color.blue;
	}

	void Update ()
	{
		float incX = 0;
		reload += 2f * Time.deltaTime;

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			incX -= rateX * Time.deltaTime;   //左方向に移動
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			incX += rateX * Time.deltaTime;   //右方向に移動
		}
		if(reload > 0.5 && rapidFire == 1) //自動発射
		{
			Instantiate(missile, transform.localPosition, Quaternion.identity);
			reload = 0;
		}

		Vector3 pos = transform.localPosition;
		pos.x = Mathf.Clamp(pos.x + incX, minX, maxX);
		transform.localPosition = pos;

		if(Input.GetKeyDown(KeyCode.Space))  //ミサイル発射
		{
			if(reload > 1 && rapidFire == 0)
			{
				Instantiate(missile, transform.localPosition, Quaternion.identity);
				reload = 0;
		  }
		}
	}
}
