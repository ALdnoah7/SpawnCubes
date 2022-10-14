using UnityEngine;

public class ExitHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();
    }
}
