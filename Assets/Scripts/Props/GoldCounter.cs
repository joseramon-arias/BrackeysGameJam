using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    private int goldCount = 0;
    public int GoldCount
    {
        get { return goldCount; }
        set { goldCount = value; }
    }
    [SerializeField] TMPro.TextMeshProUGUI goldCountText;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    public void AddGold()
    {
        GoldCount += 1;
        goldCountText.text = $"Gold: {GoldCount}";
    }
}
