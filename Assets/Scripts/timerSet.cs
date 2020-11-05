using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int time = (int)GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManagerScript>().getTimer();
        GetComponent<TMPro.TextMeshProUGUI>().text = time.ToString();
    }
}
