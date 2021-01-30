using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_controller : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }
        //if (GameObject.FindGameObjectsWithTag("target").Length ==1)
        //{
        //    //ui_win.SetActive(true);
        //    //ui_lose.SetActive(false);
        //    //Debug.Log("YOU WIN");
        //}
        //else
        //{
        //    if (gun_controller.count_of_cannonballs==0)
        //    {
        //    //Debug.Log("YOU LOSE");
        //    }
        //}
        //Debug.Log(GameObject.FindGameObjectsWithTag("target").Length);
        //try_find_objects(other, count_of_finded_objects);

    }
}
