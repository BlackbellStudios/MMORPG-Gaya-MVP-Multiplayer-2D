using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserLoader : MonoBehaviour
{
    public GameBD GameBD;
    public CharsLoader CharsLoader;
	private string urlUser = "http://gayaojogo.esy.es/PHP/User.php"; //url base do Json Usuario

    public void GetUser(string name, string senha)
    {
        WWW www = new WWW(urlUser + "?login=" + name + "&senha=" + senha);
        StartCoroutine(DownloadJson(www));
    }

    IEnumerator DownloadJson(WWW www)
    {
        //yield return new WaitUntil(() => www.isDone);
        yield return www;
        if (www.error == null)
        {
            Usuario usuario = JsonUtility.FromJson<Usuario>(www.text);
            GameBD.LoadUsuario(usuario.id_usuario, usuario._nome, usuario._email, usuario._status);
            CharsLoader.GetChars(GameBD.myID);
            Debug.Log("Usuario Carregado com sucesso!");
        }
        else
        {
                Debug.Log(www.error);
        }
    }
}
