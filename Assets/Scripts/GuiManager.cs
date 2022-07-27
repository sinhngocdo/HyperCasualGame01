using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public static GuiManager instance;

    public TMP_Text yourScoreValueText;
    public TMP_Text currentScoreText;
    public TMP_Text BestScoreValueText;

    public GameObject BestScorePanel;
    public GameObject ShopPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
