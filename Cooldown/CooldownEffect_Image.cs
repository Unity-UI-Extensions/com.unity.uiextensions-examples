/// Credit SimonDarksideJ
/// Sourced from my head

namespace UnityEngine.UI.Extensions.Examples
{
    [RequireComponent(typeof(Image))]
    public class CooldownEffect_Image : MonoBehaviour
    {
        public CooldownButton coolDown;
        public TMPro.TMP_Text displayText;
        private Image target;

        string originalText;

        // Use this for initialization
        void Start()
        {
            if (coolDown == null)
            {
                Debug.LogError("Missing CoolDown Button assignment");
            }
            target = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            target.fillAmount = Mathf.Lerp(0, 1, coolDown.CooldownTimeRemaining / coolDown.CooldownTimeout);
            if (displayText)
            {
                displayText.text = string.Format("{0}%", coolDown.CooldownPercentComplete);
            }
        }

        private void OnDisable()
        {
            if (displayText)
            {
                displayText.text = originalText;
            }
        }

        private void OnEnable()
        {
            if (displayText)
            {
                originalText = displayText.text;
            }
        }


    }
}