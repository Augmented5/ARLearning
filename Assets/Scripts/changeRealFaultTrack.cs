using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Vuforia;

public class changeRealFaultTrack : MonoBehaviour {

	public Sprite[] s1;
	public Button b1;
	public UnityEngine.UI.Image i1;
	public Animation anime0;
	public Animation anime2;
	static int count=0;
	public Button nextButton;
	public Button previousButton;
	public Button btn;
	public Button btn1;
	public Text prevShow;
	public Text nextShow;
	public GameObject power ;
	public GameObject cross ;
	public GameObject right ;
	private DefaultTrackableEventHandler myObjext ;
	public string trackableName="TrackRouter1";
	public string trackableName1="fevistick";
	private string abc="";
	private string def="";
	private string a1b1c1="";
	private string d1e1f1="";
	public int z;
	public int y;
	public int z1;
	public int y1;


	public void ChangeScene (string a)
	{
		count=0;
		Application.LoadLevel (a);
	}

	void Awake () {
		btn = nextButton.GetComponent<Button>();
		btn1 = previousButton.GetComponent<Button>();
		s1=Resources.LoadAll<Sprite>("faulttolerance");
		anime0 = GetComponent<Animation>();
		anime0.Stop();
		anime2 = GetComponent<Animation>();
		anime2.Stop();
		power = Instantiate(Resources.Load("Power", typeof(GameObject))) as GameObject;
		cross = Instantiate(Resources.Load("cross", typeof(GameObject))) as GameObject;
		right =Instantiate(Resources.Load("Android_LowPoly", typeof(GameObject))) as GameObject;
		z=Vuforia.DefaultTrackableEventHandler.foundflag;
		y=Vuforia.DefaultTrackableEventHandler.lostflag;
		z1=Vuforia.DefaultTrackableEventHandler.ff;
		y1=Vuforia.DefaultTrackableEventHandler.lf;
		abc=Vuforia.DefaultTrackableEventHandler.aaa;
		def=Vuforia.DefaultTrackableEventHandler.bbb;
		a1b1c1=Vuforia.DefaultTrackableEventHandler.a1a1a1;
		d1e1f1=Vuforia.DefaultTrackableEventHandler.b1b1b1;
	}

	public void Start(){
		myObjext=gameObject.GetComponent<DefaultTrackableEventHandler>();
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
				nextShow.GetComponent<Text>().enabled = true;
				anime2.Stop();
				right.SetActive(false);
				break;
			}
		case 1:	{ 
				z=Vuforia.DefaultTrackableEventHandler.foundflag;
				y=Vuforia.DefaultTrackableEventHandler.lostflag;
				abc=Vuforia.DefaultTrackableEventHandler.aaa;
				def=Vuforia.DefaultTrackableEventHandler.bbb;
				Debug.Log("NextB Case 1-> z:" +z+" y:"+y+"    abc:"+abc+" def:"+def);
				prevShow.GetComponent<Text>().enabled = true;
			//	nextShow.GetComponent<Text>().enabled = false;
				if(def =="fevistick" && (z==0|| y==1))               //No luck
				{	
					nextShow.GetComponent<Text>().enabled = false;
					abc =string.Empty;      //abc ="";
					anime2.Play();
					right.SetActive(false);
					power.SetActive (true);
					cross.SetActive(true);

				}

				if(abc =="fevistick" && (z==1|| y==0))                  //Got luck
				{
					nextShow.GetComponent<Text>().enabled = true;
					def =string.Empty;       //def="";
					anime2.Stop(); 
					right.SetActive(false);
					power.SetActive (false);
					cross.SetActive(false);

				}
				break;
			}
		case 2: {
				z=Vuforia.DefaultTrackableEventHandler.foundflag;
				y=Vuforia.DefaultTrackableEventHandler.lostflag;
				abc=Vuforia.DefaultTrackableEventHandler.aaa;
				def=Vuforia.DefaultTrackableEventHandler.bbb;
				Debug.Log("NextB Case 2-> z:" +z+" y:"+y+"      abc:"+abc+" def:"+def);
				if((z==1 || y==0) && abc == "fevistick"){
					nextShow.GetComponent<Text>().enabled = false;
					prevShow.GetComponent<Text>().enabled = true;
					right.SetActive(true);
					anime2.Stop();
					power.SetActive (false);
					cross.SetActive(false);
				}
				if((z==0 || y==1) && def == "fevistick")				//if(abc !="dsl123go" && (z==0|| y==1))
				{	
					nextShow.GetComponent<Text>().enabled = false;
					prevShow.GetComponent<Text>().enabled = true;
					right.SetActive(false);
					abc =string.Empty; 
					On_PrevClick_Button();
					break;
				}
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
				abc =string.Empty; 
				def= string.Empty;
				z=Vuforia.DefaultTrackableEventHandler.foundflag;
				y=Vuforia.DefaultTrackableEventHandler.lostflag;
				abc=Vuforia.DefaultTrackableEventHandler.aaa;
				def=Vuforia.DefaultTrackableEventHandler.bbb;
				Debug.Log("PrevB Case 0-> z:" +z+" y:"+y+"      abc:"+abc+" def:"+def);
				prevShow.GetComponent<Text>().enabled = false;
				nextShow.GetComponent<Text>().enabled = true;
				anime2.Stop();
				power.SetActive (false);
				cross.SetActive(false);
				right.SetActive(false);
				break;
			}
		case 1:	{
				Debug.Log("PrevB Case 1-> z:" +z+" y:"+y+"      abc:"+abc+" def:"+def);
				def=string.Empty;
				abc=string.Empty;
				z=0;
				y=1;
				z=Vuforia.DefaultTrackableEventHandler.foundflag;
				y=Vuforia.DefaultTrackableEventHandler.lostflag;
				abc=Vuforia.DefaultTrackableEventHandler.aaa;
				def=Vuforia.DefaultTrackableEventHandler.bbb;
				Debug.Log("PrevB Case 1-> z:" +z+" y:"+y+"      abc:"+abc+" def:"+def);
				nextShow.GetComponent<Text>().enabled = true;
				prevShow.GetComponent<Text>().enabled = true;
				if(def =="fevistick" && (z==0|| y==1))                 //if(abc !="dsl123go" && (z==0|| y==1))     //No luck
				{	
					abc =string.Empty;      //abc ="";
					anime2.Play();
					right.SetActive(false);
					power.SetActive (true);
					cross.SetActive(true);
					nextShow.GetComponent<Text>().enabled = false;
				}

				if(abc =="fevistick" && (z==1|| y==0))                  //Got luck
				{
					def =string.Empty;       //def="";
					anime2.Stop(); 
					right.SetActive(false);
					power.SetActive (false);
					cross.SetActive(false);
					nextShow.GetComponent<Text>().enabled = true;
				}
				break;
			}
		
		}
	}

}
