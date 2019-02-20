namespace PrisonBreak.Scripts.Web
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using SimpleJSON;
    using UnityEngine.UI;
    using PrisonBreak.Scripts.Interactables;

    public class ChuckNorrisJokeSetup : MonoBehaviour
    {
        [SerializeField]
        private InputField _inputField;

        [SerializeField]
        private Door _door;

        private string rsp;

        IEnumerator GetRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)
                {
                    Debug.Log(": Error: " + webRequest.error);
                }
                else
                {
                    var data = JSON.Parse(webRequest.downloadHandler.text);
                    rsp = data["value"]["joke"];
                    GetComponent<Text>().text = rsp;
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GetRequest("http://api.icndb.com/jokes/random?limitTo=[nerdy]"));
        }

        private void Update()
        {
            if (_inputField.text == rsp)
            {
                _door.OpenSpecialDoor();
                _inputField.text = "Door is open";
            }
        }
    }
}