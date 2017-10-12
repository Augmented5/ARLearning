using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changesettopbox : MonoBehaviour {

	public Sprite[] s1;
	public Button b1;
	public Image i1;
	public Animation anime0;
	public Animation anime1;       //coax cable
	public Animation anime2;       //power cable
	public Animation anime3;       //rca cable
	public Animation anime4;       //hdmi cable
	static int count=0;            // for image sprite loading
	public Button nextButton;
	public Button previousButton;
	public Button btn;
	public Button btn1;
	public GameObject coax ;
	public GameObject hdmi ;
	public GameObject power ;
	public GameObject rca ;
	public GameObject tv ;
	public GameObject stb ;
	public GameObject tvfurniture ;
	public GameObject smalltv ;
	public GameObject girl ;
	public GameObject smallfurniture ;
	void Awake () {
		btn = nextButton.GetComponent<Button>();
		btn1 = previousButton.GetComponent<Button>();
		s1=Resources.LoadAll<Sprite>("SettopboxAllSteps");
		anime0 = GetComponent<Animation>();
		anime0.Stop();
		anime1 = GetComponent<Animation>();
		//anime1.Stop();
		anime2 = GetComponent<Animation>();
		anime2.Stop();
		anime3 = GetComponent<Animation>();
		anime3.Stop();
		anime4 = GetComponent<Animation>();
		anime4.Stop();
		coax = Instantiate(Resources.Load("COAxial", typeof(GameObject))) as GameObject;
		power = Instantiate(Resources.Load("Power", typeof(GameObject))) as GameObject;
		hdmi = Instantiate(Resources.Load("HDMI", typeof(GameObject))) as GameObject;
		rca = Instantiate(Resources.Load("RCA Cables", typeof(GameObject))) as GameObject;
	    tv = Instantiate(Resources.Load("TV", typeof(GameObject))) as GameObject;
	    stb = Instantiate(Resources.Load("Tuner", typeof(GameObject))) as GameObject;
		tvfurniture = Instantiate(Resources.Load("TVfurniture", typeof(GameObject))) as GameObject;
		girl= Instantiate(Resources.Load("girl", typeof(GameObject))) as GameObject;
		smallfurniture= Instantiate(Resources.Load("TVfurniture", typeof(GameObject))) as GameObject;
		smalltv= Instantiate(Resources.Load("TV", typeof(GameObject))) as GameObject;
	}
	public void ChangeScene (string a)
	{
		 count=0;
		SceneManager.LoadSceneAsync(a);
	}
	public void On_NextClick_Button () {
		count++;
		if(count>= s1.Length-1)
		{
			btn.interactable  = false;
		}
		if(count>=1)       // function written, as wen i diabled button on above condition and again use prev button and again coming to next then it should enable back the button
		{
			btn1.interactable  = true;
		}
		i1.sprite=s1[count];
		
		switch(count)
		{
			case 0:	{ 
			         
					 anime1.Play();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 
					 break;
	        		}
			case 1: {
					power.SetActive (true); 
					anime1.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime2.Play(); break;
					 }
			case 2: {
					power.SetActive (true);
					rca.SetActive (true);
				     anime1.Stop();
					 anime2.Rewind();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Play();
					  break;
					}
			case 3: {
				    power.SetActive (true);
					rca.SetActive (true);
					hdmi.SetActive (true);
				     anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play(); break;
					}
			case 4: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 coax.SetActive (false);         // setting models disable in last task
					 hdmi.SetActive (false); 
					 power.SetActive (false);
					 rca.SetActive (false); 
					 stb.SetActive(false);
					 tv.SetActive (true); 
					 tvfurniture.SetActive(true);
					 break;
				    }
			case 5: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 coax.SetActive (false);         // setting models disable in last task
					 hdmi.SetActive (false); 
					 power.SetActive (false);
					 rca.SetActive (false); 
					 stb.SetActive(false);
					 tv.SetActive (false); 
					 tvfurniture.SetActive(false);
					 girl.SetActive(true);
					 smalltv.SetActive (true); 
					 smallfurniture.SetActive(true);
					 break;
				    }
		}
	}
	public void On_PrevClick_Button () {
		if(count>=1){
		count--;
		}
		if(count<1)
		{
			btn1.interactable = false;
		}
		if(count <=s1.Length-2)       // for making next button again enable when we go back from disable to prev state hence we need to make next button enable again
		{ 
			btn.interactable  = true;
		}
		i1.sprite=s1[count];
		
		switch(count)
		{
			
			case 0:	{ 
					coax.SetActive(true);
					anime1.Play();
					power.SetActive (false);
                   	 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 	
					 break;
	        		}
			case 1: {
					 power.SetActive (true);
					 rca.SetActive (false);
					 hdmi.SetActive (false);
				     anime1.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime2.Play(); break;
					 }
			case 2: {
					power.SetActive (true);
					rca.SetActive (true);
					hdmi.SetActive (false);
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Play();
					  break;
					}
			case 3: {
				   	 coax.SetActive (true); 
					 hdmi.SetActive (true); 
					 power.SetActive (true);
					 rca.SetActive (true);
					 stb.SetActive (true);
					 tv.SetActive(false);
					 tvfurniture.SetActive(false);
					 anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play(); 
					 break;
					}
			case 4: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 tv.SetActive (true); 
					 tvfurniture.SetActive(true);
					 girl.SetActive(false);
					 smalltv.SetActive (false); 
					 smallfurniture.SetActive(false);
					 break;
			        }
			case 5: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 tv.SetActive (false); 
					 tvfurniture.SetActive(false);
					 girl.SetActive(true);
					 smalltv.SetActive (true); 
					 smallfurniture.SetActive(true);
					 break;
				    }
		}
	}
	
}
