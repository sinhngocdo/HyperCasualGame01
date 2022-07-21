using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawner : MonoBehaviour
{
    public static StairSpawner instance;
    public GameObject boxStairPrefab;

    int index = 0;
    //[SerializeField] float stairWidht = 2f, stairHeight = 0.5f;
    //[SerializeField] int minX = -5, maxX = 5;

    //List<GameObject> stairList = new List<GameObject>();

    float hue;

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
        //MakeObjects();
        MakeItColor();
        for (int i = 0; i < 5; i++)
        {
            //MakeNewStair();
            //MakeNewBoxStair();
            spawnObject();
 
        }
        InvokeRepeating("spawnObject", 0.5f, 0.5f);

    }

    void MakeItColor()
    {
        hue = Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hue, 0.6f, 0.8f);
    }

    void spawnObject()
    {
        Vector2 newPosition = new Vector2(0, index * 7);
        GameObject boxStair = Instantiate(boxStairPrefab);
        boxStair.SetActive(true);
        boxStair.transform.position = newPosition;
        boxStair.transform.rotation = Quaternion.identity;
        boxStair.transform.SetParent(transform);
        index++;
    }

    //private void MakeObjects()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {
    //        GameObject boxStair = Instantiate(boxStairPrefab);
    //        boxStair.SetActive(false);
    //        stairList.Add(boxStair);
    //    }
    //}

    //GameObject GetStair()
    //{
    //    GameObject obj = null;
    //    for (int i = 0; i < stairList.Count; i++)
    //    {
    //        if (!stairList[i].activeInHierarchy)
    //        {
    //            obj = stairList[i];
    //            return obj;
    //        }
    //    }
    //    return null;
    //}

    //public void MakeNewStair()
    //{
    //    int randomPos;
    //    if(index == 0)
    //    {
    //        randomPos = 0;
    //    }
    //    else
    //    {
    //        randomPos = Random.Range(minX, maxX);
    //    }

    //    Vector2 newPosition = new Vector2(randomPos, index * 5);
    //    GameObject stair = GetStair();//Instantiate(stairPrefab, newPosition, Quaternion.identity);
    //    stair.SetActive(true);
    //    stair.transform.position = newPosition;
    //    stair.transform.rotation = Quaternion.identity;
    //    stair.transform.SetParent(transform);
    //    stair.transform.localScale = new Vector2(stairWidht, stairHeight);
    //    SetColor(stair);
    //    index++;
    //}

    //public void MakeNewBoxStair()
    //{
    //    Vector2 newPosition = new Vector2(0, index * 5);
    //    GameObject boxStair = GetStair();
    //    boxStair.SetActive(true);
    //    boxStair.transform.position = newPosition;
    //    boxStair.transform.rotation = Quaternion.identity;
    //    boxStair.transform.SetParent(transform);
    //    index++;
    ////}


    //void SetColor(GameObject stair)
    //{
    //    if(Random.Range(0,3) != 0)
    //    {
    //        hue += 0.08f;
    //        if (hue >= 1)
    //        {
    //            hue -= 1f;
    //        }
    //    }
    //    stair.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hue, 0.6f, 0.8f);
    //}

}
