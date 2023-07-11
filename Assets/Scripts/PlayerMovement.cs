using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private float speed1;
    [SerializeField] private float speed2;
    [SerializeField] private Transform finish;
    [SerializeField] private Slider player1_Slider;
    [SerializeField] private Slider player2_Slider;
    private float stopTouch1;
    private float stopTouch2;
    [SerializeField] private GameObject player2_Button;

    private bool mode;

    [SerializeField] public StartGame game;

    void Start()
    {
        StartCoroutine(Timer());

        speed1 = 0f;
        speed2 = 0f;

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


    public void Move(bool player)
    {
        if (player)
        {
            speed1 += 1f;
            stopTouch1 = 0f;
        }
        else
        {
            speed2 += 1f;
            stopTouch2 = 0f;
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            stopTouch1 += 0.25f;
            stopTouch2 += 0.25f;

            if (stopTouch1 >= 0.5f && speed1 >= 1f)
            {
                speed1 -= 1f;

            }

            if (mode)
            {
                if (stopTouch2 >= 0.5f && speed2 >= 1f)
                {
                    speed2 -= 1f;
                }
            }

        }


    }


    IEnumerator AISpeed()
    {
        speed2 = 2f;
        yield return new WaitForSeconds(1);
        speed2 = 6f;
        yield return new WaitForSeconds(1);
        speed2 = 10f;
    }

}
