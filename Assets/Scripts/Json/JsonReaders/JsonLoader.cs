using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class JsonLoader : Photon.MonoBehaviour {


	private string urlBase = "http://localhost/GayaOJogo/PHP/";

	private string[] phpFile;


	public Char[] Char;


	public void testando(){
		phpFile [0] = "1";
		phpFile [1] = "2";
		phpFile [2] = "3";
		phpFile [3] = "4";
		phpFile [4] = "5";
		for (int i = 0; i < phpFile.Length; i++) {
			Debug.Log (phpFile[i]);
		}
	}

	public void GetChars(int UserID)
	{

		//StartCoroutine(DownloadJson(UserID));

	}

	//IEnumerator DownloadJson(int UserID) {

		//WWW www = new WWW(urlUser + "?UserId=" + UserID);
		//yield return www;

		//Char = JsonHelper.FromJson<Char>(www.text);

		//Menu_SelectPlayer.LoadUI(Char);

	//}

}
