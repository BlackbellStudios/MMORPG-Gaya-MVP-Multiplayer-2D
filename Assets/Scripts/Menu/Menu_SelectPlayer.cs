using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_SelectPlayer : MonoBehaviour
{

  public GameBD GameBD;
  public CharsLoader CharsLoader;

  [SerializeField] private Button[] buttonLoadGamethisChar;
  [SerializeField] private Button[] buttonCreate;
  [SerializeField] private Button[] buttonDelete;
  [SerializeField] private Text[] charNome;
  [SerializeField] private Image[] charAvatar;

  [SerializeField] private Sprite charArrow;
  [SerializeField] private Sprite charWizard;
  [SerializeField] private Sprite charWarrior;

  [SerializeField] private int CharDelete; //recebe a posição do array
  [SerializeField] private Text Aviso;
  [SerializeField] private InputField NewCharName;
  [SerializeField] private Text AvisoCriar; // Aviso de erro na janela de criação
  [SerializeField] private Button ButtonConfirm;
  [SerializeField] private Image ClassArrow;
  [SerializeField] private Image ClassWizard;
  [SerializeField] private Image ClassWarrior;

  private Char[] Char;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {


  }
  public void LoadUI(Char[] Getchar)
  {
    Char = Getchar;
    for (int i = 0; i < Char.Length; i++)
    {
      charNome[i].text = Char[i]._nome;

      if (Char[i]._classe == "Arqueiro" || Char[i]._classe == "arqueiro")
      {
        charAvatar[i].sprite = charArrow;
      }
      else if (Char[i]._classe == "Mago")
      {
        charAvatar[i].sprite = charWizard;
      }
      else
      {
        charAvatar[i].sprite = charWarrior;
      }


      if (Char[i]._nome != null)
      {
        buttonCreate[i].gameObject.SetActive(false);
        buttonDelete[i].gameObject.SetActive(true);
        charAvatar[i].gameObject.SetActive(true);

      }

    }
  }

  public void DeleteChar(int PosChar)
  {
    Aviso.text = ("Você tem certeza que deseja deletar o personagem " + Char[PosChar]._nome + " permanentemente ? ");
    CharDelete = PosChar;
  }

  public void ConfirmDeleteChar()
  {
    int CharID = Char[CharDelete].id_personagem;

    StartCoroutine(TryDelete(CharID));
  }

  IEnumerator TryDelete(int i)
  {
    //Deleta personagem temporario na memoria "Banco de dados Off-line"
    yield return "1";

    /*WWW www = new WWW("http://gayaojogo.esy.es/PHP/CharDelete.php?CharID=" + i);
    yield return www;
    if (www.text == "1")
    {
        Debug.Log("Personagem deletado com sucesso!");
        ResetMenu();
    }
    else if (www.text == "2")
    {
        Debug.Log("Erro ao deletar personagem");
    }
    else {
        Debug.Log(www.error);
    }*/
  }

  public void ConfirmCreateChar()
  {
    int UserID = GameBD.myID;
    string CharName = NewCharName.text;
    string Class = "";

    if (CharName == "")
    {
      AvisoCriar.text = "Nome do Usuario não pode estar vazio";
    }
    else
    {
      if (ClassArrow.isActiveAndEnabled)
      {
        Class = "Arqueiro";
      }
      else if (ClassWizard.isActiveAndEnabled)
      {
        Class = "Mago";
      }
      else
      {
        Class = "Guerreiro";
      }
      StartCoroutine(TryCreateChar(UserID, CharName, Class));
    }


  }

  IEnumerator TryCreateChar(int i, string x, string y)
  {
    //Cria personagem temporario na memoria "Banco de dados Off-line"
    yield return "1";
    ResetMenu();
    /*
            WWW www = new WWW("http://gayaojogo.esy.es/PHP/CharCreate.php?UserID=" + i+"&CharName="+x+"&CharClass="+y);
            yield return www;
            if (www.text == "1")
            {
                Debug.Log("Personagem "+x+" criado com sucesso!");
                ResetMenu();
            }
            else if (www.text == "2")
            {
                Debug.Log("Erro ao criar personagem");
            }
            else
            {
                Debug.Log(www.error);
            }*/
  }
  public void ResetMenu()
  {
    for (int i = 0; i < charNome.Length; i++)
    {
      charNome[i].text = "SLOT VAZIO";
      charAvatar[i].gameObject.SetActive(false);
      buttonDelete[i].gameObject.SetActive(false);
      buttonCreate[i].gameObject.SetActive(true);
    }
    CharsLoader.GetChars(GameBD.myID);
  }

  public void LoadGame(int i)
  {
    //Desativada logica de loading da basa de dados
    GameBD.LoadChar(1, "Personagem teste", "Arqueiro", 1, 1, 1, 5, 5, 5, 5, 0, 0.ToString(), "5");
    string map = "map" + '0';
    /*GameBD.LoadChar(Char[i].id_personagem,
                    Char[i]._nome,
                    Char[i]._classe,
                    Char[i]._slot_1,
                    Char[i]._slot_2,
                    Char[i]._slot_3,
                    Char[i]._inteligencia,
                    Char[i]._forca,
                    Char[i]._critico,
                    Char[i]._taxa_critica,
                    Char[i]._localizacao,
                    Char[i].usuario_id_usuario,
                    Char[i].bolsa);*/

    //string map = "map" + 'Char[i]._localizacao';
    RoomOptions roomOptions = new RoomOptions();
    roomOptions.IsVisible = false;
    PhotonNetwork.JoinOrCreateRoom(map, roomOptions, TypedLobby.Default);
  }
}