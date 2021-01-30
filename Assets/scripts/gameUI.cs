using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameUI : MonoBehaviour
{

    [SerializeField] Slider slider;

    float maxDistance;

    public void setProgress(int p)
    {
        slider.value = p;
    }

    public void Progress_reset()
    {
        slider.value = 0;
    }

    public void Progress_reset(int p)
    {
        slider.value = 0;
    }
}