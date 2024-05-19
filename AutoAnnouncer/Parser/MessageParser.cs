using BloodyNotify.AutoAnnouncer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BloodyNotify.AutoAnnouncer.Parser
{
    public class MessageParser
    {
        public IEnumerable<AutoAnnouncerMessage> Parse(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                yield break;
            }

            var messages = JsonSerializer.Deserialize<string[][]>(content);

            foreach (string[] lines in messages)
            {

                var message = new AutoAnnouncerMessage();

                foreach (var line in lines)
                {
                    message.MessageLines.Add(line); 
                }

                yield return message;
            }
        }
    }
}
