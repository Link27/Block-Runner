using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickNextLevel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string nextLevelScene;

    // When "Next Level?" is hovered over, the text will change and the text will get slightly
    // smaller to help indicate you have hovered over it
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Transform>().localScale = new Vector3(.95f, .95f, 1);
    }

    // Reverts back when you are no longer hovering over "Next Level?"
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
    }

    // This will take the user to the next nevel when clicked
    public void nextLevel()
    {
        SceneManager.LoadScene(nextLevelScene);
    }
}
