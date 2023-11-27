using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public PlayerHP PlayerHP;


    void Update()
    {
        text.text = "HP:" + PlayerHP.currentHP + "/" + PlayerHP.maxHP;
    }
}
