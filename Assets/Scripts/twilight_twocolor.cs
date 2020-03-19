using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twilight_twocolor : MonoBehaviour
{
    // pass colors to shader for a two-color gradient
    public Material gradient;

    // Start is called before the first frame update
    void Start()
    {
        gradient.SetColor("_Color0", new Color32(255, 157, 0, 1));
        gradient.SetColor("_Color1", new Color32(25, 53, 193, 1));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
