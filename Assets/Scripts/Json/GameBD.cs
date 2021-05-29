using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBD : MonoBehaviour
{

  [SerializeField] public int myID;
  [SerializeField] public string myUser;
  [SerializeField] public string myEmail;
  [SerializeField] public int myStatus;
  [SerializeField] public int myId_personagem;
  [SerializeField] public string myNome;
  [SerializeField] public string myClasse;
  [SerializeField] public int mySlot_1;
  [SerializeField] public int mySlot_2;
  [SerializeField] public int mySlot_3;
  [SerializeField] public int myInteligencia;
  [SerializeField] public int myForca;
  [SerializeField] public int myCritico;
  [SerializeField] public int myTaxa_critica;
  [SerializeField] public int myLocalizacao;
  [SerializeField] public string myUsuario_id_usuario;
  [SerializeField] public string myBolsa;

  public void LoadUsuario(int _ID, string _nome, string _email, int _status)
  {
    myID = _ID;
    myUser = _nome;
    myEmail = _email;
    myStatus = _status;
  }

  public void LoadChar(int _Id_personagem, string _nome, string _classe, int _slot_1, int _slot_2, int _slot_3, int _inteligencia, int _forca, int _critico, int _taxa_critico, int _localizacao, string _usuario_id_usuario, string _bolsa)
  {
    myId_personagem = _Id_personagem;
    myNome = _nome;
    myClasse = _classe;
    mySlot_1 = _slot_1;
    mySlot_2 = _slot_2;
    mySlot_3 = _slot_3;
    myInteligencia = _inteligencia;
    myForca = _forca;
    myCritico = _critico;
    myTaxa_critica = _taxa_critico;
    myLocalizacao = _localizacao;
    myUsuario_id_usuario = _usuario_id_usuario;
    myBolsa = _bolsa;
  }

  public void Start()
  {
    DontDestroyOnLoad(this);
  }
}
