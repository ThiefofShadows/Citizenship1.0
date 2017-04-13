using System.Collections;
using System.Collections.Generic;

public class characterClass
{
    private string id;
    public string ID
    {
        get
        {
            return id;
        }
    }

    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    private char pronouns;
    public char Pronouns
    {
        get
        {
            return pronouns;
        }
        set
        {
            pronouns = value;
        }
    }

    private string status;
    public string Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }

    private string bio;
    public string Bio
    {
        get
        {
            return bio;
        }
        set
        {
            bio = value;
        }
    }


    public characterClass()
    {
        id = "15514803";
        name = id;
        pronouns = 'o';
        bio = "(enter bio here)";
    }

    public characterClass(string newID, string newCharacterName, char newPronouns, string newBio)
    {
        id = newID;
        name = newCharacterName;
        pronouns = newPronouns;
        bio = newBio;
    }
}
