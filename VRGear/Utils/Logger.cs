using System;
using MelonLoader;
using System.Diagnostics;

namespace VRGear.Utils
{
    public class Logger
    {
        private static Logger _instance;
        private readonly MelonLogger.Instance _logger;

        private Logger()
        {
            _logger = new MelonLogger.Instance(nameof(VRGear), ConsoleColor.White);
            Console.Title = $"{nameof(VRGear)} by Rai#3279";
        }

        public static Logger Instance => _instance ??= new Logger();

        public void Log(object message, ConsoleColor color = ConsoleColor.White)
        {
            try
            {
                _logger.Msg(color, $"[{new StackTrace().GetFrames()?[1].GetMethod()?.DeclaringType?.Name}] {message}");
            }
            catch (Exception exception)
            {
                Error($"Error while logging: {exception}");
            }
        }

        public void Warn(object message)
        {
            try
            {
                _logger.Msg(ConsoleColor.Yellow, $"[{new StackTrace().GetFrames()?[1].GetMethod()?.DeclaringType?.Name}] {message}");
            }
            catch (Exception exception)
            {
                Error($"Error while logging: {exception}");
            }
        }

        public void Error(object message)
        {
            try
            {
                _logger.Msg(ConsoleColor.Red, $"[{new StackTrace().GetFrames()?[1].GetMethod()?.DeclaringType?.Name}] {message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error while handling error: {exception}");
            }
        }
    }
}