﻿using Arma.Studio.Data;
using Arma.Studio.Data.Dockable;
using Arma.Studio.Data.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arma.Studio.LocalsWindow
{
    public class PluginMain : IPlugin, IDockableProvider
    {
        #region IPlugin
        public Version Version => new Version(1, 0, 0, 0);
        public string Name => Properties.Language.LocalsWindow_Name;
        public Task<IUpdateInfo> CheckForUpdate(CancellationToken cancellationToken) => Task.Run(() => default(IUpdateInfo));
        public Task Initialize(string pluginPath, CancellationToken cancellationToken) => Task.CompletedTask;
        #endregion
        #region IDockableProvider
        public IEnumerable<DockableInfo> Dockables => new DockableInfo[] {
            DockableInfo.Create(Properties.Language.LocalsWindow, ECreationMode.Anchorable, () => new LocalsWindowDataContext())
        };
        public void AddDataTemplates(GenericDataTemplateSelector selector)
        {
            selector.AddAllDataTemplatesInAssembly(typeof(PluginMain).Assembly, (s) => s.StartsWith("Arma.Studio.LocalsWindow"));
        }
        #endregion
    }
}