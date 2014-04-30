using UnityEngine;
using System.Collections;

public class MouseMenuHandler : MonoBehaviour {

    public Vector3 rotation;

    void OnMouseDown() { 
        if (this.name == "PlayBT") //When the play button is clicked, you start playing
            Application.LoadLevel("Cubbart");
    
        else if (this.name == "HelpBT") //when the help button is pressed, the help screen is loaded
            Application.LoadLevel("helpScreen");

        else if (this.name == "BackBT") //when the back button is pressed the menu screen is loaded again
            Application.LoadLevel("menu");

        else if (this.name == "QuitBT") //when the quit game button is clicked, the application closes
            Application.Quit();
    }
}
