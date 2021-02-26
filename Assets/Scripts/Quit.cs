using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Quit").GetComponent<Button>();
        btn.onClick.AddListener(delegate { QuitGame(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
