using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;


public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player1Victory;
    [SerializeField] private GameObject player2Victory;
    [SerializeField] private Transform finish;
    [SerializeField] private Init initSDK;


    void Start()
    {
        player1Victory.SetActive(false);
        player2Victory.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(player1.transform.position.y);
        if (player1.transform.position.y > finish.position.y)
        {
            EndGame(player1Victory);
        }
        else if (player2.transform.position.y > finish.position.y)
        {
            EndGame(player2Victory);
        }
    }


    private void EndGame(GameObject panel)
    {
        panel.SetActive(true);
        Invoke("toMenu", 3f);

        initSDK.ShowInterstitialAd();
        
        //initSDK.RateGameFunc();
        
    }

    private void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
