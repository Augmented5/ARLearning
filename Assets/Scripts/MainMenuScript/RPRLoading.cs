using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class RPRLoading : MonoBehaviour {
	public Transform loadingBar;
	public Transform textIndicator;
	public Transform textLoading;
	public GameObject loadingscreen;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;
	Loading123 a=new Loading123();
	public void LoadLevel(int sceneIndex)
	{
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}
	
	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		loadingscreen.SetActive(true);
		while(!operation.isDone)
		{
			a.UpdateLoadingScreen();
			
			yield return null;
			
		}
	}
	
	public void CloseAppButton ()
	{
		Application.Quit ();
	}
}


	