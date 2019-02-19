using UnityEngine;
using UnityEngine.UI;

namespace BadCase
{
    public class MemoData
    {
        public string text;

        public void Save()
        {
            var repo = new PlayerPrefsMemoRepository();
            repo.Save(text);
        }

        public void Load()
        {
            var repo = new PlayerPrefsMemoRepository();
            text = repo.Load();
        }
    }

    public class PlayerPrefsMemoRepository
    {
        public void Save(string text)
        {
            PlayerPrefs.SetString("memo",text);
        }

        public string Load()
        {
            return PlayerPrefs.GetString("memo", "");
        }
    }

    public class God : MonoBehaviour
    {
        public InputField _memoInputField;
        public Button _saveButton;
        public Button _loadButton;
        public MemoData memo;

        public void Start()
        {
            memo = new MemoData();
            _saveButton.onClick.AddListener(Save);
            _loadButton.onClick.AddListener(Load);
        }

        public void Save()
        {
            memo.text = _memoInputField.text;
            memo.Save();
        }

        public void Load()
        {
            memo.Load();
            _memoInputField.text = memo.text;
        }
    }
}
