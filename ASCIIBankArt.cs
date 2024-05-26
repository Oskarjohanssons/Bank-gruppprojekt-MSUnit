using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank_gruppprojekt
{
    internal class AviciiBank
    {
        public AviciiBank()
        {

        }

        public void PaintBank()
        {
            string[] asciiArt = {
            "         _._._                       _._._",
            "        _|   |_                     _|   |_",
            "        | ... |_._._._._._._._._._._| ... |",
            "        | ||| | o THE AVICII BANK o | ||| |", 
            "        | \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |",
            "   ())  |[-|-]| [-|-]  [-|-]  [-|-] |[-|-]|  ())",
            "  (())) |     |---------------------|     | (()))",
            " (())())| \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |(())())",
            " (()))()|[-|-]|  :::   .-\"-.   :::  |[-|-]|(()))()", 
            " ()))(()|     | |-|-|  |_|_|  |-|-| |     |()))(()", 
            "    ||  |_____|_|_|_|__|_|_|__|_|_|_|_____|  ||",
            " ~ ~^^ @@@@@@@@@@@@@@/=======\\@@@@@@@@@@@@@@ ^^~ ~",
            "      ^~^~                                ~^~^"
        };
            
                
                foreach (string line in asciiArt)
                {                                        
                    string coloredLine = line.Replace(")", "\u001b[32m)\u001b[0m")
                        .Replace("@", "\u001b[32m@\u001b[0m")
                        .Replace("~", "\u001b[32m~\u001b[0m")
                        .Replace("^", "\u001b[32m^\u001b[0m")
                        .Replace("(", "\u001b[32m(\u001b[0m")
                        .Replace("THE AVICII BANK", "\u001b[36mTHE AVICII BANK\u001b[0m");
                    Console.WriteLine(coloredLine);
                    Thread.Sleep(75);
                }                                      
        }
  
        public void FadeBank()
        {
            string[] asciiArt = {
            "         _._._                       _._._",
            "        _|   |_                     _|   |_",
            "        | ... |_._._._._._._._._._._| ... |",
            "        | ||| | o THE AVICII BANK o | ||| |",
            "        | \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |",
            "   ())  |[-|-]| [-|-]  [-|-]  [-|-] |[-|-]|  ())",
            "  (())) |     |---------------------|     | (()))",
            " (())())| \"\"\" |  \"\"\"    \"\"\"    \"\"\"  | \"\"\" |(())())",
            " (()))()|[-|-]|  :::   .-\"-.   :::  |[-|-]|(()))()",
            " ()))(()|     | |~|~|  |_|_|  |~|~| |     |()))(()",
            "    ||  |_____|_|_|_|__|_|_|__|_|_|_|_____|  ||",
            " ~ ~^^ @@@@@@@@@@@@@@/=======\\@@@@@@@@@@@@@@ ^^~ ~",
            "      ^~^~                                ~^~^"
        };

            for (int frame = 0; frame <= 10; frame++) 
            {
                foreach (string line in asciiArt)
                {
                    
                    Console.WriteLine(FadeLine(line, frame));
                }

                
                Thread.Sleep(100);

                
                Console.Clear();
            }

            
        }

        static string FadeLine(string line, int frame)
        {
            
            int opacity = 10 - frame;

            
            opacity = Math.Max(0, Math.Min(10, opacity));

            
            string fadedLine = "";
            foreach (char c in line)
            {
                fadedLine += (c == ' ' || c == '\t') ? c : FadeCharacter(c, opacity);
            }

            return fadedLine;
        }

        static char FadeCharacter(char character, int opacity)
        {
            
            char[] opacityLevels = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
            int index = (opacity * (opacityLevels.Length - 1)) / 10;
            return opacityLevels[index];
        }

        public static void BankArt()
        {
            AviciiBank art = new AviciiBank();
            art.PaintBank();
        }
    }   
}
