using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progress : MonoBehaviour
{

    //public Slider slider;

    static public void Save(int current_level, float slider_value)
    {
        //save coins
        //PlayerPrefs.SetInt("coins", collect_coins.coins_count);
        PlayerPrefs.SetInt("current_level", current_level);
        PlayerPrefs.SetFloat("current_progress", slider_value);


        //save pos of player
        //if (player_move.rb != null)
        //{
        //    PlayerPrefs.SetFloat("x", player_move.rb.position.x);
        //    PlayerPrefs.SetFloat("y", player_move.rb.position.y);
        //}

        print("data is saved");
        //collect_coins.coins_count++;
    }

    static public void Load(/*int current_level, float slider_value*/)
    {
        if (PlayerPrefs.HasKey("current_level") && PlayerPrefs.GetInt("current_level")>0/*&& PlayerPrefs.HasKey("current_progress")*/)
        {
            //gun_controller.current_level = PlayerPrefs.GetInt("current_level", current_level);
            gun_controller.current_level= PlayerPrefs.GetInt("current_level");
            //slider_value = PlayerPrefs.GetFloat("current_progress", slider_value);
            print("data is loaded");
            print("current level is "+gun_controller.current_level);
        }
        else
        {
            PlayerPrefs.SetInt("current_level", 1);
            gun_controller.current_level = 1;
            print("its new game, we create new record about current level");
            print("and now current level is "+gun_controller.current_level);
        }
    }

    static public void Next_level()
    {
        //gun_controller.     ++;
        PlayerPrefs.SetInt("current_level", (PlayerPrefs.GetInt("current_level") + 1));
        print("now cl is "+ PlayerPrefs.GetInt("current_level"));
        //PlayerPrefs.SetFloat("current_progress", 1/*slider_value*/);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Restart_level();
    }

    static public void Prev_level()
    {
        if (gun_controller.current_level > 1)
        {
            //gun_controller.current_level--;
            PlayerPrefs.SetInt("current_level", PlayerPrefs.GetInt("current_level")-1);
            Restart_level();
        }
    }

    static public void Restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    static public void TEST_function()
    {
        print("data is " + PlayerPrefs.GetInt("current_level"));
        //PlayerPrefs.DeleteAll();
        //print("all data is cleared");
    }


    //static public void progress_Reset()
    //{
    //    PlayerPrefs.DeleteAll();
    //    //collect_coins.coins_count = 0;
    //    print("progress is Reset");
    //}

    //static public void progress_Reset()
    //{
    //    PlayerPrefs.DeleteAll();
    //    //collect_coins.coins_count = 0;
    //    print("progress is Reset");
    //}
}
