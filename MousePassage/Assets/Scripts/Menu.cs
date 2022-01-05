using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject tela;

    private bool menup = false;
    public bool restart = false;

    public float timer = 60;
    public GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MenuUp();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (menup)
        {
            #region Flash text
            timer--;

            if (timer <= 0)
            {
                FlipTextVisibility();
                timer = 60;
            }
            #endregion

            if (Input.anyKeyDown)
            {
                MenuDown();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    #region Menu management
    public void MenuUp()
    {
        if (tela == null)
            return;

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
            SceneManager.LoadScene(1);
        }
    }
    #endregion

    private void FlipTextVisibility()
    {
        if(texto.activeSelf)
        {
            texto.SetActive(false);
        }
        else
        {
            texto.SetActive(true);
        }
    }
}
