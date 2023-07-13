using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public Transform player1;
    [SerializeField] public Transform player2;
    [SerializeField] public Vector3 startPlayer1;
    [SerializeField] public Vector3 startPlayer2;
    [SerializeField] public float speed1;
    [SerializeField] public float speed2;
    [SerializeField] private Transform finish;
    [SerializeField] private Slider player1_Slider;
    [SerializeField] private Slider player2_Slider;
    [SerializeField] private GameObject player1_Button;
    [SerializeField] private GameObject player2_Button;


    [SerializeField] public StartGame game;

    //[SerializeField] private Init initSDK;


    void Start()
    {

        speed1 = 0f;
        speed2 = 0f;

        startPlayer1 = player1.position;
        startPlayer2 = player2.position;

        player1_Slider.maxValue = finish.position.y - player1.position.y;
        player2_Slider.maxValue = finish.position.y - player2.position.y;

    }

    void Update()
    {
        player1.Translate(player1.up * speed1 * Time.deltaTime);
        player2.Translate(player2.up * speed2 * Time.deltaTime);

        player1_Slider.value = player1_Slider.maxValue - (finish.position.y - player1.position.y);
        player2_Slider.value = player2_Slider.maxValue - (finish.position.y - player2.position.y);

        if (player1.position.y > player2.position.y && player1.position.y > 0f)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player1.position.y, Camera.main.transform.position.z);
        }
        if (player2.position.y > player1.position.y && player2.position.y > 0f)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, player2.position.y, Camera.main.transform.position.z);
        }



        if (!Init.Instance.mobile)
        {
            player1_Button.SetActive(false);
            player2_Button.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Move(true);
            }

            if (!game.isRobot)
            {
                if (Input.GetKeyDown(KeyCode.M))
                {
                    Move(false);
                }
            }
            else
            {
                StartCoroutine(AISpeed());
            }
        }
        else
        {
            player1_Button.SetActive(true);
            if (!game.isRobot)
            {
                player2_Button.SetActive(true);
            }
            else
            {
                StartCoroutine(AISpeed());
            }
        }
    }


    public void Move(bool player)
    {
        if (player)
        {
            speed1 += 1f;
        }
        else
        {
            speed2 += 1f;
        }
    }



    IEnumerator AISpeed()
    {
        speed2 = 2f;
        yield return new WaitForSeconds(1);
        speed2 = 6f;
        yield return new WaitForSeconds(1);
        speed2 = 10f;
        yield return new WaitForSeconds(1);
        speed2 = 12f;
    }

}
