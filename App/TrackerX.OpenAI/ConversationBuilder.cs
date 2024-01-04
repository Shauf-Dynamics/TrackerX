using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace TrackerX.OpenAI
{
    internal static class ConversationBuilder
    {
        private static Model OpenAIMode = Model.ChatGPTTurbo;
        private static double Temperature = 0;

        internal static Conversation Build(IConfiguration config)
        {
            var apiToken = config["OpenAI:ApiToken"];
            var api = new OpenAIAPI(new APIAuthentication(apiToken));

            Conversation chat = api.Chat.CreateConversation();
            chat.Model = OpenAIMode;
            chat.RequestParameters.Temperature = Temperature;

            return chat;
        }
    }
}
