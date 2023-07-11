using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject switchF_R;
    [SerializeField] public bool isRobot;

    private void Start()
    {
        panel.SetActive(false);
        switchF_R.SetActive(true);
    }
    public void playWithFriend()
    {
        panel.SetActive(true);
        switchF_R.SetActive(false);

        isRobot = false;
    }

    public void playWithRobot()
    {
        panel.SetActive(true);
        switchF_R.SetActive(false);
        isRobot = true;
    }

    public void beck_button()
    {
        SceneManager.LoadScene(0);

    }

}
