using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class LoginManager : Photon.MonoBehaviour
{
  [SerializeField] private InputField userField = null;
  [SerializeField] private InputField passField = null;
  [SerializeField] private Text feedbackmsg = null;
  [SerializeField] private Toggle rememberData = null;
  [SerializeField] private GameObject WaitingScreen = null;
  [SerializeField] private GameObject LoginScreen = null;
  [SerializeField] private GameObject CharacterScreen = null;
  [SerializeField] private GameObject UserInfo;

  [SerializeField] private Text ConnectText;

  public Char MyChar;

  private string url = "http://gayaojogo.esy.es/PHP/login.php"; //url base Login

  void Start()
  {
    if (PlayerPrefs.HasKey("remember") && PlayerPrefs.GetInt("remember") == 1)
    {
      userField.text = PlayerPrefs.GetString("rememberLogin");
      passField.text = PlayerPrefs.GetString("rememberPass");
    }
  }

  private void Update()
  {
    // Teste não usar .tostring no update
    ConnectText.text = PhotonNetwork.connectionStateDetailed.ToString();
  }

  //Tenta fazer o login com as informaçoes inseridas
  public void TryLogin()
  {
    if (userField.text == "" || passField.text == "")
    {
      FeedBackError("Preencha todos os campos!");
    }
    else
    {
      string getUser = userField.text;
      string getPass = passField.text;

      if (rememberData.isOn)
      {
        PlayerPrefs.SetInt("remember", 1);
        PlayerPrefs.SetString("rememberLogin", getUser);
        PlayerPrefs.SetString("rememberPass", getPass);
      }
      //WWW www = new WWW(url + "?login=" + getUser + "&senha=" + getPass);
      //Ao inves de fazer o request a api, autoriza qualquer login
      StartCoroutine(ValidaLogin(" 1"));
    }
  }

  //Valida o login após resposta do servidor!
  IEnumerator ValidaLogin(String www)
  {
    //Metodo deve receber WWW, como api esta off, recebe string
    yield return www;
    if (www == " 1")
    {
      FeedBackOk("Logado com sucesso!");
      StartCoroutine(LoadingScene());

    }

    /* Comentada a logica do servidor 
        if (www.error == null)
        {
          if (www.text == " 1")
          {
            FeedBackOk("Logado com sucesso!");
            StartCoroutine(LoadingScene());

          }
          else if (www.text == " 2")
          {
            FeedBackError("Usuario não encontrado!");
          }
          else if (www.text == " 3")
          {
            FeedBackError("Senha incorreta!");
          }
          else
          {
            FeedBackError("Impossivel realizar conexão");
            print(www.text);
          }
        }
        else
        {
          if (www.error == "couldn't connect to host")
          {
            FeedBackError("Servidor indisponível");
          }
        }*/
  }

  //Após login autorizado fazer...
  IEnumerator LoadingScene()
  {
    PhotonNetwork.JoinLobby();

    WaitingScreen.gameObject.SetActive(true);
    LoginScreen.gameObject.SetActive(false);
    yield return new WaitForSeconds(2);
    WaitingScreen.gameObject.SetActive(false);
    CharacterScreen.gameObject.SetActive(true);
  }

  //Mensagens de erro!
  void FeedBackOk(string mensagem)
  {
    feedbackmsg.CrossFadeAlpha(100f, 0f, false);
    feedbackmsg.color = Color.green;
    feedbackmsg.text = mensagem;
  }
  void FeedBackError(string mensagem)
  {
    feedbackmsg.CrossFadeAlpha(100f, 0f, false);
    feedbackmsg.color = Color.red;
    feedbackmsg.text = mensagem;
    feedbackmsg.CrossFadeAlpha(0f, 2f, false);
    userField.text = "";
    passField.text = "";
  }
}
