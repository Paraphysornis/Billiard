using UnityEngine;

public class GameManager : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 40), "RESET"))
        {
            FindObjectOfType<BallController>().OnResetButtonClicked();
        }
    }
}
