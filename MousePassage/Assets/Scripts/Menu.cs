using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject tela;

    bool menup = false;
    public bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        MenuUp();
    }

    // Update is called once per frame
    void Update()
    {
        if(menup && Input.GetKey(KeyCode.Mouse0))
        {
            MenuDown();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void MenuUp()
    {
        tela.SetActive(true);
        menup = true;
        Time.timeScale = 0f;
    }

    public void MenuDown()
    {
        tela.SetActive(false);
        menup = false;
        Time.timeScale = 1f;
        if(restart)
        {
            SceneManager.LoadScene(0);
        }
    }
}
