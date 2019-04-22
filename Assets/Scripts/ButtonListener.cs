using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonListener : MonoBehaviour {
    public Transform positionVectorHome;
    public GameObject tempObjectHome;
    public Button createHome;

    public Transform positionVectorChurch;
    public GameObject tempObjectChurch;
    public Button createChurch;
    // public int controller = globala.controller;
    public int controllerbuttonclicked = 0;

    private GameObject cloneHome;
    private GameObject cloneChurch;
    private int objectID = -1;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        createHome.onClick.AddListener(TaskOnClick);
        createChurch.onClick.AddListener(TaskOnClick2);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        GlobalVariables.controller = 0;
        objectID = 0;
        Debug.Log(createHome.GetComponentInChildren<Text>().text);
    }
    void TaskOnClick2()
    {
        //Output this to console when Button1 or Button3 is clicked
        GlobalVariables.controller = 0;
        objectID = 1;
        Debug.Log(createChurch.GetComponentInChildren<Text>().text);
    }

    void Update()
    {
        if (GlobalVariables.controller == 0 && !GlobalVariables.buttonActive)
        {
            if (objectID == 0)
            {
                cloneHome = Instantiate(tempObjectHome, positionVectorHome.position, positionVectorHome.rotation);
                GlobalVariables.controller = 1;
                GlobalVariables.buttonActive = true;
            }
            else if (objectID == 1)
            {
                cloneChurch = Instantiate(tempObjectChurch, positionVectorChurch.position, positionVectorChurch.rotation);
                GlobalVariables.controller = 1;
                GlobalVariables.buttonActive = true;
            }

        }

    }
}