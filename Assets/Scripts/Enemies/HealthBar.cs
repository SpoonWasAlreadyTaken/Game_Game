using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;


    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        float c = currentValue;
        float m = maxValue;

        slider.value = c / m;
        Debug.Log(c / m);
    }

    void Update()
    {
        transform.rotation = camera.transform.rotation;
    }
}
