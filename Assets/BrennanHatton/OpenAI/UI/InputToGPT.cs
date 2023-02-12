using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{

	public class InputToGPT : MonoBehaviour
	{
		public GPT3 gpt;
		public TMP_InputField input;
		public TextAsset[] prePromptText, postPromptText;
		public string prePrompt, postPrompt;
		
		void Reset()
		{
			input = this.GetComponentInChildren<TMP_InputField>();
			gpt = GameObject.FindObjectOfType<GPT3>();
		}
		
		public void AskGPT()
		{
			string prompt = "";
			
			for(int i = 0; i < prePromptText.Length; i++)
				prompt += prePromptText[i].text;
			
			prompt = prePrompt + input.text + postPrompt;
			
			
			for(int i = 0; i < prePromptText.Length; i++)
				prompt += postPromptText[i].text;
			gpt.Execute(prompt);
		}
	}

}