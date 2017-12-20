using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyAR;

public class EasyARTargetManager : ImageTargetBehaviour
{
	public bool isDeveloperMode = false;

	protected override void Awake()
	{
		if (!isDeveloperMode)
		{
			base.Awake();
			TargetFound += OnTargetFound;
			TargetLost += OnTargetLost;
			TargetLoad += OnTargetLoad;
			TargetUnload += OnTargetUnload;
		} else {
			Time.timeScale = 1f;
		}
	}

	void OnTargetFound(TargetAbstractBehaviour obj)
	{
		if (SceneGUI.ILayer < 1)
		{
			SceneGUI.HideMessage();
			Time.timeScale = 1f;
			//Debug.Log("Found: " + Target.Id);
		}
	}
	void OnTargetLost(TargetAbstractBehaviour behaviour)
	{
		if (SceneGUI.ILayer < 1)
		{
			SceneGUI.ShowMessage("Find image");
			Time.timeScale = 0f;
			//Debug.Log("Lost: " + Target.Id);
		}
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