using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITestTest : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        text.transform.position = namePos;
    }
}
