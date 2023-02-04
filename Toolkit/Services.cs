﻿using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
#if VS16 || VS17
using Microsoft.VisualStudio.TaskStatusCenter;
using Microsoft.VisualStudio.TextManager.Interop;
#endif

namespace Toolkit
{
    /// <summary>
    /// A collection of services commonly used by extensions.
    /// </summary>
    public class Services
    {
        internal Services()
        { }

        #region Object Manager
        /// <summary>
        /// Performs a search for a specified object. The environment implements the interface
        /// </summary>
        public Task<IVsObjectSearch> GetFindSymbolAsync() => VS.GetRequiredServiceAsync<SVsObjectSearch, IVsObjectSearch>();
        #endregion

        /// <summary>
        /// Controls the binding between keys and commands
        /// </summary>
        public Task<IVsFilterKeys> GetFilterKeysAsync() => VS.GetRequiredServiceAsync<SVsFilterKeys, IVsFilterKeys>();

        #region Selection
        /// <summary>
        /// Provides access to the selection API.
        /// </summary>
        public Task<IVsMonitorSelection> GetMonitorSelectionAsync() => VS.GetRequiredServiceAsync<SVsShellMonitorSelection, IVsMonitorSelection>();

        /// <summary>
        /// Creates a new context or subcontext bag
        /// </summary>
        public Task<IVsMonitorUserContext> GetMonitorUserContextAsync() => VS.GetRequiredServiceAsync<SVsMonitorUserContext, IVsMonitorUserContext>();

        /// <summary>
        /// This interface is used by a package to register and un-register its library manager with the object manager
        /// </summary>
        public Task<IVsObjectManager> GetObjectManagerAsync() => VS.GetRequiredServiceAsync<SVsObjectManager, IVsObjectManager>();

        /// <summary>
        /// Used by a VSPackage to register and unregister the symbol libraries with the Visual Studio object manager and create component sets that can be browsed
        /// </summary>
        public Task<IVsObjectManager2> GetObjectManager2Async() => VS.GetRequiredServiceAsync<SVsObjectManager, IVsObjectManager2>();
        #endregion

        #region Solution
        /// <summary>
        /// Provides top-level manipulation or maintenance of the solution.
        /// </summary>
        public Task<IVsSolution> GetSolutionAsync() => VS.GetRequiredServiceAsync<SVsSolution, IVsSolution>();

        /// <summary>
        /// Opens a Solution or Project using the standard open dialog boxes.
        /// </summary>
        public Task<IVsOpenProjectOrSolutionDlg> GetOpenProjectOrSolutionDlgAsync() => VS.GetRequiredServiceAsync<SVsOpenProjectOrSolutionDlg, IVsOpenProjectOrSolutionDlg>();


        /// <summary>
        /// Gives access to the solution hierarchy and properties
        /// </summary>
        public Task<IVsHierarchy> GetSolutionHierarchyAsync() => VS.GetRequiredServiceAsync<SVsSolution, IVsHierarchy>();

        /// <summary>
        /// Gives access to the solution and properties persistence
        /// </summary>
        public Task<IVsSolutionPersistence> GetSolutionPersistenceAsync() => VS.GetRequiredServiceAsync<SVsSolutionPersistence, IVsSolutionPersistence>();
        #endregion

        #region Shell
        /// <summary>Provides access to the fundamental environment services, specifically those dealing with VSPackages and the registry.</summary>
        public Task<IVsShell> GetShellAsync() => VS.GetRequiredServiceAsync<SVsShell, IVsShell>();

        /// <summary>Provides access to extra VSPackage functionality</summary>
        public Task<IVsShell5> GetShell5Async() => VS.GetRequiredServiceAsync<SVsShell, IVsShell5>();

        /// <summary>This interface provides access to basic windowing functionality, including access to and creation of tool windows and document windows.</summary>
        public Task<IVsUIShell> GetUIShellAsync() => VS.GetRequiredServiceAsync<SVsUIShell, IVsUIShell>();

        /// <summary>This interface provides access to additional toolbar methods</summary>
        public Task<IVsUIShell4> GetUIShell4Async() => VS.GetRequiredServiceAsync<SVsUIShell, IVsUIShell4>();

        /// <summary>This interface provides access to additional theme methods and some other stuff</summary>
        public Task<IVsUIShell5> GetUIShell5Async() => VS.GetRequiredServiceAsync<SVsUIShell, IVsUIShell5>();

        /// <summary>This interface is used by a package to read command-line switches entered by the user.</summary>
        public Task<IVsAppCommandLine> GetAppCommandLineAsync() => VS.GetRequiredServiceAsync<SVsAppCommandLine, IVsAppCommandLine>();

        /// <summary>
        /// Registers well-known images (such as icons) for Visual Studio.<br/>
        /// Cast the result to <see cref="IVsImageService2"/>.
        /// </summary>
        [CastTo("Microsoft.VisualStudio.Shell.Interop.IVsImageService2")]
        public Task<object> GetImageServiceAsync() => VS.GetRequiredServiceAsync<SVsImageService, object>();

        /// <summary>Controls the caching of font and color settings.</summary>
        public Task<IVsFontAndColorCacheManager> GetFontAndColorCacheManagerAsync() => VS.GetRequiredServiceAsync<SVsFontAndColorCacheManager, IVsFontAndColorCacheManager>();

        /// <summary>Allows a VSPackage to retrieve or save font and color data to the registry.</summary>
        public Task<IVsFontAndColorStorage> GetFontAndColorStorageAsync() => VS.GetRequiredServiceAsync<SVsFontAndColorStorage, IVsFontAndColorStorage>();

        /// <summary>
        /// Controls the most recently used (MRU) items collection.<br/>
        /// Cast the result to <see cref="IVsMRUItemsStore"/>.
        /// </summary>
        [CastTo("Microsoft.VisualStudio.Shell.Interop.IVsMRUItemsStore")]
        public Task<object> GetMRUItemsStoreAsync() => VS.GetRequiredServiceAsync<SVsMRUItemsStore, object>();

        /// <summary>Used to retrieved services defined in the MEF catalog, such as the editor specific services like <see cref="IVsEditorAdaptersFactoryService"/>.</summary>
        public Task<IComponentModel2> GetComponentModelAsync() => VS.GetRequiredServiceAsync<SComponentModel, IComponentModel2>();

        /// <summary>Defines a component manager, a component that coordinates other components with its message loop for message processing and allocation of idle time</summary>
        public Task<IOleComponentManager> GetComponentManagerAsync() => VS.GetRequiredServiceAsync<SOleComponentManager, IOleComponentManager>();

        /// <summary>
        /// Manages the set of currently open documents in the environment
        /// </summary>
        public Task<IVsRunningDocumentTable> GetRunningDocumentTableAsync() => VS.GetRequiredServiceAsync<SVsRunningDocumentTable, IVsRunningDocumentTable>();

        /// <summary>
        /// Loads managed and unmanaged resources from Satellite DLLs.
        /// </summary>
        public Task<IVsResourceManager> GetResourceManagerAsync() => VS.GetRequiredServiceAsync<SVsResourceManager, IVsResourceManager>();

        /// <summary>
        /// Controls the state of open documents within the environment
        /// </summary>
        public Task<IVsUIShellOpenDocument> GetShellOpenDocumentAsync() => VS.GetRequiredServiceAsync<SVsUIShellOpenDocument, IVsUIShellOpenDocument>();

        /// <summary>
        /// Gives access to preview and viewing status
        /// </summary>
        public Task<IVsUIShellOpenDocument3> GetShellOpenDocument3Async() => VS.GetRequiredServiceAsync<SVsUIShellOpenDocument, IVsUIShellOpenDocument3>();

        /// <summary>Gives access to the task scheduler</summary>
        public Task<IVsTaskSchedulerService> GetTaskSchedulerAsync() => VS.GetRequiredServiceAsync<SVsTaskSchedulerService, IVsTaskSchedulerService>();

        /// <summary>Gives access to long idle events</summary>
        public Task<IVsLongIdleManager> GetLongIdleManagerAsync() => VS.GetRequiredServiceAsync<SVsLongIdleManager, IVsLongIdleManager>();
        #endregion

        #region Notifications
        /// <summary>Provides access to the environment's status bar.</summary>
        public Task<IVsStatusbar> GetStatusBarAsync() => VS.GetRequiredServiceAsync<SVsStatusbar, IVsStatusbar>();

        /// <summary>
        /// The <see cref="InfoBar"/> is often referred to as the 'yellow' or 'gold' bar.<br/>
        /// Cast the result to <see cref="IVsInfoBarUIFactory"/>.
        /// </summary>
        [CastTo("Microsoft.VisualStudio.Shell.Interop.IVsInfoBarUIFactory")]
        public Task<object> GetInfoBarUIFactoryAsync() => VS.GetRequiredServiceAsync<SVsInfoBarUIFactory, object>();

#if VS16 || VS17
        /// <summary>The Task Status Center is used to run background tasks and is located in the left-most side of the status bar.</summary>
        /// <remarks>This is only available for Visual Studio 2019 (16.0).</remarks>
        public Task<IVsTaskStatusCenterService> GetTaskStatusCenterAsync() => VS.GetRequiredServiceAsync<SVsTaskStatusCenterService, IVsTaskStatusCenterService>();
#endif

        /// <summary>
        /// Used for background tasks that needs to block the UI if they take longer than the specified seconds.<br/>
        /// Cast the result to <see cref="IVsThreadedWaitDialogFactory"/>.
        /// </summary>
        [CastTo("Microsoft.VisualStudio.Shell.Interop.IVsThreadedWaitDialogFactory")]
        public Task<object> GetThreadedWaitDialogAsync() => VS.GetRequiredServiceAsync<SVsThreadedWaitDialogFactory, object>();

        /// <summary>Used to write log messaged to the ActivityLog.xml file.</summary>
        public Task<IVsActivityLog> GetActivityLogAsync() => VS.GetRequiredServiceAsync<SVsActivityLog, IVsActivityLog>();
        #endregion

        #region Debugger
        /// <summary>Provides access to the current debugger so that the package can listen for debugger events.</summary>
        public Task<IVsDebugger> GetDebuggerAsync() => VS.GetRequiredServiceAsync<IVsDebugger, IVsDebugger>();

        /// <summary>Allows clients to add to the debuggable protocol list.`</summary>
        public Task<IVsDebuggableProtocol> GetDebuggableProtocolAsync() => VS.GetRequiredServiceAsync<SVsDebuggableProtocol, IVsDebuggableProtocol>();
        #endregion

        #region Commands
        /// <summary>Provides methods to manage the global designer verbs and menu commands available in design mode, and to show some types of shortcut menus.</summary>
        public Task<IMenuCommandService> GetCommandServiceAsync() => VS.GetRequiredServiceAsync<IMenuCommandService, IMenuCommandService>();

        /// <summary>Used to register and unregister a command target as a high priority command handler.</summary>
        public Task<IVsRegisterPriorityCommandTarget> GetPriorityCommandTargetAsync() => VS.GetRequiredServiceAsync<SVsRegisterPriorityCommandTarget, IVsRegisterPriorityCommandTarget>();

        /// <summary>Maps command names and GUIDs. Enables you to determine all commands and names.</summary>
        public Task<IVsCmdNameMapping> GetCommandNameMappingAsync() => VS.GetRequiredServiceAsync<SVsCmdNameMapping, IVsCmdNameMapping>();
        #endregion

        #region Build
        /// <summary>
        /// A service for handling solution builds.
        /// </summary>
        public Task<IVsSolutionBuildManager> GetSolutionBuildManagerAsync() => VS.GetRequiredServiceAsync<SVsSolutionBuildManager, IVsSolutionBuildManager>();

        /// <summary>
        /// Gets the error list 
        /// </summary>
        public Task<IVsErrorList> GetErrorListAsync() => VS.GetRequiredServiceAsync<SVsErrorList, IVsErrorList>();

        #endregion

        #region Windows
        /// <summary>Manipulates the Call Browser for debugging.</summary>
        public Task<IVsCallBrowser> GetCallBrowserAsync() => VS.GetRequiredServiceAsync<SVsCallBrowser, IVsCallBrowser>();

        /// <summary>Allows navigation to an object in Class View.</summary>
        public Task<IVsClassView> GetClassViewAsync() => VS.GetRequiredServiceAsync<SVsClassView, IVsClassView>();

        /// <summary>Enables the package to use the Command Window.</summary>
        public Task<IVsCommandWindow> GetCommandWindowAsync() => VS.GetRequiredServiceAsync<SVsCommandWindow, IVsCommandWindow>();

        /// <summary>Implemented by the environment. Used by VsPackages that want to manipulate Object Browser.</summary>
        public Task<IVsObjBrowser> GetObjectBrowserAsync() => VS.GetRequiredServiceAsync<SVsObjBrowser, IVsObjBrowser>();

        /// <summary>Manages and controls functions specific to the Output tool window that has multiple panes.</summary>
        public Task<IVsOutputWindow> GetOutputWindowAsync() => VS.GetRequiredServiceAsync<SVsOutputWindow, IVsOutputWindow>();

        /// <summary>Manages lists of task items supplied by task providers.</summary>
        public Task<IVsTaskList> GetTaskListAsync() => VS.GetRequiredServiceAsync<SVsTaskList, IVsTaskList>();

        /// <summary>Used to manage the Toolbox.</summary>
        public Task<IVsToolbox2> GetToolboxAsync() => VS.GetRequiredServiceAsync<SVsToolbox, IVsToolbox2>();
        #endregion

        #region Settings
        /// <summary>Provides access to the settings manager.<br/>
        /// Cast the result to <see cref="IVsSettingsManager"/>.
        /// </summary>
        [CastTo("Microsoft.VisualStudio.Shell.Interop.IVsSettingsManager")]
        public Task<object> GetSettingsManagerAsync() => VS.GetRequiredServiceAsync<SVsSettingsManager, object>();

        /// <summary>Manages a Tools Options dialog box. The environment implements this interface.</summary>
        public Task<IVsToolsOptions> GetToolsOptionsAsync() => VS.GetRequiredServiceAsync<SVsToolsOptions, IVsToolsOptions>();
        #endregion

        [AttributeUsage(AttributeTargets.Method)]
        internal sealed class CastToAttribute : Attribute
        {
#pragma warning disable IDE0060 // Parameter is used by code analyzers only.
            public CastToAttribute(string typeName) { }
#pragma warning restore IDE0060
        }
    }
}
