using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGUI : MonoBehaviour
{
	public GUISkin skin;

	string layer = "Main menu";

	string leaderScoreText = "Loading...";
	float scoreHeight = 32f;

	Rect rectBoxMenu = new Rect(0f, 0f, 400f, 467f);
	Rect rectScrollView = new Rect(0f, 0f, 325f, 250f);
	Rect rectLabelScrollView = new Rect(0f, 0f, 325f, 1000f);
	//Rect rectButtonScrollView = new Rect(0f, 0f, 200f, 50f);

	Rect[] rectShopElms = new Rect[6];

	Vector2 scrollPos = Vector2.zero;
	Rect[] rectMenuBtns =
	{
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
		new Rect(0f, 0f, 200f, 50f),
	};

	void Awake()
	{
		SaveLoader.Load();
	}

	void Start ()
	{
		rectBoxMenu = SceneGUI.CenterRect(rectBoxMenu);
		rectScrollView = SceneGUI.CenterRect(rectScrollView);
		rectMenuBtns = SceneGUI.CenterRect(rectMenuBtns);
		rectShopElms[0] = new Rect(Screen.width / 2 - 162f, rectMenuBtns[1].y, 162f, 50f);
		rectShopElms[1] = new Rect(Screen.width / 2, rectMenuBtns[1].y, 162f, 50f);
		rectShopElms[2] = new Rect(Screen.width / 2 - 162f, rectMenuBtns[2].y, 162f, 50f);
		rectShopElms[3] = new Rect(Screen.width / 2, rectMenuBtns[2].y, 162f, 50f);
		rectShopElms[4] = new Rect(Screen.width / 2 - 162f, rectMenuBtns[3].y, 162f, 50f);
		rectShopElms[5] = new Rect(Screen.width / 2, rectMenuBtns[3].y, 162f, 50f);
		/*rectButtonScrollView = SceneGUI.CenterRect(rectButtonScrollView);
		rectButtonScrollView = new Rect(rectButtonScrollView.x,
										rectButtonScrollView.y + 165f,
										rectButtonScrollView.width,
										rectButtonScrollView.height);*/
	}
	
	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.Box(rectBoxMenu, layer);
		if (layer == "Main menu")
		{
			if (GUI.Button(rectMenuBtns[0], "Start"))
				layer = "Start";
			if (GUI.Button(rectMenuBtns[1], "Shop"))
				layer = "Shop";
			if (GUI.Button(rectMenuBtns[2], "Best score"))
			{
				scrollPos = Vector2.zero;
				leaderScoreText = "Loading... ";
				StartCoroutine(LoadScore());
				layer = "Best score";
			}
			if (GUI.Button(rectMenuBtns[3], "About"))
			{
				scrollPos = Vector2.zero;
				layer = "About";
			}
			if (GUI.Button(rectMenuBtns[4], "Exit"))
				Application.Quit();
		}
		else if (layer == "About")
		{
			scrollPos = GUI.BeginScrollView(rectScrollView, scrollPos, new Rect(0f, 0f, 300f, 200f));
			GUI.Label(rectLabelScrollView, "This game created by Savchenko Vlad, Mikhaylenko Oleg and Buzinniy Olexandr. Feel free to contact us: brightsvl@gmail.com");
			GUI.EndScrollView();
			if (GUI.Button(rectMenuBtns[4], "Back")) layer = "Main menu";
		}
		else if (layer == "Best score")
		{
			scrollPos = GUI.BeginScrollView(rectScrollView, scrollPos, new Rect(0f, 0f, 300f, scoreHeight));
			GUI.Label(rectLabelScrollView, leaderScoreText);
			GUI.EndScrollView();
			if (GUI.Button(rectMenuBtns[4], "Back")) layer = "Main menu";
		}
		else if (layer == "Start")
		{
			for (int i = 1; i <= SaveLoader.Level; i++)
			{
				if (GUI.Button(rectMenuBtns[i - 1], "Level  " + i))
				{
					Application.LoadLevel("Level " + i);
				}
			}
			if (GUI.Button(rectMenuBtns[4], "Back")) layer = "Main menu";
		}
		else if (layer == "Shop")
		{
			GUI.Label(rectMenuBtns[0], "Money: <color=yellow>" + SaveLoader.Money + "</color>", skin.GetStyle("ShopLabel"));
			GUI.Label(rectShopElms[0], "Health: " + SaveLoader.Health, skin.GetStyle("ShopLabel"));
			if (GUI.Button(rectShopElms[1], "Increase <color=yellow>" + Updator.IncreaseHealthCost + "$</color>", skin.GetStyle("ShopBtn")))
				Updator.IncreaseHealth();
			GUI.Label(rectShopElms[2], "Damage: " + SaveLoader.Damage, skin.GetStyle("ShopLabel"));
			if (GUI.Button(rectShopElms[3], "Increase <color=yellow>" + Updator.IncreaseDamageCost + "$</color>", skin.GetStyle("ShopBtn")))
				Updator.IncreaseDamage();
			GUI.Label(rectShopElms[4], "Reload time: " + SaveLoader.ReloadTime, skin.GetStyle("ShopLabel"));
			if (GUI.Button(rectShopElms[5], "Increase <color=yellow>" + Updator.IncreaseReloadTimeCost + "$</color>", skin.GetStyle("ShopBtn")))
				Updator.IncreaseReloadTime();
			if (GUI.Button(rectMenuBtns[4], "Back")) layer = "Main menu";
		}
	}

	IEnumerator LoadScore ()
	{
		WWW scoreJson = new WWW("http://somestuff.cf/wadjet/get_scores.php");
		yield return scoreJson;
		if (scoreJson.text != "")
		{
			leaderScoreText = "";
			var strArrs = scoreJson.text.Split('|');
			scoreHeight = 32f * strArrs.Length;
			for (var i = 0; i < strArrs.Length; i++)
			{
				var arr = strArrs[i].Split('#');
				leaderScoreText += (i+1) + ". " + arr[0] + " - " + arr[1] + "\n";
			}
		}
		else
		{
			scoreHeight = 32f;
			leaderScoreText = "No scores";
		}
	}
}
