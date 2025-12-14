using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private PlayerInputActions input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = new PlayerInputActions();
		input.Menu.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Menu.StartGame.IsPressed())
        {
            SceneManager.LoadScene(1); // load the gameplay scene
            input.Menu.Disable();
        }
    }
}
