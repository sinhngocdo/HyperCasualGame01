using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairControl : MonoBehaviour
{
    [SerializeField] List<GameObject> stairs;

    [SerializeField] GameObject stairPrefab;

    public float pos1, pos2, pos3, pos4;

    private void Awake()
    {
        SetColor();
    }

    // Start is called before the first frame update
    void Start()
    {

        SetRandomPositionMainStair();
    }

    void SetColor()
    {
        float randomHue = Random.Range(0.5f, 2f);
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        stairPrefab.GetComponent<SpriteRenderer>().color = newColor * randomHue;
        try
        {
            for (int i = 0; i <= this.stairs.Count; i++)
            {
                this.stairs[i].GetComponent<SpriteRenderer>().color = newColor;
            }


        }
        catch (System.Exception)
        {

            Debug.LogWarning("ok");
        }


    }


    void SetRandomPositionMainStair()
    {
        int randomPos = Random.Range(1, 4);

        Debug.Log(randomPos);

        switch (randomPos)
        {
            case 1: stairPrefab.transform.position = new Vector2(pos1, transform.position.y);
                break;
            case 2:
                stairPrefab.transform.position = new Vector2(pos2, transform.position.y);
                break;
            case 3:
                stairPrefab.transform.position = new Vector2(pos3, transform.position.y);
                break;
            case 4:
                stairPrefab.transform.position = new Vector2(pos4, transform.position.y);
                break;
            default:
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
        CheckBoxStair();
    }


    void CheckBoxStair()
    {
        if (transform.position.y < Camera.main.transform.position.y - 30)
        {
            Destroy(this.gameObject);
        }
    }
}
