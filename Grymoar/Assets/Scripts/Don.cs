using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Don : MonoBehaviour {

    public static Don dons;

    private void Awake()
    {
        if (dons)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            dons = this;
        }
    }
}
