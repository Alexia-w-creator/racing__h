using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPrev : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject menu;

    void Start()
    {
        menu.SetActive(true);
    }


    public void play()
    {
        SceneManager.LoadScene(1);

    }
}
