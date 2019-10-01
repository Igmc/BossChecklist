﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader.Config;

namespace BossChecklist
{
	[Label("Boss Log Customization")]
	public class BossLogConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public override void OnLoaded() => BossChecklist.BossLogConfig = this;

		[Header("[i:149] [c/ffeb6e:Boss Log UI]")]

		[DefaultValue(typeof(Color), "87, 181, 92, 255")]
		[Label("Boss Log Color")]
		[Tooltip("Choose the color of your Boss Log!")]
		public Color BossLogColor { get; set; }

		[DefaultValue(false)]
		[Label("Reset Records Option")]
		[Tooltip("Allows you to reset you records for bosses by double right-clicking the boss records button")]
		public bool ResetRecordsBool { get; set; }

		[DefaultValue(true)]
		[Label("Check Next Boss")]
		[Tooltip("Puts a circle in the checkbox to indicate it is the next undefeated boss to fight")]
		public bool DrawNextMark { get; set; }

		[DefaultValue(true)]
		[Label("Colored Boss Text")]
		[Tooltip("The boss text in the table of contents will be green when defeated and red when not.\nIf next check is enabled, the next boss will be yellow.")]
		public bool ColoredBossText { get; set; }

		[DefaultValue(true)]
		[Label("Boss Silhouettes")]
		[Tooltip("Masks the images of bosses when they have not been defeated.")]
		public bool BossSilhouettes { get; set; }
		
		[DrawTicks]
		[Label("Checklist Markings Type")]
		[OptionStrings(new string[] { "✓ and  ☐", "✓ and  X", "X and  ☐" })]
		[DefaultValue("✓ and  ☐")]
		public string SelectedCheckmarkType { get; set; }

		[DrawTicks]
		[Label("Filter bosses in list")]
		[Tooltip("Note: Changing filters within the boss log does save your preferences")]
		[OptionStrings(new string[] { "Show", "Hide when completed" })]
		[DefaultValue("Show")]
		public string FilterBosses { get; set; }

		[DrawTicks]
		[Label("Filter mini bosses in list")]
		[Tooltip("Note: Changing filters within the boss log does save your preferences")]
		[OptionStrings(new string[] { "Show", "Hide when completed", "Hide" })]
		[DefaultValue("Show")]
		public string FilterMiniBosses { get; set; }

		[DrawTicks]
		[Label("Filter events in list")]
		[Tooltip("Note: Changing filters within the boss log does save your preferences")]
		[OptionStrings(new string[] { "Show", "Hide when completed", "Hide" })]
		[DefaultValue("Show")]
		public string FilterEvents { get; set; }
		
		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			return true;
		}
	}

	[Label("Other Features")]
	public class ClientConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public override void OnLoaded() => BossChecklist.ClientConfig = this;

		[Header("[i:3037] [c/ffeb6e:Despawn Messages]")]

		[DrawTicks]
		[Label("Boss Despawn Messages")]
		[OptionStrings(new string[] { "Custom", "Generic", "Disabled" })]
		[DefaultValue("Generic")]
		public string DespawnMessageType { get; set; }

		/* EXAMPLE RADIO BUTTON
		[DefaultValue(true)]
		[Label("Boss Despawn Messages: Custom")]
		public bool CDespawnBool {
			get { return DespawnState == 0; }
			set { if (value) DespawnState = 0; }
		}

		[DefaultValue(false)]
		[Label("Boss Despawn Messages: Generic")]
		public bool GDespawnBool {
			get { return DespawnState == 1; }
			set { if (value) DespawnState = 1; }
		}

		[DefaultValue(false)]
		[Label("Boss Despawn Messages: None")]
		public bool ODespawnBool {
			get { return DespawnState == 2; }
			set { if (value) DespawnState = 2; }
		}
		*/

		[DefaultValue(true)]
		[Label("Pillar Defeated Messages")]
		[Tooltip("The Lunar Pillars will send defeated messages in chat")]
		public bool PillarMessages { get; set; }

		[DefaultValue(false)]
		[Label("Segment Defeated Messages")]
		[Tooltip("Multi-segmented bosses will send messages when a segment is defeated")]
		public bool LimbMessages { get; set; }

		[Header("[i:893] [c/ffeb6e:Item Map Detection]")]

		[DefaultValue(true)]
		[Label("Fragments display on map")]
		public bool FragmentsBool { get; set; }

		[DefaultValue(false)]
		[Label("Shadow Scales and Tissue Samples display on map")]
		public bool ScalesBool { get; set; }

		[Header("[i:3084] [c/ffeb6e:Boss Radar]")]

		[Label("Enable Boss Radar")]
		[DefaultValue(true)]
		public bool BossRadarBool { get; set; }
		
		[Label("Whitelist mini bosses")]
		[Tooltip("Note: This only works properly with mini bosses that have head icons")]
		[DefaultValue(false)]
		public bool RadarMiniBosses { get; set; }

		[Label("Radar Opacity")]
		[Tooltip("Amount of transparency with the radar icon")]
		[Range(0.35f, 0.85f)]
		[DefaultValue(0.75f)]
		public float OpacityFloat { get; set; }
		
		[Label("Radar Blacklist")]
		[Tooltip("These NPCs will not be tracked by the radar")]
		public List<NPCDefinition> RadarBlacklist { get; set; } = new List<NPCDefinition>();

		public override void OnChanged() {
			BossRadarUI.blacklistChanged = true;
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			return true;
		}
	}

	[Label("Debug Interface")]
	public class DebugConfiguration : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public override void OnLoaded() => BossChecklist.DebugConfig = this;

		[Header("[i:149] [c/ffeb6e:Info]")]

		[DefaultValue(false)]
		[Label("Truely Dead Check")]
		[Tooltip("When a boss NPC dies, it mentions in chat if the boss is completely gone")]
		public bool ShowTDC { get; set; }

		[DrawTicks]
		[Label("Show record timers and counters")]
		[OptionStrings(new string[] { "None", "RecordTimers", "BrinkChecker", "MaxHealth", "DeathTracker", "DodgeTimer", "AttackCounter" })]
		[DefaultValue("None")]
		public string ShowTimerOrCounter { get; set; }
		
		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			return true;
		}
	}
}