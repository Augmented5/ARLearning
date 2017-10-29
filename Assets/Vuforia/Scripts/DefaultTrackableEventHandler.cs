/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class DefaultTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;
		public static string aaa="";  //Power found
		public static string a1a1a1=""; //Router found
		public static string bbb="";  //power Lost
		public static string b1b1b1=""; //Router lost
		public static int foundflag=0;
		public static int ff=0;
		public static  int lostflag=0;
		public static int lf=0;
		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{	

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				if(mTrackableBehaviour.TrackableName=="fevistick"){
						foundflag=1;
						lostflag=0; 
				}
				if(mTrackableBehaviour.TrackableName=="TrackRouter1"){
					ff=0;  lf=1;
				}
				OnTrackingFound();
			}
			else
			{   
				if(mTrackableBehaviour.TrackableName!="fevistick"){
					foundflag=0;
					lostflag=1;
				}
				if(mTrackableBehaviour.TrackableName!="TrackRouter1"){
					ff=1;
					lf=0;
				}

				OnTrackingLost();
			}
		}

		#endregion // PUBLIC_METHODS



		#region PRIVATE_METHODS


		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			if(mTrackableBehaviour.TrackableName=="fevistick"){
				aaa=mTrackableBehaviour.TrackableName;
			}
			if(mTrackableBehaviour.TrackableName=="TrackRouter1"){
				a1a1a1=mTrackableBehaviour.TrackableName;
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}


		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
			if(mTrackableBehaviour.TrackableName=="fevistick"){
				bbb=mTrackableBehaviour.TrackableName;
			}
			if(mTrackableBehaviour.TrackableName=="TrackRouter1"){
				b1b1b1=mTrackableBehaviour.TrackableName;
			}
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

		#endregion // PRIVATE_METHODS
	}
}
