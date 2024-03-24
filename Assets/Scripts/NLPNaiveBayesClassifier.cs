using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Voxell;
using Voxell.Inspector;
using Voxell.NLP;
using Voxell.NLP.Classifier;
using Voxell.NLP.Tokenize;
using Voxell.NLP.PosTagger;
using Voxell.NLP.Stem;

//script to handle naivebayes classifier

public class NLPNaiveBayesClassifier : MonoBehaviour
{
  public ClassifyOptions classifyOptions;
  [StreamingAssetFilePath] public string tokenizerModel;
  [StreamingAssetFilePath] public string posTaggerModel;
  [StreamingAssetFilePath] public string tagDict;

  public TextAsset dataset;
  public List<Sentence> sentences;
  public List<string> vocabs;
  public string sentenceToClassify;
  [InspectOnly] public string classifiedLabel;
  [InspectOnly] public double highestConfidence;
  public bool classified = false;
  public OpenAINPC openai;

  private NaiveBayesClassifier classifier;
  private EnglishMaximumEntropyTokenizer tokenizer;
  private EnglishMaximumEntropyPosTagger posTagger;
  private RegexStemmer stemmer;


  public void InitializeData()
  {
    // reset data
    sentences.Clear();
    sentences.TrimExcess();
    classifyOptions.labels.Clear();
    classifyOptions.labels.TrimExcess();

    // create tokenizer, pos tagger, and stemmer
    tokenizer = new EnglishMaximumEntropyTokenizer(FileUtilx.GetStreamingAssetFilePath(tokenizerModel));
    posTagger = new EnglishMaximumEntropyPosTagger(
      FileUtilx.GetStreamingAssetFilePath(posTaggerModel),
      FileUtilx.GetStreamingAssetFilePath(tagDict));
    stemmer = new RegexStemmer();
    stemmer.CreatePattern();

    // generate data
    var data = JsonConvert.DeserializeObject<JObject>(dataset.text);
    JToken intents = data["intents"];
    foreach (JToken intent in intents)
      classifyOptions.AddLabel((string)intent["intent"]);

    foreach (JToken intent in intents)
    {
      // convert each sentences into a Sentence class and add it into the list
      foreach (JToken text in intent["text"])
        sentences.Add(new Sentence(
          ((string)text).ToLower(),
          (string)intent["intent"],
          tokenizer, posTagger, stemmer
        ));
    }
  }

  [Button]
  public void TrainClassifier()
  {
    InitializeData();
    // train and save the model
    classifier = new NaiveBayesClassifier();
    classifier.Train(sentences, classifyOptions);
    classifier.SaveModel(classifyOptions);
  }

//method to read the inputfield
 public void ReadStringInput(string s)
    {
        sentenceToClassify = s;
        
    }

//method to wait if using online classifier
IEnumerator<object> Wait(){
  string stringToClassify = "";
   if (SettingsVariables.onlineClassifier){
     // openai.DoApiCompletionClassifier("The following is a list of categories and which categories sentences are classified into: \n\nagree, disagree, anger, threaten, apologise, thank, expresshappiness, expresssadness, question, comfort, resolve, inappropriate, dontunderstand. \n\nSentence: " + sentenceToClassify + "\n\n Category: ");
      openai.DoApiCompletionClassifier("Answer the following question in one word. The following sentence is going to be classified in one of these categories: agree, disagree, apologise, thank, expresshappiness, expresssadness, question, inappropriate, dontunderstand. The sentence "+ sentenceToClassify+ " would be classified as");
      
      yield return new WaitUntil(() => openai.result != "");
      stringToClassify = openai.result;
      Debug.Log(stringToClassify);
    } else{
      stringToClassify = sentenceToClassify;
    }

    // convert string sentence to Sentence class
    Sentence sent = new Sentence(stringToClassify.ToLower(), "", tokenizer, posTagger, stemmer);
    classifier = new NaiveBayesClassifier();
    classifier.LoadModel(classifyOptions);

    // take a look at all the vocabs that the classifier stored
    vocabs = classifier.words;
    List<Tuple<string, double>> result = classifier.Classify(sent, classifyOptions);

    classifiedLabel = "";
    highestConfidence = 0.0;
    for (int r=0; r < result.Count; r++)
    {
      if (result[r].Item2 > highestConfidence)
      {
        classifiedLabel = result[r].Item1;
        highestConfidence = result[r].Item2;
      }
    }
    classified = true;
    Debug.Log(classifiedLabel);
}

  [Button]
  public void Classify()
  {
    if (tokenizer == null)
    {
      // recreate tokenizer, pos tagger, and stemmer if editor is being refreshed
      tokenizer = new EnglishMaximumEntropyTokenizer(FileUtilx.GetStreamingAssetFilePath(tokenizerModel));
      posTagger = new EnglishMaximumEntropyPosTagger(
        FileUtilx.GetStreamingAssetFilePath(posTaggerModel),
        FileUtilx.GetStreamingAssetFilePath(tagDict));
      stemmer = new RegexStemmer();
      stemmer.CreatePattern();
    }

    
    
    StartCoroutine(Wait());
  }



}
