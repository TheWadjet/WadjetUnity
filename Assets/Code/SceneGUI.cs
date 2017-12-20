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

	public Texture statsImg;
	public Texture menuImg;
	public GUISkin skin;

	string nameFieldStr = "Anon";
	string statusOnlineScore = "";
	Rect rectMsg = new Rect(0,0,400,200);
	Rect rectMsgText = new Rect(0, 0, 350, 150);
	Rect rectBtnBack = new Rect(10f, 10f, 40f, 40f);
	Rect rectHP;
	Rect rectGold;
	Rect rectScore;
	Rect rectStats;

	Rect rectBoxMenu = new Rect(0f, 0f, 400f, 467f);
	Rect[] rectMenuBtns =
	{
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
	};

	public static int ILayer
	{
		get { return iLayer; }
		set { iLayer = value; }
	}

	private void Start()
	{
		rectBoxMenu = CenterRect(rectBoxMenu);
		rectMenuBtns = CenterRect(rectMenuBtns);
		rectStats = new Rect(Screen.width - 210f, 10f, 200f, 115f);
		rectGold = new Rect(Screen.width - 210f, 10f, 150f, 30f);
		rectHP = new Rect(Screen.width - 210f, 50f, 150f, 30f);
		rectScore = new Rect(Screen.width - 210f, 90f, 150f, 30f);
		mainTower = GameObject.Find("MainTower").GetComponent<MainTower>();
		rectMsg = CenterRect(rectMsg);
		rectMsgText = CenterRect(rectMsgText);
	}

	private void OnGUI()
	{
		if (isMsg && lastTimeMsg + durationMsg > Time.time)
		{
			GUI.Box(rectMsg, "");
			GUI.Label(rectMsgText, msgText);
		}
		if (iLayer == 0)
		{
			GUI.DrawTexture(rectStats, statsImg);
			GUI.Label(rectGold, SaveLoader.Money.ToString(), skin.GetStyle("LabelStat"));
			GUI.Label(rectHP, mainTower.HP, skin.GetStyle("LabelStat"));
			GUI.Label(rectScore, SaveLoader.Score.ToString(), skin.GetStyle("LabelStat"));
			if (GUI.Button(rectBtnBack, menuImg))
				Application.LoadLevel("MainMenu");
		}
		else if (iLayer == 1)	// defeat
		{
			GUI.skin = skin;
			GUI.Box(rectBoxMenu, "Defeat!");
			GUI.Label(rectMenuBtns[0], "Total score: " + SaveLoader.Score, skin.GetStyle("LabelVD"));
			GUI.Label(rectMenuBtns[1], "Total money: " + SaveLoader.Money, skin.GetStyle("LabelVD"));
			if (GUI.Button(rectMenuBtns[4], "Continue"))
			{
				Application.LoadLevel("MainMenu");
			}
		}
		else if (ILayer == 2)	// victory
		{
			GUI.skin = skin;
			GUI.Box(rectBoxMenu, "Victory!");
			GUI.Label(rectMenuBtns[0], "Total score: " + SaveLoader.Score, skin.GetStyle("LabelVD"));
			nameFieldStr = GUI.TextField(rectMenuBtns[1], nameFieldStr);
			if (GUI.Button(rectMenuBtns[2], "Set score online", skin.GetStyle("ShopBtn")) && statusOnlineScore != "Succesfully set")
				SetOnlineScore();
			GUI.Label(rectMenuBtns[3], statusOnlineScore, skin.GetStyle("LabelVD"));
			if (GUI.Button(rectMenuBtns[4], "Continue"))
			{
				int currentLvl = int.Parse(Application.loadedLevelName.Substring(6));
				Application.LoadLevel("Level " + (currentLvl + 1));
			}
		}
	}

	void SetOnlineScore ()
	{
		statusOnlineScore = "Loading...";
		StartCoroutine(LoadScore());
	}

	IEnumerator LoadScore()
	{
		var url = "http://somestuff.cf/wadjet/set_score.php?score=" + SaveLoader.Score + "&name=" + nameFieldStr;
		Debug.Log(url);
		WWW answer = new WWW(url);
		yield return answer;
		statusOnlineScore = answer.text;
	}

	public static Rect CenterRect(Rect rect)
	{
		return new Rect(Screen.width / 2f - rect.width / 2f, Screen.height / 2f - rect.height / 2f, rect.width, rect.height);
	}

	public static Rect[] CenterRect(Rect[] rects)
	{
		float heightElms = 0f;
		for (int i = 0; i < rects.Length; i++)
		{
			heightElms += rects[i].height;
		}
		float curPosX = 0;
		for (int i = 0; i < rects.Length; i++)
		{
			float marginBottom = rects[i].height * 0.3f;
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
