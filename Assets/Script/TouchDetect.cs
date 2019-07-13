using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetect : MonoBehaviour {
    
    public GameObject ballRegion1, ballRegion2, ballRegion3, ballRegion4, ballRegion5, ballRegion6, ballRegion7, ballRegion8;
    private Dictionary<int, GameObject> regionMap = new Dictionary<int, GameObject>();
    private static bool[] regionCheck;
    public GameObject stick;
    public static float stickDelayTime;
    private bool isPaused;

    // Use this for initialization
    void Start()
    {
        regionMap.Add(1, ballRegion1);
        regionMap.Add(2, ballRegion2);
        regionMap.Add(3, ballRegion3);
        regionMap.Add(4, ballRegion4);
        regionMap.Add(5, ballRegion5);
        regionMap.Add(6, ballRegion6);
        regionMap.Add(7, ballRegion7);
        regionMap.Add(8, ballRegion8);
        regionCheck = new bool[9];
        stickDelayTime = 1f;
    }

    // Update is called once per frame
    void Update () {
        if (isPaused) return;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);
            int devX = Screen.width;
            int devY = Screen.height;
            int x = (int) touch.position.x;
            int y = (int) touch.position.y;
            int regionNumber = getRegionNumber(x, y, devX, devY);
            if (regionNumber == -1) return;
            if (regionCheck[regionNumber]) return;
            Instantiate(stick, regionMap[regionNumber].transform.position, regionMap[regionNumber].transform.rotation);
            StartCoroutine(startDelay(regionNumber));
        }
    }

    private int getRegionNumber(int x, int y, int min, int max)
    {
        x = x - min / 2;
        y = y - max / 2;

        if (Math.Abs(x) > min / 2 || Math.Abs(y) > min / 2) return -1;

        if (y > 0)
        {
            if (x > 0)
            {
                if (x > y) return 3;
                else return 2;
            }
            else
            {
                if (-x > y) return 8;
                else return 1;
            }
        }
        else
        {
            if (x > 0)
            {
                if (x > -y) return 4;
                else return 5;
            }
            else
            {
                if (-x > -y) return 7;
                else return 6;
            }

        }
    }

    IEnumerator startDelay(int regionNumber)
    {
        regionCheck[regionNumber] = true;
        Color tmp = regionMap[regionNumber].GetComponent<SpriteRenderer>().color;
        tmp.a = 0.2f;
        regionMap[regionNumber].GetComponent<SpriteRenderer>().color = tmp;
        yield return new WaitForSeconds(stickDelayTime);
        tmp.a = 1f;
        regionMap[regionNumber].GetComponent<SpriteRenderer>().color = tmp;
        regionCheck[regionNumber] = false;
    }

    public void setPaused(bool set)
    {
        isPaused = set;
    }

}
