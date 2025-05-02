using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{

    static UI singlton;



    // Start is called before the first frame update
    public Text scoreText;

    public GameObject panel;

    public Text panelScoreText;

    public Text defeatText;

    public Text victoryText;

    public Button ButtonVictory;

    public Button ButtonDefeat;

    void Awake()
    {
        singlton = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = Player.score.ToString();   
    }


    public void OnClickRestart()
    {
        Player.Restart();

    }

    public static void ShowVictoryPanel()
    {
        singlton.panel.SetActive(true);
        singlton.victoryText.gameObject.SetActive(true);
        singlton.panelScoreText.text = Player.score.ToString();
        singlton.ButtonVictory.gameObject.SetActive(true);
    }

    public static void ShowDefeatPanel()
    {
        singlton.panel.SetActive(true);
        singlton.defeatText.gameObject.SetActive(true);
        singlton.panelScoreText.text = Player.score.ToString();
        singlton.ButtonDefeat.gameObject.SetActive(true);
    }

}


