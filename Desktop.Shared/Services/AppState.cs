﻿using Immense.RemoteControl.Desktop.Shared.Enums;
using Immense.RemoteControl.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Immense.RemoteControl.Desktop.Shared.Services
{
    public interface IAppState
    {
        event EventHandler<ScreenCastRequest> ScreenCastRequested;

        event EventHandler<Viewer> ViewerAdded;

        event EventHandler<string> ViewerRemoved;

        Dictionary<string, string> ArgDict { get; }
        string DeviceID { get; }
        string Host { get; }
        AppMode Mode { get; }
        string OrganizationId { get; }
        string OrganizationName { get; }
        string RequesterConnectionId { get; }
        string ServiceConnectionId { get; }
        ConcurrentDictionary<string, Viewer> Viewers { get; }
        void InvokeScreenCastRequested(ScreenCastRequest viewerIdAndRequesterName);
        void InvokeViewerAdded(Viewer viewer);
        void InvokeViewerRemoved(string viewerID);
        void UpdateHost(string host);
        void UpdateOrganizationId(string organizationId);
    }

    public class AppState : IAppState
    {
        private readonly ILogger<AppState> _logger;

        public AppState(ILogger<AppState> logger)
        {
            _logger = logger;
        }

        public event EventHandler<ScreenCastRequest>? ScreenCastRequested;

        public event EventHandler<Viewer>? ViewerAdded;

        public event EventHandler<string>? ViewerRemoved;

        public Dictionary<string, string> ArgDict { get; } = new();
        public string DeviceID { get; init; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public AppMode Mode { get; init; }
        public string OrganizationId { get; set; } = string.Empty;
        public string OrganizationName { get; init; } = string.Empty;
        public string RequesterConnectionId { get; init; } = string.Empty;
        public string ServiceConnectionId { get; init; } = string.Empty;

        public ConcurrentDictionary<string, Viewer> Viewers { get; } = new();

        public void InvokeScreenCastRequested(ScreenCastRequest viewerIdAndRequesterName)
        {
            ScreenCastRequested?.Invoke(null, viewerIdAndRequesterName);
        }

        public void InvokeViewerAdded(Viewer viewer)
        {
            ViewerAdded?.Invoke(null, viewer);
        }

        public void InvokeViewerRemoved(string viewerID)
        {
            ViewerRemoved?.Invoke(null, viewerID);
        }

        public void UpdateHost(string host)
        {
            Host = host;
        }

        public void UpdateOrganizationId(string organizationId)
        {
            OrganizationId = organizationId;
        }
    }
}
