using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_Button : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject switchF_R;

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    

    }
}