using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChange : MonoBehaviour
{

	public void buttonClick (string sceneName)
    {
        //System.Threading.Thread.Sleep(5000); //5 second wait
        Application.LoadLevel(sceneName);
    }

}
