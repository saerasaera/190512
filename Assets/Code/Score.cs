using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int score; //撃破数

    void Update ()
    {
      scoreText.text = score.ToString ();
    }

    public void AddScore (int point)  //撃破数追加
    {
      score = score + point;
    }
}
