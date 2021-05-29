using UnityEngine;
using System.Collections;

public class CharsLoader : MonoBehaviour
{
  private string urlUser = "http://gayaojogo.esy.es/PHP/MyChars.php"; //url base do Json Usuario
                                                                      // Use this for initialization
  public Char[] Char;
  public Menu_SelectPlayer Menu_SelectPlayer;

  public void GetChars(int UserID)
  {

    StartCoroutine(DownloadJson(UserID));

  }

  IEnumerator DownloadJson(int UserID)
  {
    yield return '1';
    //WWW www = new WWW(urlUser + "?UserId=" + UserID);
    //yield return www;

    //Char = JsonHelper.FromJson<Char>(www.text);
    Menu_SelectPlayer.LoadUI(Char);

  }
}
