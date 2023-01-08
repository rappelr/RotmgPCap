using NetFwTypeLib;
using System;

namespace RotmgPCap.Util
{
    internal static class FirewallUtil
    {
        internal static void SetFirewallRule()
        {
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            firewallRule.ApplicationName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Description = "RotmgPCap firewall access, required to capture incoming packets";
            firewallRule.Enabled = true;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = "RotmgPCap";

            try
            {
                firewallPolicy.Rules.Remove("RotmgPCap");
            }
            catch { }


            firewallPolicy.Rules.Add(firewallRule);
        }
    }
}
