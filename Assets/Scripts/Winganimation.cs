using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winganimation : MonoBehaviour
{
    public float countdown=1f;
    public float delay=1f;
    public PlayMode swing;                              //animation of wings
    
    void Update()
    {
        countdown-=Time.deltaTime;
        if(countdown<=0)                                //plays animation of countdown reaches to 0, then sets back to delay
        {   
            GetComponent<Animation>().Play(swing);
            countdown=delay;
        }
    }
}
