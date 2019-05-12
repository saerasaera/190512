using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour {

	public void ChangeColorOfGameObject(GameObject targetObject, Color color)
	{
  	foreach(Renderer targetRenderer in targetObject.GetComponents<Renderer>())
		{
    	foreach(Material material in targetRenderer.materials)
			{
      	material.color = color;
    	}
  	}
  	for(int i = 0; i < targetObject.transform.childCount; i++)
		{
    ChangeColorOfGameObject (targetObject.transform.GetChild(i).gameObject, color);
  	}
	}

	private void ReplaceMaterial(GameObject targetObject, Material mat)
	{
		targetObject.GetComponent<Renderer>().material = mat;
	}
}
