using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExitGames.Client.Photon;
using Photon.Realtime;
using VRGear.Attributes;

namespace VRGear.Utils
{
    public class ModuleManager
    {
        private readonly IReadOnlyList<Module> _modules;

        public ModuleManager()
        {
            _modules = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.IsSubclassOf(typeof(Module)))
                .Where(type => type.GetCustomAttribute<DontLoadAttribute>() == null)
                .OrderBy(type => type.GetCustomAttribute<LoadOrder>()?.Order ?? 0)
                .Select(ActivateModule)
                .ToList();
        }

        public IEnumerable<object> Modules => _modules;

        private Module ActivateModule(Type module)
        {
            Logger.Instance.Log($"Loaded [{module.Name}]", ConsoleColor.Green);
            return Activator.CreateInstance(module) as Module;
        }

        public void UiInit()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].UiInit();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void Update()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].Update();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void LateUpdate()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].LateUpdate();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void OnEvent(EventData eventData)
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].OnEvent(eventData);
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }
        
        public void Save()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].Save();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void Load()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].Load();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void PlayerJoin(VRC.Player player)
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].PlayerJoin(player);
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }

        public void PlayerLeft(VRC.Player player)
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].PlayerLeft(player);
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }
        
        public void Quit()
        {
            for (var i = 0; i < _modules.Count; i++)
            {
                try
                {
                    _modules[i].Quit();
                }
                catch (Exception exception)
                {
                    Logger.Instance.Error($"Error while handling module {_modules[i].GetType().Name}: {exception}");
                }
            }
        }
    }
}