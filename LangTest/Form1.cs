using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Synthesis;
using Microsoft.Speech.Recognition;

namespace LangTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = new CultureInfo("de-de");
            SpeechRecognitionEngine speechRecognitionEngine = new SpeechRecognitionEngine(cultureInfo);
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            //Choices choices = new Choices("Привет");
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Culture = cultureInfo;
            grammarBuilder.Append("Gute");
            Grammar grammar = new Grammar(grammarBuilder);
            speechRecognitionEngine.LoadGrammar(grammar);
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.Invoke((MethodInvoker)(delegate { this.BackColor = Color.Red; }));
        }
    }
}
