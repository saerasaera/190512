using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	ChangeColor changeColor;

	//public GameObject invader; //生成するインベーダーを設定
	int lastInvader;
	public int invaderNumX;  //1列内のインベーダーの数
	public int invaderNumY;  ////インベーダーの列数

	Color[] collors = new Color[] {Color.blue, Color.red, Color.yellow}; //インベーダーの色
	public GameObject[] invader = new GameObject[3];

	void Start()
	{
		changeColor = GameObject.Find("GameController").GetComponent<ChangeColor>();
		StartGame();
	}

	void StartGame()
	{
		for(int j = 0; j < invaderNumY; j++)
		{
			for(int i = 0; i < invaderNumX; i++)
			{
				Vector3 pos = new Vector3( -36f + i * 6f, 15f - j * 5f, 0);
				GameObject gameObject = Instantiate(invader[j], pos, Quaternion.identity);
				//changeColor.ChangeColorOfGameObject(gameObject, collors[j]);
			}
		}
		lastInvader = invaderNumX * invaderNumY;
	}

	public void DestroyInvader()
	{
		lastInvader--;
		if(lastInvader == 1)
		{
			Invader.timeOut = Invader.timeOut / 4;
		}
		if(lastInvader == 0)
		{
			Invader.timeOut = Invader.timeOut * 4;
			SceneManager.LoadScene("result");
		}
	}
}
