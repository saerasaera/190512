using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad  : MonoBehaviour {

	public void SceneStart(String scene)
	{
		SceneManager.LoadScene(scene);
	}
}
