using System;
using MelonLoader;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using VRGear.Attributes;
using VRGear.Attributes.Log;

namespace VRGear.Utils
{
    public class Logger
    {
        private static Logger _instance;
        private readonly MelonLogger.Instance _logger;
        private readonly bool _isPriorityMode;

        private Logger()
        {
            _logger = new MelonLogger.Instance(nameof(VRGear), ConsoleColor.White);
            Console.Title = $"{nameof(VRGear)} by Rai#3279";

            _isPriorityMode = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsClass)
                .Any(type => Attribute.IsDefined(type, typeof(PriorityLogAttribute)));
        }

        public static Logger Instance => _instance ??= new Logger();

        public void Log(object message, ConsoleColor color = ConsoleColor.White)
        {
            try
            {
                var stackFrame = new StackTrace().GetFrames()?[1];
                var declaringType = stackFrame?.GetMethod()?.DeclaringType;

                if (Attribute.IsDefined(declaringType?.GetType()!, typeof(IgnoreLogAttribute)))
                    return;

                if (_isPriorityMode)
                {
                    if (Attribute.IsDefined(declaringType?.GetType()!, typeof(PriorityLogAttribute)))
                        _logger.Msg(color, declaringType?.Name);

                    return;
                }

                _logger.Msg(color, $"[{declaringType?.Name}] {message}");
            }
            catch (Exception exception)
            {
                _logger.Msg($"Error while logging: {exception}");
            }
        }

        public void Warn(object message)
        {
            Log(message, ConsoleColor.Yellow);
        }

        public void Error(object message)
        {
            Log(message, ConsoleColor.Red);
        }
    }
}