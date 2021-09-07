﻿using System.Threading.Tasks;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Quickstart.AspNetCore.Handlers
{
    public class PingCommand : CommandBase
    {
        public PingCommand() : base("ping")
        {
        }
        
        protected override async Task HandleAsync(IUpdateContext context, UpdateDelegate next, string[] args)
        {
            var msg = context.Update.Message;

            await context.Bot.Client.SendTextMessageAsync(
                msg.Chat,
                "*PONG*",
                ParseMode.Markdown,
                replyToMessageId: msg.MessageId,
                replyMarkup: new InlineKeyboardMarkup(
                    InlineKeyboardButton.WithCallbackData("Ping", "PONG")
                )
            );
        }

        
    }
}