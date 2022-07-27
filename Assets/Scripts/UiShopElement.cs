using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiShopElement : MonoBehaviour
{
    public int id;
    public int cost;

    public Text constTxt;
    public Button btn_Purchase;

    private void Awake()
    {
        btn_Purchase.onClick.AddListener(OnPurchase);

        UpdateView();
    }

    private void UpdateView()
    {
        constTxt.text = cost.ToString();
    }
    
    private void OnPurchase()
    {
        Debug.Log("Purchase success");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
