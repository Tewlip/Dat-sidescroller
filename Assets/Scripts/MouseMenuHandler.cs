using UnityEngine;
using System.Collections;

public class MouseMenuHandler : MonoBehaviour {

    public Vector3 rotation;

    void OnMouseDown() {
        if (this.name == "PlayBT")
        {
            Application.LoadLevel("Cubbart");
        }
        else if (this.name == "HelpBT") {
            Application.LoadLevel("helpScreen");
        }
        else if (this.name == "BackBT") {
            Application.LoadLevel("menu");
        } 
    }
}
