using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//using UnityEditor;
//using System.Text;
using System.IO; //stream reader
using System.Text.RegularExpressions; //Regex
using UnityEditor.SceneManagement; //EditorSceneManager

public class DialogueParser : MonoBehaviour {

    struct DialogueLine
    {
        public string name; //name of person taling
        public string content; //content
        public int pose;
        public string position; //left or right
        public string[] options;

        public DialogueLine(string Name, string Content, int Pose, string Position)
        {
            name = Name;
            content = Content;
            pose = Pose;
            position = Position;
            options = new string[0];
        }
    }

    List<DialogueLine> lines; //stores the diferent lines of dialogue

    // Use this for initialization
    void Start () {
        // dynamicaly getting dialogue file (not sure how works, ask steve)
        string file = "Assets/Data/Dialogue";
        string sceneNum = EditorSceneManager.GetActiveScene().name;
        sceneNum = Regex.Replace(sceneNum, "[^0-9]", ""); 
        file += sceneNum;
        file += ".txt";

        lines = new List<DialogueLine>(); //new Dialogueline list called lines

        LoadDialogue(file);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadDialogue(string filename)
    {
        string line;
        StreamReader r = new StreamReader(filename); //creates stream reader r

        using (r)
        {
            do
            {
                line = r.ReadLine(); //reads a line from file
                if (line != null)
                {
                    string[] lineData = line.Split(';'); //splits the line into different strings based upon where the ; is
                    if (lineData[0] == "Player")
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0, "");
                        lineEntry.options = new string[lineData.Length - 1];
                        for (int i = 1; i < lineData.Length; i++)
                        {
                            lineEntry.options[i - 1] = lineData[i];
                        }
                        lines.Add(lineEntry);
                    }
                    else
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3]);
                        lines.Add(lineEntry);
                    }
                }
            }
            while (line != null);
            r.Close(); //closes the stream
        }
    }
}
