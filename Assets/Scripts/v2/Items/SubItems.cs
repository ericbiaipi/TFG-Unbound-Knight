using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    public Text subItemsText;
    public int subItemsAmount;

    public static SubItems instance;

    public void Awake()
    {
        if (instance == null) instance = this; 
    }

    public void Start()
    {
        subItemsText.text = "x " + subItemsAmount.ToString();
    }

    public void SubItem(int subItemAmount)
    { 
        subItemsAmount += subItemAmount;
        subItemsText.text = "x " + subItemsAmount.ToString();
    }
}
