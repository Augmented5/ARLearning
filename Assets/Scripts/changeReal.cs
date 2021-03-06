﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class changeReal : MonoBehaviour {

	public Sprite[] s1;
	public Button b1;
	public Image i1;
	public Animation anime0;
	public Animation anime1;
	public Animation anime2;
	public Animation anime4;
	static int count=0;
	public Button nextButton;
	public Button previousButton;
	public Button btn;
	public Button btn1;
	public Text prevShow;
	public Text nextShow;
	public GameObject ethernet ;
	public GameObject dsl ;
	public GameObject power ;
	public GameObject computer ;
	public GameObject virtualRouter ;
	void Awake () {
		btn = nextButton.GetComponent<Button>();
		btn1 = previousButton.GetComponent<Button>();
		s1=Resources.LoadAll<Sprite>("RealRouter");
		anime0 = GetComponent<Animation>();
		anime0.Stop();
		anime1 = GetComponent<Animation>();
		anime1.Stop();
		anime2 = GetComponent<Animation>();
		anime2.Stop();
		anime4 = GetComponent<Animation>();
		anime4.Stop();
		ethernet = Instantiate(Resources.Load("ethernet_assem(Step_ap214)", typeof(GameObject))) as GameObject;
		power = Instantiate(Resources.Load("Power", typeof(GameObject))) as GameObject;
		dsl = Instantiate(Resources.Load("2377477_2213145-2", typeof(GameObject))) as GameObject;
		computer=Instantiate(Resources.Load("computer", typeof(GameObject))) as GameObject;
		virtualRouter=Instantiate(Resources.Load("RouterNew", typeof(GameObject))) as GameObject;
	}
	public void ChangeScene (string a)
	{
		count=0;
		Application.LoadLevel (a);
	}
	public void On_NextClick_Button () {
		count++;
		if(count>= s1.Length-1)
		{
			btn.interactable  = false;    //next button 
		}
		if(count>=1)       // function written, as wen i diabled button on above condition and again use prev button and again coming to next then it should enable back the button
		{
			btn1.interactable  = true;
		}
		
		i1.sprite=s1[count];
		
		switch(count)
		{
			case 0: {
					prevShow.GetComponent<Text>().enabled = false;
					 anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 break;
					}
			case 1:	{   
					 prevShow.GetComponent<Text>().enabled = true;
					 anime2.Stop();
					 anime4.Stop();
					 anime1.Play();
					 virtualRouter.SetActive(false);
					 ethernet.SetActive (false);         // setting models enable
					 dsl.SetActive (true); 
					 power.SetActive (false);
					 break;
	        		}
			case 2: {
				     anime1.Stop();
					 anime4.Stop();
					 anime2.Play();
					 virtualRouter.SetActive(false);
					 ethernet.SetActive (false);         // setting models enable
					 dsl.SetActive (false); 
					 power.SetActive (true);
					 break;
					 }
			case 3: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Play();
					  virtualRouter.SetActive(false);
					 ethernet.SetActive (true);         // setting models enable
					 dsl.SetActive (false); 
					 power.SetActive (false);
					 computer.SetActive (false); 
					 nextShow.GetComponent<Text>().enabled = true;
					 break;
					}
			case 4: {
					nextShow.GetComponent<Text>().enabled = false;
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 virtualRouter.SetActive(false);
					 ethernet.SetActive (false);
					 computer.SetActive (true); 
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
			case 0: {
					prevShow.GetComponent<Text>().enabled = false;
					 anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					  virtualRouter.SetActive(true);
					 ethernet.SetActive (false);         // setting models enable
					 dsl.SetActive (false); 
					 power.SetActive (false);
					 break;
					}
			case 1:	{
					prevShow.GetComponent<Text>().enabled = true;  
					 anime2.Stop();
					 anime4.Stop();
					 anime1.Play();
					  virtualRouter.SetActive(false);
					 ethernet.SetActive (false);         // setting models enable
					 dsl.SetActive (true); 
					 power.SetActive (false);
					 break;
	        		}
			case 2: {
				     anime1.Stop();
					 anime4.Stop();
					 anime2.Play();
					  virtualRouter.SetActive(false);
					 ethernet.SetActive (false);         // setting models enable
					 dsl.SetActive (false); 
					 power.SetActive (true);
					 break;
					 }
			case 3: {
					nextShow.GetComponent<Text>().enabled = true;
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Play();
					 ethernet.SetActive (true);         // setting models enable
					 dsl.SetActive (false); 
					 power.SetActive (false);
					 computer.SetActive (false); 	
				     virtualRouter.SetActive(false);
					 break;
					}
			case 4: {
				     anime1.Stop();
					 anime2.Stop();
					 anime4.Stop();
					 ethernet.SetActive (false);
					 computer.SetActive (true); 
					  virtualRouter.SetActive(false);
					 nextShow.GetComponent<Text>().enabled = false;
					
					 break;
				    }
			
		}
	}
	
}
