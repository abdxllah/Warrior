

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAIParametersLoader : MonoBehaviour
{
    public OpenAIParameters openAIParameters;

    void Awake()
    {
        TextAsset json = Resources.Load<TextAsset>("OpenAIParameters");
        openAIParameters = JsonUtility.FromJson<OpenAIParameters>(json.text);
    }
}