using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerX.OpenAI;

class Program
{
    public async static Task Main()
    {
        var chat = ConversationBuilder.Build(null);

        chat.AppendSystemMessage("This conversation is about music." +
            "User will request certain information." +
            "This information should be responded as a list. " +
            "Any additional text should be droped.");
        
        chat.AppendUserInput("List top 10 'Deep Purple' songs along with albums each song belongs. Add bpm for each song if possible");

        await chat.StreamResponseFromChatbotAsync(res =>
        {
            try
            {
                Console.Write(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }               
        });

        Console.ReadKey();
    }
}   
