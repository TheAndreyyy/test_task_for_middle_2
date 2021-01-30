using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun_controller : MonoBehaviour
{
    public static int current_level=1;
    public static int count_of_cannonballs;
    public GameObject cannonBall;

    Rigidbody cannonballRB;
    public Transform shotPos;
    public float firePower;

    //public text GO_count_of_cannonballs;
    public Text text_count_of_cannonballs;
    public Text text_current_level;
    public Text text_next_level;

    //public GameObject current_level;
    //public GameObject GO_count_of_cannonballs;

    //int count_of_update;

    public GameObject ui_win;
    public GameObject ui_lose;

    public Slider slider;
    public int slider_value;

    public Text text_start;
    public Text text_finish;

    public AudioSource Audio;//звук выстрела пушки

    //progress progress_temp = new progress();

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        //var progress_temp = new progress();
        //пробуем загрузить данные об уровнях, если их нет, значит ставим дефолтный 1 уровень
        progress.Load(/*current_level, slider.value*/);
        
        //if (current_level == 0)
        //{
        //    Debug.Log("level= " + current_level);
        //    current_level = 1;
        //}
        //выполняем условия, кол-во снарядов = уровень * 3
        count_of_cannonballs = current_level * 3;
        text_count_of_cannonballs.text = "Count of Cannonballs: " + count_of_cannonballs;
        text_current_level.text = current_level.ToString();
        text_next_level.text = (current_level+1).ToString();

        //ui_win = GameObject.Find("UI_win");
        //ui_win.SetActive(false);
        //ui_lose = GameObject.Find("UI_lose");
        //ui_lose.SetActive(false);
        //Debug.Log(GameObject.FindGameObjectsWithTag("ui_win").Length);
        //Debug.Log(GameObject.FindGameObjectsWithTag("ui_lose").Length);
    }

    void Update()
    {
        //поворот пушки по тапу на экране
        if (Input.GetMouseButtonDown(1))
        {
            Turn_to_cursor();
            if (count_of_cannonballs > 0)
            {
                //выстрел из пушки
                count_of_cannonballs--;
                FireCannon();
                text_count_of_cannonballs.text = "Count of Cannonballs: " + count_of_cannonballs;
            }
        }

        if (GameObject.FindGameObjectsWithTag("target").Length == 0 && (ui_win.activeInHierarchy == false && ui_lose.activeInHierarchy == false))
        {
            //ui_win.SetActive(true);
            //ui_lose.SetActive(false);
            Debug.Log("YOU WIN");
                ui_win.SetActive(true);
            if (slider.value<slider.maxValue)
            {
            slider.value++;
            }
            else
            {
                slider.value = 0;
                text_start.text = current_level.ToString();
                text_finish.text = current_level+1.ToString();
                progress.Next_level(/*current_level,slider_value*/);
            }
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("target").Length > 0 && (ui_win.activeInHierarchy == false && ui_lose.activeInHierarchy == false) && count_of_cannonballs==0 && GameObject.FindGameObjectsWithTag("cannonball").Length == 0)
            {
                ui_lose.SetActive(true);
                Debug.Log("YOU LOSE");
                //progress_temp.Restart_level();
            }
        }
    }

    public void FireCannon()
    {
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, transform.rotation) as GameObject;
        cannonballRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonballRB.AddForce(transform.up * firePower);
        Shoot_sound();
    }

    public void Turn_to_cursor()
    {
        float oldX = Input.mousePosition.x;
        float oldY = Input.mousePosition.y;
        float newX = Remap(oldX, 0, 1080, 20, -20);
        float newY = Remap(oldY, 0, 1920, 105, 54);
        transform.rotation = Quaternion.Euler(newY, 0, newX);                 //ОСЬ X, Y - работают
    }

    public void onMouseDown()
    {

    }

    public void Shoot_sound() 
    {
        Audio.Play();
    }

    float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_collide : MonoBehaviour
{
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="target")
        {
            Audio.Play();
        }
    }
}

 */
