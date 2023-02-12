using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.AI
{
	
	public class SingleResponseDisplay : MonoBehaviour
	{
		public TMP_Text tmpText;
		public float paddingTop, lineHeight, paddingBottom;
		public InteractionData interactionData;
		float height;
		public float Height{get {return height;}}
		
		void Reset()
		{
			tmpText = this.GetComponentInChildren<TMP_Text>();
			paddingTop = -tmpText.rectTransform.rect.position.y;
			lineHeight = tmpText.fontSize;
			paddingBottom = ((RectTransform)this.transform).rect.height - (paddingTop+lineHeight);
		}
		
		public void SetResponse(InteractionData data)
		{
			interactionData = data;
			SetText(interactionData.generatedText);
		}
		
		void SetText(string text)
		{
			if(text == tmpText.text)
				return;
				
			tmpText.SetText(text);
			tmpText.ForceMeshUpdate();
			
			
			Debug.Log(tmpText.textInfo.lineCount);
			
			
			height = paddingTop + 
				tmpText.textInfo.lineCount*lineHeight+
				paddingBottom;;
			((RectTransform)this.transform).SetHeight(height);
			
			//StartCoroutine(adjustOnTextSize());
			
		}
		
		IEnumerator adjustOnTextSize()
		{
			var oldInfo = tmpText.textInfo;
			Debug.Log(tmpText.textInfo.lineCount);
			
			while(oldInfo == tmpText.textInfo)
			{
				yield return new WaitForEndOfFrame();
			}
			
			Debug.Log(tmpText.textInfo.lineCount);
			
			
			height = paddingTop + 
				tmpText.textInfo.lineCount*lineHeight+
				paddingBottom;;
			((RectTransform)this.transform).SetHeight(height);
			
		}
		
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}

}