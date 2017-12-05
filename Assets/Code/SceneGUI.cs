using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGUI : MonoBehaviour
{
	MainTower mainTower;

	static bool isMsg = false;
	static string msgText = "";
	static float lastTimeMsg = 0f;
	static float durationMsg = 0f;

	static int iLayer = 0;

	Rect rectMsg = new Rect(0,0,400,200);
	Rect rectMsgText = new Rect(0, 0, 350, 150);

	private void Start()
	{
		mainTower = GameObject.Find("MainTower").GetComponent<MainTower>();
		rectMsg = CenterRect(rectMsg);
		rectMsgText = CenterRect(rectMsgText);
	} 

	private void OnGUI()
	{
		GUILayout.Label("HP: " + mainTower.HP);
		if (isMsg && lastTimeMsg + durationMsg > Time.time)
		{
			GUI.Box(rectMsg, "");
			GUI.Label(rectMsgText, msgText);
		}
		if (iLayer == 0)
		{
			
		}
	}

	private Rect CenterRect(Rect rect)
	{
		return new Rect(Screen.width / 2f - rect.width / 2f, Screen.height / 2f - rect.height / 2f, rect.width, rect.height);
	}

	private Rect[] CenterRect(Rect[] rects)
	{
		float heightElms = 0f;
		for (int i = 0; i < rects.Length; i++)
		{
			heightElms += rects[i].height;
		}
		float curPosX = 0;
		for (int i = 0; i < rects.Length; i++)
		{
			float marginBottom = rects[i].height * 0.6f;
			rects[i] = new Rect(
				Screen.width / 2f - rects[i].width / 2f,
				Screen.height / 2f - heightElms / 2f + curPosX,
				rects[i].width,
				rects[i].height);
			curPosX += rects[i].height + marginBottom;
		}
		return rects;
	}

	public static void ShowMessage(string text)
	{
		isMsg = true;
		msgText = text;
		lastTimeMsg = Time.time;
		durationMsg = 1000f;
	}

	public static void ShowMessage(string text, float time)
	{
		isMsg = true;
		msgText = text;
		lastTimeMsg = Time.time;
		durationMsg = time;
	}

	public static void HideMessage()
	{
		isMsg = false;
	}
}
