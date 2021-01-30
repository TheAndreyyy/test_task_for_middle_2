using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_targets : MonoBehaviour
{
    Transform this_pos;
    GameObject ui_win;
    GameObject ui_lose;
    void Start()
    {
        this_pos = GetComponent<Transform>();
        ui_win = GameObject.Find("UI_win");
        ui_lose = GameObject.Find("UI_lose");
    }
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }
    }



}
