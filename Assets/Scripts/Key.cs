using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    public void collect()           //collecting key makes object disappear along with its corresponding door
    {
        Destroy(gameObject);
    }
}
