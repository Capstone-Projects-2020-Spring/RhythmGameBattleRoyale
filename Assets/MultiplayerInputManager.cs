using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class MultiplayerInputManager : MonoBehaviour
{
    //public data members that need explicit assignment in-editor
    public GameObject[] inputButtonObjects;
    public Material[] buttonMaterials;
    public List<Text> scoreObj = new List<Text>();

    //public data members that are assigned at runtime
    public bool[] notesOnButtons;
    public Text eliminationText;

    //private data members
    private MeshRenderer[] inputButtonMaterials;
    private bool[] buttonStates;
    private MultiplayerButtonManager[] buttonScriptReferences;

    private bool validInput = true;
    public GameObject backButton;
    public PlayerProps playerProps;

    // Start is called before the first frame update
    void Start()
    {
        inputButtonMaterials = new MeshRenderer[inputButtonObjects.Length];
        buttonStates = new bool[inputButtonObjects.Length];
        buttonScriptReferences = new MultiplayerButtonManager[inputButtonObjects.Length];
        notesOnButtons = new bool[inputButtonObjects.Length];

        for (int i = 0; i < inputButtonObjects.Length; i++)
        {
            inputButtonMaterials[i] = inputButtonObjects[i].GetComponent<MeshRenderer>();
            buttonStates[i] = false;
            notesOnButtons[i] = false;
            buttonScriptReferences[i] = inputButtonObjects[i].GetComponent<MultiplayerButtonManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (validInput == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                inputButtonMaterials[0].material = buttonMaterials[5];
                buttonStates[0] = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                inputButtonMaterials[1].material = buttonMaterials[6];
                buttonStates[1] = true;
            }
            if (Input.GetButtonDown("Fire3"))
            {
                inputButtonMaterials[2].material = buttonMaterials[7];
                buttonStates[2] = true;
            }
            if (Input.GetButtonDown("Fire4"))
            {
                inputButtonMaterials[3].material = buttonMaterials[8];
                buttonStates[3] = true;
            }
            if (Input.GetButtonDown("Fire5"))
            {
                inputButtonMaterials[4].material = buttonMaterials[9];
                buttonStates[4] = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                inputButtonMaterials[0].material = buttonMaterials[0];
                buttonStates[0] = false;
            }
            if (Input.GetButtonUp("Fire2"))
            {
                inputButtonMaterials[1].material = buttonMaterials[1];
                buttonStates[1] = false;
            }
            if (Input.GetButtonUp("Fire3"))
            {
                inputButtonMaterials[2].material = buttonMaterials[2];
                buttonStates[2] = false;
            }
            if (Input.GetButtonUp("Fire4"))
            {
                inputButtonMaterials[3].material = buttonMaterials[3];
                buttonStates[3] = false;
            }
            if (Input.GetButtonUp("Fire5"))
            {
                inputButtonMaterials[4].material = buttonMaterials[4];
                buttonStates[4] = false;
            }


            if (Input.GetButtonDown("Fire6") || Input.GetButtonDown("Strum") || true)
            {
                if (checkStrum())
                {
                    executeStrum();
                    PhotonNetwork.LocalPlayer.AddScore(1000 + Random.Range(0, 500));
                    getScores();
                }
            }
        }

        getScores();

        List<int> scores = new List<int>();

        for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            scores.Add(PhotonNetwork.CurrentRoom.Players[i].GetScore());
        }

        scores.Sort();
        int highestScore = scores[scores.Count - 1];
        
        for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            if (highestScore > 10000)
            {
                if (scores[0] == PhotonNetwork.CurrentRoom.Players[i].GetScore())
                {
                    PhotonView PV = PhotonView.Get(this);
                    PV.RPC("RPC_Eliminate", PhotonNetwork.CurrentRoom.Players[i]);
                    PV.RPC("RPC_CancelPlayer", RpcTarget.All, PhotonNetwork.CurrentRoom.Players[i]);
                }
            }
        }

        for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            if (highestScore > 20000)
            {
                if (scores[1] == PhotonNetwork.CurrentRoom.Players[i].GetScore())
                {
                    PhotonView PV = PhotonView.Get(this);
                    PV.RPC("RPC_Eliminate", PhotonNetwork.CurrentRoom.Players[i]);
                    PV.RPC("RPC_CancelPlayer", RpcTarget.All, PhotonNetwork.CurrentRoom.Players[i]);
                    PV.RPC("RPC_BackButton", RpcTarget.All);
                }
            }
        }
    }

    private bool checkStrum()
    {
        bool atLeastOne = false;
        for (int i = 0; i < buttonStates.Length; i++)
        {
            if ((buttonStates[i]) != notesOnButtons[i])
            {
                return false;
            }
            if (notesOnButtons[i])
            {
                atLeastOne = true;
            }
        }
        return atLeastOne;
    }

    private void executeStrum()
    {
        for (int i = 0; i < notesOnButtons.Length; i++)
        {
            if (notesOnButtons[i])
            {
                buttonScriptReferences[i].destroyNote();
            }

            notesOnButtons[i] = false;
        }
    }

    private void getScores()
    {
        if (SceneManager.GetActiveScene().name == "MultiPlayerScene")
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
                {
                    scoreObj[i].text = PhotonNetwork.CurrentRoom.Players[i].GetScore().ToString();
                }
            }
        }
    }

    [PunRPC]
    private void RPC_Eliminate()
    {
        validInput = false;
        eliminationText.text = "You have been eliminated";
    }

    [PunRPC]
    private void RPC_BackButton()
    {
        backButton.SetActive(true);
    }

    [PunRPC]
    private void RPC_CancelPlayer(Player player)
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                if (playerProps.playerNames[i].text == player.NickName)
                {
                    playerProps.playerNames[i].GetComponent<Text>().color = Color.red;
                }
                if(scoreObj[i].text == player.GetScore().ToString())
                {
                    scoreObj[i].GetComponent<Text>().color = Color.red;
                }
            }
        }
        
    }

}