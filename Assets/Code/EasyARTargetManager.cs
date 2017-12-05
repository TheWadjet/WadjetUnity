using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAR;

public class EasyARTargetManager : ImageTargetBehaviour
{
	protected override void Awake()
	{
		base.Awake();
		TargetFound += OnTargetFound;
		TargetLost += OnTargetLost;
		TargetLoad += OnTargetLoad;
		TargetUnload += OnTargetUnload;
	}

	void OnTargetFound(TargetAbstractBehaviour obj)
	{
		SceneGUI.HideMessage();
		Time.timeScale = 1f;
		//Debug.Log("Found: " + Target.Id);
	}
	void OnTargetLost(TargetAbstractBehaviour behaviour)
	{
		SceneGUI.ShowMessage("Find image");
		Time.timeScale = 0f;
		//Debug.Log("Lost: " + Target.Id);
	}
	void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
	{
		SceneGUI.ShowMessage("Find image");
		//Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
	}
	void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
	{
		//Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
	}
}