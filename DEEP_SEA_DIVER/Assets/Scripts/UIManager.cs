using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UnityEngine.UI.Image O2Gage;
    public static UIManager instance;
    public UnityEngine.UI.Image[] items = new UnityEngine.UI.Image[3];
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SetPercent(float a)
    {
        O2Gage.fillAmount = a / 100;
    }

    // public void Initialized()
    // {
    //     for(int i = 0; i < items.Length; i++)
    //     {
    //         items[i].C
    //     }
    // }

    public void setImage(GameObject item, int index)
    {
        Item item1 = item.GetComponent<Item>();
        items[index].sprite = item1.sprite;
    }
}
