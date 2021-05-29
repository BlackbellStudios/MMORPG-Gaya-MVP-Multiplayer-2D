using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonInstantiate : Photon.MonoBehaviour {
	[SerializeField] private GameObject Player;
    [SerializeField] private Transform InstantiatePoint;
    //[SerializeField] private GameBD GameBD;

    // Use this for initialization

    void Start () {
        //GameBD = GameObject.Find("GameBD").GetComponent<GameBD>();
        PhotonNetwork.Instantiate(Player.name, InstantiatePoint.position, Quaternion.identity,0);

        //PhotonNetwork.RaiseEvent(0, new object[] { Player.name, new Vector3(0, 0, -3) , Quaternion.identity , GameBD.myClasse}, true, new RaiseEventOptions() { Receivers = ReceiverGroup.All, CachingOption = EventCaching.AddToRoomCache});
	}

    /*private void OnEvent(byte eventcode, object content, int senderid) {
        if (eventcode == 0)
        {
            object[] data = (object[])content;

            string prefabPathAndName = (string)data[0];
            Vector3 position = (Vector3)data[1];
            Quaternion rotation = (Quaternion)data[2];
            string classe = (string)data[3];

            PhotonNetwork.Instantiate(Player.name, InstantiatePoint.position, Quaternion.identity, 0);
        }
    }*/
}
