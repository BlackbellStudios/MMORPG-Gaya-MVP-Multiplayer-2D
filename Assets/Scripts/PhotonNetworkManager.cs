using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonNetworkManager : Photon.MonoBehaviour {

    public Button LoginBtn;
    public UserLoader UserLoader;
    public GameBD GameBD;

    [SerializeField] private InputField userField = null;
    [SerializeField] private InputField passField = null;

    public GameObject LoadScreen;
    public Slider slider;

    // Use this for initialization
    private void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public virtual void OnConnectedToMaster()
    {
        LoginBtn.interactable = true;
    }

    public virtual void OnJoinedLobby() {
        Debug.Log("Você esta agora na sala de espera");
        GetMyChars();



        //Junta-se a sala se ela existe ou então cria uma sala
        //PhotonNetwork.JoinOrCreateRoom("Map001", null, null);
    }

    public void GetMyChars() {
        string getUser = userField.text;
        string getPass = passField.text;

        UserLoader.GetUser(getUser, getPass);
    }
    public virtual void OnJoinedRoom(){
		//PhotonNetwork.automaticallySyncScene = true;
		//PhotonNetwork.LoadLevel (1);
        //SceneManager.LoadScene ("Game",LoadSceneMode.Single);
        StartCoroutine(LoadSceneSyc(1));
        Debug.Log("Você esta agora no mapa (em jogo)");
    }

    IEnumerator LoadSceneSyc(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        LoadScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
