﻿//using System;
//using System.Collections.Generic;
//using System.Text;

//using RhuEngine.Managers;
//using RhuEngine.WorldObjects;

//using RNumerics;
//using RhuEngine.Linker;

//namespace RhuEngine.Components.PrivateSpace.Windows
//{
//	public class DebugWindow:Window
//	{
//		public override bool? OnLogin => null;

//		public override string Name => "Debug";

//		private string GetUserList() {
//			var returnstring = "";
//			var currentUserID = 0;
//			if (WorldManager.FocusedWorld != null) {
//				foreach (User item in WorldManager.FocusedWorld.Users) {
//					returnstring += $"User: {currentUserID + 1} UserRef: {item.Pointer} UserName: {item.UserName} PeerLoaded: {item.CurrentPeer != null} UserID: {item.userID.Value} IsLocal: {WorldManager.FocusedWorld.GetLocalUser() == item} SyncStreamsCount: {item.syncStreams.Count} isPresent: {item.isPresent.Value} isConnected: {item.IsConnected} peerID: {item.CurrentPeer?.ID.ToString()??"null"}  latency{item.CurrentPeer?.latency??-1}\n";
//					currentUserID++;
//				}
//			}
//			else {
//				returnstring = "Not in session\n";
//			}
//			return returnstring;
//		}

//		public bool ShowVolumes = false;

//		public override void Update() {
//			Hierarchy.Push(Matrix.S(0.5f));
//			UI.WindowBegin("    ===---===     Debug Window     ===---===", ref windowPose, new Vec2(0.4f, 0));
//			CloseDraw();
//			var e = ShowVolumes;
//			UI.Toggle("ShowVolumes", ref e);
//			if(e != ShowVolumes) {
//				UI.ShowVolumes = ShowVolumes= e;
//			}
//			UI.Text(@$"

//=====---- EngineStatistics ----=====
//Is Login {Engine.netApiManager.IsLoggedIn}
//Username {Engine.netApiManager.User?.UserName ?? "Null"}
//UserID {Engine.netApiManager.User?.Id ?? "Null"}

//worldManager stepTime {WorldManager.TotalStepTime * 1000f:f3}ms
//FPS {1 / Time.Elapsedf:f3}
//RunningTime {Time.Totalf:f3}
//Worlds Open {WorldManager.worlds.Count}
//Soft Keyboard Open {Platform.KeyboardVisible}
//File Picker Open {Platform.FilePickerVisible}
//Eyes Tracked {Input.EyesTracked.IsActive()}
//Main Mic {Engine.MainMic ?? "System Default"}
//XRType {Backend.XRType}
//Bounds Pose {StereoKit.World.BoundsPose}
//Bounds Size {StereoKit.World.BoundsSize}
//Has Bounds {StereoKit.World.HasBounds}
//Occlusion Enabled {StereoKit.World.OcclusionEnabled}
//Raycast Enabled {StereoKit.World.RaycastEnabled}


//=====---- Focused World ----=====
//UserID {WorldManager.FocusedWorld.GetLocalUser()?.userID.Value ?? "Null"}
//LastFocusChange {WorldManager.FocusedWorld?.LastFocusChange}
//IsLoading {WorldManager.FocusedWorld?.IsLoading}
//IsLoadingNet {WorldManager.FocusedWorld?.IsLoadingNet}
//WaitingForState {WorldManager.FocusedWorld?.WaitingForWorldStartState}
//IsDeserializing {WorldManager.FocusedWorld?.IsDeserializing}
//World Name {WorldManager.FocusedWorld?.WorldName.Value ?? "Null"}
//Session Name {WorldManager.FocusedWorld?.SessionName.Value ?? "Null"}

//MasterUserID {WorldManager.FocusedWorld?.MasterUser}
//UserID {WorldManager.FocusedWorld?.LocalUserID}
//UserCount {WorldManager.FocusedWorld?.Users.Count}

//Updating Entities {WorldManager.FocusedWorld?.UpdatingEntityCount}
//Entities {WorldManager.FocusedWorld?.EntityCount}
//Networkeds {WorldManager.FocusedWorld?.NetworkedObjectsCount}
//WorldObjects {WorldManager.FocusedWorld?.WorldObjectsCount}
//RenderComponents {WorldManager.FocusedWorld?.RenderingComponentsCount}
//GlobalStepables {WorldManager.FocusedWorld?.GlobalStepableCount}
//stepTime {(WorldManager.FocusedWorld?.stepTime * 1000f).Value:f3}ms
//=====    FocusedWorld Users    =====
//{GetUserList()}
//=====FocusedWorld NetStatistics=====
//{((WorldManager.FocusedWorld?.NetStatistics is not null) ?
//$@"BytesReceived {WorldManager.FocusedWorld?.NetStatistics?.BytesReceived.ToString()}
//BytesSent {WorldManager.FocusedWorld?.NetStatistics?.BytesSent}
//PacketLoss {WorldManager.FocusedWorld?.NetStatistics?.PacketLoss}
//PacketLossPercent {WorldManager.FocusedWorld?.NetStatistics?.PacketLossPercent}
//PacketsReceived {WorldManager.FocusedWorld?.NetStatistics?.PacketsReceived}
//PacketsSent {WorldManager.FocusedWorld?.NetStatistics?.PacketsSent}" : "No NetStatistics for this world")}
//=====-----------------------=====
//");
//			var serverindex = 0;
//			foreach (var item in WorldManager.FocusedWorld?.relayServers) {
//				UI.Text($"RelayServer{serverindex} Connections{item.peers.Count} latency{item.latency}");
//				serverindex++;
//			}
//			UI.WindowEnd();
//			Hierarchy.Pop();
//		}
//		public DebugWindow(Engine engine, WorldManager worldManager, WorldObjects.World world) :base(engine,worldManager,world) {
//		}
//	}
//}
