namespace PrisonBreak.Scripts.SceneControl
{
    using UnityEngine;

    public class SceneControl : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Application.Quit();
            }
        }
    }
}