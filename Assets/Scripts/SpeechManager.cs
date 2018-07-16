using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class SpeechManager : MonoBehaviour {

    KeywordRecognizer keywordRecognizer = null;

    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    

	// Use this for initialization
	void Start () {

        keywords.Add("Reset world", () =>
        {
            this.BroadcastMessage("OnReset");
        });

        keywords.Add("Drop it", () =>
        {
            var focusObject = GazeGestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {
                focusObject.SendMessage("OnDrop", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += (args) =>
        {
            System.Action action;
            if (keywords.TryGetValue(args.text, out action))
            {
                action.Invoke();
            }
        };
        keywordRecognizer.Start();
		
	}
}
