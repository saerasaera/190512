using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Invader : MonoBehaviour {

	GameController gameController;
	Score score;

	int life;
	public float invaderX = 3f;  //インベーダーの移動量
	public float limitInvederX = 30F;
	public int invaderD = 1; //インベーダーの移動方向
	public static float timeOut = 0.5f; //インベーダーの移動タイミングを制御
  public float timeElapsed;  //カウンタ
	private int moveMax = 9; //同方向への最大移動回数
	private int moveCount = 0;//移動回数カウンタ

	void Start()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		score = GameObject.Find("Score").GetComponent<Score>();
		GetComponent<Collider>().isTrigger = true;
		life = 1;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Missile")
		{
			life--;
			if(life < 1)
			{
				gameController.DestroyInvader();
				score.AddScore(1);
				Destroy(gameObject);
			}
		}
		if(other.gameObject.tag == "Border")
		{
			SceneManager.LoadScene("result");
		}
	}

	void Update()
	{
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= timeOut)
		{
			Vector3 pos = transform.localPosition;
			moveCount += 1;
			if(moveCount >= moveMax && invaderD == 1) //右端到達時
			{
				pos.y -= 5f;
				if(pos.y < -15)
				{
					SceneManager.LoadScene("gameover");
				}
				moveCount = 0;
				//pos.x = limitInvederX;
				invaderD = -invaderD; //進行方向を変更
				transform.localPosition = pos;
			}
			else if(moveCount >= moveMax && invaderD == -1)  //左端到達時
			{
				pos.y -= 5f;
				if(pos.y < -15)
				{
					SceneManager.LoadScene("gameover");
				}
				moveCount = 0;
				//pos.x = -limitInvederX;
				invaderD = -invaderD; //進行方向を変更
				transform.localPosition = pos;
			}
			else
			{
				pos.x += invaderX *invaderD;
				transform.localPosition = pos;
			}
			timeElapsed = 0f;
		}
	}

}
