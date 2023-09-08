using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreationEmojiSlot : MonoBehaviour
{
    [SerializeField] private List<EmojiDataSO> _emojiInfo;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private EmojiSlotView _emojiSlotView;
    [SerializeField] private Transform _emojiPanel;
    [SerializeField] private Transform _nextPanel;
    [SerializeField] private UnityEvent OnPicked;

    private void Start()
    {
        foreach (var emoji in _emojiInfo)
        {
            var emojiSlot = Instantiate(_emojiSlotView, _spawnPosition);
            emojiSlot.ConfigureSlot(emoji.emojiSprite, OnPicked);
        }
    }

}
