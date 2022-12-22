using UnityEngine;

public class SelectorScript : MonoBehaviour
{
    public GameObject Cube, Sphere, Capsule, Cylinder;
    public static Material purpleMat, blueMat, lightBlueMat, greenMat, yellowMat, orangeMat, redMat, pinkMat;
    private GameObject[] players = new GameObject[4];
    private Material[] materials = new Material[8];
    private Material tempMaterial;
    private int character = 1;
    private int characterPos = 0;
    private int color = 1;

    public void Awake()
    {
        Cube.SetActive(true);
        Sphere.SetActive(false);
        Capsule.SetActive(false);
        Cylinder.SetActive(false);
        Cube.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
        players[0] = Cube;
        players[1] = Sphere;
        players[2] = Capsule;
        players[3] = Cylinder;
        materials[0] = purpleMat;
        materials[1] = blueMat;
        materials[2] = lightBlueMat;
        materials[3] = greenMat;
        materials[4] = yellowMat;
        materials[5] = orangeMat;
        materials[6] = redMat;
        materials[7] = pinkMat;
    }

    public void nextCharacter()
    {
        switch(character)
        {
            case 1:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos++;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character++;
                break;
            case 2:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos++;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character++;
                break;
            case 3:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos++;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character++;
                break;
            case 4:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos++;
                resetCharacterPosInt();
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character++;
                resetCharacterInt();
                break;
            default:
                resetCharacterPosInt();
                resetCharacterInt();
                break;
        }
    }

    public void previousCharacter()
    {
        switch(character)
        {
            case 1:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos--;
                resetCharacterPosInt();
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character--;
                resetCharacterInt();
                break;
            case 2:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos--;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character--;
                break;
            case 3:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos--;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character--;
                break;
            case 4:
                players[characterPos].SetActive(false);
                tempMaterial = players[characterPos].GetComponent<Renderer>().material;
                characterPos--;
                players[characterPos].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 4));
                players[characterPos].GetComponent<Renderer>().material = tempMaterial;
                players[characterPos].SetActive(true);
                character--;
                break;
            default:
                resetCharacterPosInt();
                resetCharacterInt();
                break;
        }
    }

    public void nextColor()
    {
        switch(color)
        {
            case 1:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/BlueMat", typeof(Material)) as Material;
                color++;
                break;
            case 2:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/LightBlueMat", typeof(Material)) as Material;
                color++;
                break;
            case 3:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/GreenMat", typeof(Material)) as Material;
                color++;
                break;
            case 4:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/YellowMat", typeof(Material)) as Material;
                color++;
                break;
            case 5:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/OrangeMat", typeof(Material)) as Material;
                color++;
                break;
            case 6:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/RedMat", typeof(Material)) as Material;
                color++;
                break;
            case 7:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/PinkMat", typeof(Material)) as Material;
                color++;
                break;
            case 8:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/PurpleMat", typeof(Material)) as Material;
                color++;
                resetColorInt();
                break;
            default:
                resetColorInt();
                break;
        }
    }

    public void previousColor()
    {
        switch(color)
        {
            case 1:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/PinkMat", typeof(Material)) as Material;
                color--;
                resetColorInt();
                break;
            case 2:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/PurpleMat", typeof(Material)) as Material;
                color--;
                break;
            case 3:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/BlueMat", typeof(Material)) as Material;
                color--;
                break;
            case 4:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/LightBlueMat", typeof(Material)) as Material;
                color--;
                break;
            case 5:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/GreenMat", typeof(Material)) as Material;
                color--;
                break;
            case 6:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/YellowMat", typeof(Material)) as Material;
                color--;
                break;
            case 7:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/OrangeMat", typeof(Material)) as Material;
                color--;
                break;
            case 8:
                players[characterPos].GetComponent<Renderer>().material = Resources.Load("Materials/RedMat", typeof(Material)) as Material;
                color--;
                break;
            default:
                resetColorInt();
                break;
        }
    }

    private void resetCharacterInt()
    {
        if(character >= 4)
        {
            character = 1;
        }
        else
        {
            character = 4;
        }
    }

    private void resetCharacterPosInt()
    {
        if(characterPos >= 3)
        {
            characterPos = 0;
        }
        else
        {
            characterPos = 3;
        }
    }

    private void resetColorInt()
    {
        if(color >= 8)
        {
            color = 1;
        }
        else
        {
            color = 8;
        }
    }

    public void FixedUpdate()
    {
        Cube.transform.Rotate(.4f, .2f, -.8f);
        Sphere.transform.Rotate(.4f, .2f, -.8f);
        Capsule.transform.Rotate(.4f, .2f, -.8f);
        Cylinder.transform.Rotate(.4f, .2f, -.8f);
    }
}
