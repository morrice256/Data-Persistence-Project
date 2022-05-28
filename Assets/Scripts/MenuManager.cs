using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()   
    {
        
    }


    public void StartNew(){
        string username = inputField.text;
        ManagerDAta.Instance.SaveName(username);
        SceneManager.LoadScene("main");
    }

}
