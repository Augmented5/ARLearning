using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class Loading123 : MonoBehaviour {
	public Transform loadingBar;
	public Transform textIndicator;
	public Transform textLoading;
	[SerializeField] private float currentAmount;
	[SerializeField] private float speed;
    public void UpdateLoadingScreen () {
		if(currentAmount<100){
			currentAmount += speed * Time.deltaTime;
			textIndicator.GetComponent<Text>().text =((int)currentAmount).ToString()+"%";
			textLoading.gameObject.SetActive(true);
		}
		else{
			textLoading.gameObject.SetActive(false);
			textIndicator.GetComponent<Text>().text="DONE!";
		}
		loadingBar.GetComponent<Image>().fillAmount=currentAmount/100;
	}
	
}


	