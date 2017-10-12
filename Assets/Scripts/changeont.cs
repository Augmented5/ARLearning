using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeont : MonoBehaviour {

	public Sprite[] s1;
	public Image i1;
	public Animation anime0;
	public Animation anime1;       //coax cable
	public Animation anime2;       //power cable
	public Animation anime3;       //battery cable
	public Animation anime4;       //optical cable
	static int count=0;            // for image sprite loading
	public Button nextButton;
	public Button previousButton;
	public Button btn;
	public Button btn1;
	public GameObject coax ;
	public GameObject power ;
	public GameObject battery ;
	public GameObject optical ;
	public GameObject ont ;
	public GameObject bluehouse ;
	public GameObject redhouse ;
	public GameObject lego ;
	public GameObject modem;
	void Awake () {
		btn = nextButton.GetComponent<Button>();
		btn1 = previousButton.GetComponent<Button>();
		s1=Resources.LoadAll<Sprite>("ontAllSteps");
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
		coax = Instantiate(Resources.Load("Coax", typeof(GameObject))) as GameObject;
		power = Instantiate(Resources.Load("Power", typeof(GameObject))) as GameObject;
	    battery = Instantiate(Resources.Load("batterycable", typeof(GameObject))) as GameObject;     
		optical = Instantiate(Resources.Load("optical", typeof(GameObject))) as GameObject;
	    ont = Instantiate(Resources.Load("Ont", typeof(GameObject))) as GameObject;
	    bluehouse = Instantiate(Resources.Load("bluehouse", typeof(GameObject))) as GameObject;
		redhouse = Instantiate(Resources.Load("redhouse", typeof(GameObject))) as GameObject;
		lego=Instantiate(Resources.Load("lego", typeof(GameObject))) as GameObject;
		modem=Instantiate(Resources.Load("Modem", typeof(GameObject))) as GameObject;
	}
	public void ChangeScene (string a)
	{ 
	    count=0;
		SceneManager.LoadSceneAsync(a);
		
	}
	public void On_NextClick_Button () {
		Debug.Log("pressed");
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
					 bluehouse.SetActive (true); 
					 redhouse .SetActive(true);
			         anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 
					 break;
	        		}
			case 1: {
				     bluehouse.SetActive (false); 
					 redhouse .SetActive(false);
				     ont.SetActive(true);
					 coax.SetActive (true); 
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime1.Play(); break;
					 }
			case 2: {
				     ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (true);
					 anime1.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime2.Play();
					  break;
					}
			case 3: {
					 ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (true);
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Play(); break;
					}
			case 4: {
					 ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (false);
					 optical.SetActive(true);
				     anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play();
					 break;
					   }
			case 5: {
					 ont.SetActive(false);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (false);
					 optical.SetActive(false);
					 lego.SetActive(true);
					 modem.SetActive(true);
				     anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play();
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
					 bluehouse.SetActive (true); 
					 redhouse .SetActive(true);
					 ont.SetActive(false);
					 coax.SetActive (false); 
					 optical.SetActive(false);
					 battery.SetActive (false);
					 power.SetActive (false);
					 anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Stop();
					 	
					 break;
	        		}
			case 1: {
					 bluehouse.SetActive (false); 
					 redhouse .SetActive(false);
					 ont.SetActive(true);
					 coax.SetActive (true); 
					 optical.SetActive(false);
					 battery.SetActive (false);
					 power.SetActive (false);
				     anime2.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime1.Play();  break;
					 }
			case 2: {
					 ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (true);
					 battery.SetActive (false);
					 optical.SetActive (false);
				     anime1.Stop();
					 anime3.Stop();
					 anime4.Stop();
					 anime2.Play();
					  break;
					}
			case 3: {
				     ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (true);
					 optical.SetActive(false);
					 anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 anime3.Play();
					 break;
					}
			case 4: {
				     ont.SetActive(true);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (false);
					 optical.SetActive(true);
					 lego.SetActive(false);
					 modem.SetActive(false);
				     anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play();
					 break;
				    }
			case 5: {
					 ont.SetActive(false);
					 coax.SetActive (false); 
					 power.SetActive (false);
				     battery.SetActive (false);
					 optical.SetActive(false);
					 lego.SetActive(true);
					 modem.SetActive(true);
				     anime1.Stop();
					 anime2.Stop();
					 anime3.Stop();
					 anime4.Play();
					 break;
							    }
		}
	}
	
}
