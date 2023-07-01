using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Emoji", menuName = "Emoji Data")]
public class EmojiDataSO : ScriptableObject
{
    public Sprite emojiSprite;
    public int value;
    public string emojiName;
}
