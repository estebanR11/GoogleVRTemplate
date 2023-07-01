using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EmojiCarrousel : MonoBehaviour
{
    [SerializeField] EmojiDataSO[] emojis;

    [SerializeField] Image leftImage;
    [SerializeField] Image midImage;
    [SerializeField] Image rightImage;
    [SerializeField] TextMeshProUGUI actualEmojiName;

    [SerializeField]int actualEmojiIndex;
    [SerializeField]int beforeEmojiIndex;
    [SerializeField]int afterEmojiIndex;

    private void Start()
    {
        actualEmojiIndex = 0;
        UpdateEmoji(actualEmojiIndex);
        
    }

    public void UpdateEmoji(int newNumber)
    {
        actualEmojiIndex += newNumber; 
        if (actualEmojiIndex < 0)
        {
            actualEmojiIndex = emojis.Length - 1;
        }
        else if (actualEmojiIndex > emojis.Length - 1)
        {
            actualEmojiIndex = 0;
        }
        afterEmojiIndex = actualEmojiIndex+1;
        beforeEmojiIndex = actualEmojiIndex-1;

        if(beforeEmojiIndex <0)
        {
            beforeEmojiIndex =emojis.Length-1;
        }
        if(afterEmojiIndex >emojis.Length-1)
        {
            afterEmojiIndex = 0;
        }


        leftImage.sprite = emojis[beforeEmojiIndex].emojiSprite;
        rightImage.sprite = emojis[afterEmojiIndex].emojiSprite;
        midImage.sprite = emojis[actualEmojiIndex].emojiSprite;
        actualEmojiName.text = emojis[actualEmojiIndex].name;

    }


    public void SendEmojiData()
    {
        GameManager.Instance.SetNewEmojiData(emojis[actualEmojiIndex]);
    }
}
