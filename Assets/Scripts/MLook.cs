using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MLook : MonoBehaviour                                                  //stands for Mouse Look, but in general, a script for player's look perspective
{
    public float mouseSensitivity =100f;                                            //how fast player looks
    public Transform playerBody;                                                    //player that is 'looking'
    float xRotation=0f;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("currentSensitivity", 4000);
        slider.value = mouseSensitivity / 10;
        Cursor.lockState=CursorLockMode.Locked;                                     //locks cursor
		Cursor.visible=false;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", mouseSensitivity);               //updates current sensitivity
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;      //can look left and right
        float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;      //can look up and down

        xRotation-=mouseY;                                                          //moving mouse changings look position
        xRotation=Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation=Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up*mouseX);
    }
    public void AdjustSense(float newSense)                                         //Updates Sensitivity
    { 
        mouseSensitivity = newSense * 10;
    }
}
