﻿using System;
using System.Threading.Tasks;
using Telegram.Bot.Abstractions;

namespace Quickstart.Net45.Handlers
{
    public class ExceptionHandler : IUpdateHandler
    {
        public bool CanHandle(IBot bot, IUpdateContext context) =>
            context.Update.Message != null;

        public async Task HandleAsync(IBot bot, IUpdateContext context, UpdateDelegate next)
        {
            var u = context.Update;

            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occured in handling update {0}.{1}{2}", u.Id, Environment.NewLine, e);
                Console.ResetColor();
            }
        }
    }
}