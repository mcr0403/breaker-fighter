using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSound : MonoBehaviour
{
    private static HoldSound instance;
    public static HoldSound Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        //GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        //if (musicObj.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}
        //DontDestroyOnLoad(this.gameObject);
    }
}
