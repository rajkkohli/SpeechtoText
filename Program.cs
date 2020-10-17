using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Threading;
using System.Speech.Synthesis;

namespace speechtotext
{
    class Program
    {
        //variable declaration for speaking text
       static SpeechSynthesizer sythesizer ;

        static void Main(string[] args)
        {
            SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            recEngine.SetInputToDefaultAudioDevice();

            sythesizer = new SpeechSynthesizer();

            Choices pizzacommands = new Choices();
            Console.WriteLine("Please select a Pizza serial number to order the pizza...");
            Console.WriteLine(" 1. Margherita \n 2. Calzone \n 3. Stromboli");
            pizzacommands.Add(new string[] { "One"
                ,"Two"
                ,"Three"
            });

            sythesizer.Speak("Please select a Pizza serial number to order the pizza. One for Margherita, Two for Calzone and Three for Stromboli");
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(pizzacommands);
            Grammar g = new Grammar(gb);
            recEngine.LoadGrammarAsync(g);


            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

            //will accept multiple times values
            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            //will hold the app to run for infinite times otherwise application will start and stop immediately
             while(true);
        }

        // Create a simple handler for the SpeechRecognized event
        static void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Speech recognized: {0}", e.Result.Text);

            sythesizer = new SpeechSynthesizer();
            
            switch (e.Result.Text)
            {
                case "One":
                    Console.WriteLine("You ordered Margherita Pizaa and your amount to pay is " + "$7, Thank you.");
                    sythesizer.Speak("You ordered Margherita Pizaa and your amount to pay is " + "$7, Thank you.");
                    break;
                case "Two":
                    Console.WriteLine("You ordered Calzone Pizaa and your amount to pay is " + "$9, Thank you.");
                    sythesizer.Speak("You ordered Calzone Pizaa and your amount to pay is " + "$9, Thank you.");
                    break;

                case "Three":
                    Console.WriteLine("You ordered Stromboli Pizaa and your amount to pay is " + "$10, Thank you.");
                    sythesizer.Speak("You ordered Stromboli Pizaa and your amount to pay is " + "$10, Thank you.");
                    break;
                default:
                    break;
            }
        }

            
        }
}
